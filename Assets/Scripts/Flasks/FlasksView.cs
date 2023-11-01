using System;
using UnityEngine;
using Zenject;

namespace Flasks
{
    public class FlasksView : MonoBehaviour, IDisposable
    {
        public class Factory:PlaceholderFactory<Vector3, FlasksView>
        {
        }
        
        [Inject]
        private void Construct(Vector3 position)
        {
            transform.position = position;
        }

        public void Dispose()
        {
            Destroy(gameObject);
        }
    }
}