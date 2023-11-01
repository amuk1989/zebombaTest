using GameStage.Controllers;
using GameStage.Data;
using GameStage.Factories;
using GameStage.Interfaces;
using GameStage.Stages;
using Zenject;

namespace GameStage.Bootstrap
{
    public class GameStageInstaller: Installer
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IGameStage>()
                .WithId(GameStageId.StartMenu)
                .To<StartMenuStage>()
                .AsSingle();

            Container
                .Bind<IGameStage>()
                .WithId(GameStageId.Game)
                .To<GamingStage>()
                .AsSingle();
            
            Container
                .Bind<IGameStage>()
                .WithId(GameStageId.Finish)
                .To<FinishStage>()
                .AsSingle();

            Container
                .BindInterfacesTo<GameStageController>()
                .AsSingle()
                .NonLazy();

            Container
                .BindFactory<GameStageId, IGameStage, GameStageFactory>()
                .FromFactory<GameStageInstanceFactory>();
        }
    }
}