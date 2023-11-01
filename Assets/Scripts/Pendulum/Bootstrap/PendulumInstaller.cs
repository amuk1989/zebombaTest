using Circle;
using Pendulum.Configs;
using Pendulum.Controllers;
using Pendulum.Models;
using Pendulum.Views;
using UnityEngine;
using Zenject;

namespace Pendulum.Bootstrap
{
    public class PendulumInstaller: Installer
    {
        private readonly PendulumConfig _config;

        public PendulumInstaller(PendulumConfig config)
        {
            _config = config;
        }

        public override void InstallBindings()
        {
            Container
                .Bind<PendulumModel>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<PendulumController>()
                .AsSingle()
                .NonLazy();

            Container
                .BindFactory<Vector3, PendulumView, PendulumView.Factory>()
                .FromComponentInNewPrefab(_config.PendulumPrefab);
        }
    }
}