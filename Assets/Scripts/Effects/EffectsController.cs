using UnityEngine;

namespace Effects
{
    public class EffectsController
    {
        private readonly EffectView.Factory _factory;
        private readonly EffectsConfig _config;

        public EffectsController(EffectView.Factory factory, EffectsConfig config)
        {
            _factory = factory;
            _config = config;
        }

        public void CreateEffect(Vector3 position)
        {
            _factory.Create(_config.LifeTime, position);
        }
    }
}