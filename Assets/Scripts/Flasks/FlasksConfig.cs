using UnityEngine;

namespace Flasks
{
    [CreateAssetMenu(fileName = "FlasksConfig", menuName = "Configs/Flasks Config", order = 0)]
    public class FlasksConfig : ScriptableObject
    {
        [SerializeField] private FlasksView flasksPrefab;

        public FlasksView Prefab => flasksPrefab;
    }
}