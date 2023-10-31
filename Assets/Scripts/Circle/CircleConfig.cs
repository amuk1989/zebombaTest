using UnityEngine;

namespace Circle
{
    [CreateAssetMenu(fileName = "CircleConfig", menuName = "Configs/CircleConfig", order = 0)]
    public class CircleConfig : ScriptableObject
    {
        [SerializeField] private CircleView _circlePrefab;
        [SerializeField] private Color[] _colorsVariations;

        public CircleView CirclePrefab => _circlePrefab;
        public Color[] ColorsVariations => _colorsVariations;
    }
}