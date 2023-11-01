using UnityEngine;

namespace Effects
{
    [CreateAssetMenu(fileName = "EffectsConfig", menuName = "Configs/Effects Config", order = 0)]
    public class EffectsConfig : ScriptableObject
    {
        [SerializeField] private EffectView _effectPrefab;
        [Range(0.1f,5f)][SerializeField] private float _lifeTime;

        public EffectView EffectPrefab => _effectPrefab;
        public float LifeTime => _lifeTime;
    }
}