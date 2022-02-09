using System;
using Enums;
using UnityEngine;

namespace DefaultNamespace
{

    public class Cell : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private GameObject _figureObj;
        [SerializeField] private FigureType _figureType;
        [SerializeField] private MeshRenderer _meshRenderer;
        [SerializeField] private Material _material;

        public Transform Transform => _transform;
        public GameObject FigureObj => _figureObj;
        public FigureType FigureType => _figureType;

        public void SetupCell(GameObject figureObj, FigureType figureType)
        {
            _figureObj = figureObj;
            _figureType = figureType;
            
            figureObj.transform.SetParent(transform);
            figureObj.transform.localScale = Vector3.one * 10f;
            figureObj.transform.localPosition = Vector3.zero;
        }

        public void SetCellEmpty()
        {
            _figureObj = null;
            _figureType = FigureType.None;
        }

        public GameObject RemoveFigureFromDesk()
        {
            return _figureObj;
        }

        public void SetupReferences()
        {
            _transform = GetComponent<Transform>();
            _meshRenderer = GetComponent<MeshRenderer>();
            _material = _meshRenderer.material;
        }

        public void ChooseCell()
        {
            _material.color = Color.red;
            _meshRenderer.enabled = true;
        }
        
        public void SetPossibleMoveCell()
        {
            _material.color = Color.green;
            _meshRenderer.enabled = true;
        }

        public void UnchooseCell()
        {
            _material.color = Color.white;
            _meshRenderer.enabled = false;
        }
    }
}