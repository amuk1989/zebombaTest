using Circle;
using Pendulum.Controllers;
using Pendulum.Models;
using Pendulum.Views;
using UnityEngine;
using Zenject;

namespace Pendulum.Bootstrap
{
    public class PendulumInstaller: Installer
    {
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
        }
    }
}