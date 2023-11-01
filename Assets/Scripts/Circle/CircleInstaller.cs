using UnityEngine;
using Zenject;

namespace Circle
{
    public class CircleInstaller: Installer
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<CircleViewsRepository>()
                .AsSingle()
                .NonLazy();
            
            Container
                .BindInterfacesAndSelfTo<CircleRepository>()
                .AsSingle()
                .NonLazy();
            
            Container
                .BindInterfacesAndSelfTo<CircleController>()
                .AsSingle()
                .NonLazy();

            Container
                .BindFactory<CircleModel, CircleView, CircleView.Factory>()
                .FromFactory<CircleViewFactory>();

            Container
                .BindFactory<string, Vector3, Color, CircleModel, CircleModel.Factory>();
        }
    }
}