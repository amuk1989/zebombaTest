using UnityEngine;
using Zenject;

namespace Effects
{
    public class EffectsInstaller: Installer
    {
        private readonly EffectsConfig _config;

        public EffectsInstaller(EffectsConfig config)
        {
            _config = config;
        }

        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<EffectsController>()
                .AsSingle()
                .NonLazy();

            Container
                .BindFactory<float, Vector3, EffectView, EffectView.Factory>()
                .FromComponentInNewPrefab(_config.EffectPrefab);
        }
    }
}