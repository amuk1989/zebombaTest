using UnityEngine;
using Zenject;

namespace Effects
{
    public class EffectView: MonoBehaviour
    {
        public class Factory: PlaceholderFactory<float, Vector3, EffectView>
        {
        }

        [Inject]
        private void Construct(float lifeTime, Vector3 position)
        {
            transform.position = position;
            Destroy(gameObject, lifeTime);
        }
    }
}