using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Configs;
using DefaultNamespace;
using Enums;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private GameModeData _gameModeData;
    [SerializeField] private Camera _camera;
    
    private Cell[,] _cells = new Cell[8,8];
    private List<Cell> _possibleMoves = new List<Cell>();

    private GameObject _board;
    private string[] _chars = new string[8] {"a","b","c","d","f","g","e","h"};

    private bool isCellSelected = false;
    private RaycastHit lastHit;
    private RaycastHit nextHit;
    private Cell lastCell;
    
    private void Awake()
    {
        _board = Instantiate(_gameModeData.DeskData.Prefab, Vector3.zero, Quaternion.identity);

        InstantiateCells();
        SetupCells();
    }

    private void SetupCells()
    {
        GameObject temp;
        
        foreach (var lightFigure in _gameModeData.LightFigures)
        {
            temp = Instantiate(lightFigure.FigureData.Prefab);
            _cells[(int)lightFigure.X,(int)lightFigure.Y].SetupCell(temp, lightFigure.FigureData.Type);
        }
        
        foreach (var darkFigure in _gameModeData.DarkFigures)
        {
            temp = Instantiate(darkFigure.FigureData.Prefab);
            _cells[(int)darkFigure.X,(int)darkFigure.Y].SetupCell(temp, darkFigure.FigureData.Type);
        }
    }

    private void InstantiateCells()
    {
        Vector3 pos;
        
        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                pos = new Vector3(x, 0.01f, y);
                _cells[x, y] = Instantiate(_gameModeData.CellPrefab, pos, Quaternion.identity).AddComponent<Cell>();
                _cells[x, y].gameObject.name = $"{_chars[x]}-{y+1}";
                _cells[x,y].SetCellEmpty();
                _cells[x, y].SetupReferences();
                _cells[x,y].transform.SetParent(transform);
            }
        }
    }

    private void Update()
    {
        if (isCellSelected)
        {
            if (Input.GetMouseButtonDown(0))
            {
                lastCell.UnchooseCell();
                lastCell = null;
                isCellSelected = false;
                ClearPossibleMoves();
                
                var ray = _camera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out lastHit))
                {
                    var last = lastHit.transform.GetComponent<Cell>();

                    if (_possibleMoves.Any(c => c.transform == last.transform))
                    {
                        // TO DO
                        // change chosen figure position 
                    }
                }
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                var ray = _camera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out lastHit))
                {
                    var last = lastHit.transform.GetComponent<Cell>();

                    if(last.FigureType == FigureType.None) return;
                    
                    if (last == lastCell)
                    {
                        SetNonSelectedState();
                        return;
                    }

                    isCellSelected = true;
                    lastCell = last;
                    SetPossibleMove(lastCell, lastCell.FigureType);
                    lastCell.ChooseCell();
                }
            }
        }
    }

    private void ClearPossibleMoves()
    {
        foreach (var possible in _possibleMoves)
        {
            possible.UnchooseCell();
        }
        
        _possibleMoves.Clear();
    }

    private void SetPossibleMove(Cell cell, FigureType selected)
    {
        switch (selected)
        {
            case FigureType.Pawn:
                var pos = cell.transform.position;
                var x = (int)pos.x;
                var y = (int)pos.z;

                if (y < 7)
                {
                    if (_cells[x, y + 1].FigureType == FigureType.None)
                    {
                        _possibleMoves.Add(_cells[x,y + 1]);
                    }
                }

                foreach (var possible in _possibleMoves)
                {
                    possible.SetPossibleMoveCell();
                }
                break;
            
            case FigureType.Knight:
                break;
            case FigureType.Bishop:
                break;
            case FigureType.Rook:
                break;
            case FigureType.Queen:
                break;
            case FigureType.King:
                break;
        }
    }

    private void SetNonSelectedState()
    {
        lastCell.UnchooseCell();
        lastCell = null;
        isCellSelected = false;
    }
}
