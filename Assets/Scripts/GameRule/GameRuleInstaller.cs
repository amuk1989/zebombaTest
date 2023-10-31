using Zenject;

namespace Circle
{
    public class GameRuleInstaller:Installer
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<GameRuleController>()
                .AsSingle()
                .NonLazy();
        }
    }
}