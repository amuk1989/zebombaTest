using Circle;
using Flasks;
using GameStage.Interfaces;
using Pendulum.Controllers;

namespace GameStage.Stages
{
    internal class GamingStage: IGameStage
    {
        private readonly PendulumController _pendulumController;
        private readonly CircleController _circleController;
        private readonly FlasksController _flasksController;

        public GamingStage(PendulumController pendulumController, CircleController circleController, 
            FlasksController flasksController)
        {
            _pendulumController = pendulumController;
            _circleController = circleController;
            _flasksController = flasksController;
        }

        public void Execute()
        {
            _pendulumController.StartMoving();
            _circleController.StartSpawnFlow();
            _flasksController.Spawn();
        }

        public void Complete()
        {
            _pendulumController.StopMoving();
            _circleController.StopSpawnFlow();
            _flasksController.DeSpawn();
        }
    }
}