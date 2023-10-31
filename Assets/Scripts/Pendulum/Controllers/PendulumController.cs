using Pendulum.Models;
using Zenject;

namespace Pendulum.Controllers
{
    public class PendulumController:IInitializable
    {
        private readonly PendulumModel _pendulumModel;

        public PendulumController(PendulumModel pendulumModel)
        {
            _pendulumModel = pendulumModel;
        }

        public void Initialize()
        {
        }

        public void StartMoving() => _pendulumModel.StartMoving();
        public void StopMoving() => _pendulumModel.StopMoving();
    }
}