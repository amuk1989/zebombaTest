using UnityEngine;

namespace Environment
{
    public interface ICameraProvider
    {
        public Camera Camera { get; }
        public Vector3 CameraPosition { get; }
    }
}