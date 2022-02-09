using Enums;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "Figure", menuName = "Chess/Figure", order = 1)]
    public class FigureData : ScriptableObject
    {
        [SerializeField] private FigureType _type;
        [SerializeField] private FigureColor _color;
        [SerializeField] private MoveRuleType _moveRule;
        [SerializeField] private GameObject _prefab;
        
        public FigureType Type => _type;
        public FigureColor Color => _color;
        public MoveRuleType MoveRule => _moveRule;
        public GameObject Prefab => _prefab;
    }
}