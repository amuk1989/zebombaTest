using Pendulum.Views;
using UnityEngine;

namespace Pendulum.Configs
{
    [CreateAssetMenu(fileName = "CircleConfig", menuName = "Configs/CircleConfig", order = 0)]
    public class CircleConfig : ScriptableObject
    {
        [SerializeField] private CircleView _circlePrefab;

        public CircleView CirclePrefab => _circlePrefab;
    }
}