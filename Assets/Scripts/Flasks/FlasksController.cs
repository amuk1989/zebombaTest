using Environment;

namespace Flasks
{
    public class FlasksController
    {
        private readonly FlasksView.Factory _flasksFactory;
        private readonly WorldUtility _worldUtility;

        private FlasksView _prefab;

        public FlasksController(FlasksView.Factory flasksFactory, WorldUtility worldUtility)
        {
            _flasksFactory = flasksFactory;
            _worldUtility = worldUtility;
        }

        public void Spawn()
        {
            _prefab = _flasksFactory.Create(_worldUtility.BottomCenterPosition);
        }

        public void DeSpawn()
        {
            _prefab.Dispose();
        }
    }
}