using Pendulum.Controllers;
using Pendulum.Factories;
using Pendulum.Models;
using Pendulum.Repositories;
using Pendulum.Views;
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
            
            Container
                .BindInterfacesAndSelfTo<CircleViewsRepository>()
                .AsSingle()
                .NonLazy();
            
            Container
                .BindInterfacesAndSelfTo<CircleRepository>()
                .AsSingle()
                .NonLazy();

            Container
                .BindFactory<CircleModel, CircleView, CircleView.Factory>()
                .FromFactory<CircleViewFactory>();

            Container
                .BindFactory<CircleModel, CircleModel.Factory>();
        }
    }
}