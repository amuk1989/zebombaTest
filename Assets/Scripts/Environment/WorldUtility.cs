using UnityEngine;
using Utils;
using Zenject;

namespace Environment
{
    public class WorldUtility: IInitializable
    {
        private readonly ICameraProvider _cameraProvider;
        
        public Vector3 BottomCenterPosition { get; private set; }
        public Vector3 TopCenterPosition { get; private set; }

        public WorldUtility(ICameraProvider cameraProvider)
        {
            _cameraProvider = cameraProvider;
        }

        public void Initialize()
        {
            BottomCenterPosition = _cameraProvider.Camera.ScreenToWorldPoint(new Vector3(Screen.width / 2f, 0, -_cameraProvider.CameraPosition.z));
            TopCenterPosition = _cameraProvider.Camera.ScreenToWorldPoint(new Vector3(Screen.width / 2f, Screen.height, -_cameraProvider.CameraPosition.z));
        }
    }
}