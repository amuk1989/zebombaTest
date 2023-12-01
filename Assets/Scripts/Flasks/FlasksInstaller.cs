﻿using UnityEngine;
using Zenject;

namespace Flasks
{
    public class FlasksInstaller: Installer
    {
        private readonly FlasksConfig _flasksConfig;

        public FlasksInstaller(FlasksConfig flasksConfig)
        {
            _flasksConfig = flasksConfig;
        }

        public override void InstallBindings()
        {
            Container
                .BindFactory<Vector3, FlasksView, FlasksView.Factory>()
                .FromComponentInNewPrefab(_flasksConfig.Prefab);

            Container
                .BindFactory<Vector3, FlaskModel, FlaskModel.Factory>();

            Container
                .BindInterfacesAndSelfTo<FlaskRepository>()
                .AsSingle()
                .Lazy();

            Container
                .BindInterfacesTo<FlaskService>()
                .AsSingle()
                .NonLazy();
        }
    }
}