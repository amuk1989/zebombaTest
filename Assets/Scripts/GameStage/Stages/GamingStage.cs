using GameStage.Interfaces;
using Pendulum.Controllers;

namespace GameStage.Stages
{
    internal class GamingStage: IGameStage
    {
        private readonly PendulumController _pendulumController;
        private readonly CircleController _circleController;

        public GamingStage(PendulumController pendulumController, CircleController circleController)
        {
            _pendulumController = pendulumController;
            _circleController = circleController;
        }

        public void Execute()
        {
            _pendulumController.StartMoving();
            _circleController.StartSpawnFlow();
        }

        public void Complete()
        {
            _pendulumController.StopMoving();
            _circleController.StopSpawnFlow();
        }
    }
}