using UnityEngine;

namespace Configs
{
    [System.Serializable]
    public class CellData
    {
        [SerializeField] private Vector2 pos;
        [SerializeField] private FigureData _figureData;

        public float X => pos.x;
        public float Y => pos.y;
        public FigureData FigureData => _figureData;
    }
}