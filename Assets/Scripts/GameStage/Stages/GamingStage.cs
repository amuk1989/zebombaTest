using System;
using Circle;
using Flasks;
using GameStage.Interfaces;
using Pendulum.Controllers;
using UniRx;

namespace GameStage.Stages
{
    internal class GamingStage: IGameStage
    {
        private readonly PendulumController _pendulumController;
        private readonly CircleController _circleController;
        private readonly GameRuleController _gameRuleController;

        public GamingStage(PendulumController pendulumController, CircleController circleController, 
            GameRuleController controller)
        {
            _pendulumController = pendulumController;
            _circleController = circleController;
            _gameRuleController = controller;
        }

        public IObservable<Unit> StageCompletedAsRx()
        {
            return _gameRuleController.GameOverAsRx();
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