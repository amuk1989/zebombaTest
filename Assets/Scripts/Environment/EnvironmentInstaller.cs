using Zenject;

namespace Environment
{
    public class EnvironmentInstaller: Installer
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesTo<CameraController>()
                .AsSingle()
                .NonLazy();
            
            Container
                .BindInterfacesAndSelfTo<WorldUtility>()
                .AsSingle()
                .NonLazy();
        }
    }
}