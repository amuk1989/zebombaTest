using UnityEngine;

namespace Environment
{
    public class CameraController: ICameraProvider
    {
        public Camera Camera => Camera.main;
        public Vector3 CameraPosition => Camera.transform.position;
    }
}