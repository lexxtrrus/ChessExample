using System.Collections.Generic;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu]
    public class GameModeData: ScriptableObject
    {
        [SerializeField] private DeskData _deskData;
        [SerializeField] private GameObject _cellPrefab;

        [SerializeField] private List<CellData> _whitesFigures;
        [SerializeField] private List<CellData> _blackFigures;

        public DeskData DeskData => _deskData;
        public GameObject CellPrefab => _cellPrefab;

        public List<CellData> LightFigures => _whitesFigures;
        public List<CellData> DarkFigures => _blackFigures;
    }
}