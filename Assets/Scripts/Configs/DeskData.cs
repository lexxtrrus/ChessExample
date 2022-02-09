using Enums;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "Desk", menuName = "Chess/Desk", order = 0)]
    public class DeskData : ScriptableObject
    {
        [SerializeField] private DeskType _type;
        [SerializeField] private GameObject _prefab;

        public DeskType Type => _type;
        public GameObject Prefab => _prefab;
    }
}