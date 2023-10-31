using UnityEngine;

namespace Circle
{
    [CreateAssetMenu(fileName = "GameRuleConfig", menuName = "Configs/GameRuleConfig", order = 0)]
    public class GameRuleConfig: ScriptableObject
    {
        [Range(1,6)][SerializeField] private int _circlesCountInLine;
        [Range(1,9)][SerializeField] private int _maxCircles;

        public int CirclesCountInLine => _circlesCountInLine;
        public int MaxCircles => _maxCircles;
    }
}