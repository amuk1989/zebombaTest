using Environment;
using Flasks;
using GameStage.Bootstrap;
using Input;
using Pendulum.Bootstrap;
using Zenject;

namespace Main.Bootstrap
{
    public class MainInstaller: MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Install<PendulumInstaller>();
            Container.Install<InputInstaller>();
            Container.Install<GameStageInstaller>();
            Container.Install<EnvironmentInstaller>();
            Container.Install<FlasksInstaller>();
        }
    }
}