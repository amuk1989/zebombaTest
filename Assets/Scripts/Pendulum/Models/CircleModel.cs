using System;
using UniRx;
using UnityEngine;
using Zenject;

namespace Pendulum.Models
{
    public class CircleModel
    {
        public class Factory:PlaceholderFactory<Vector3, CircleModel>
        {
        }
        
        private readonly ReactiveCommand _onDestroyed = new();

        private Vector3 _startPosition;

        public CircleModel(Vector3 position)
        {
            _startPosition = position;
        }

        public IObservable<Unit> OnDestroyedAsRx() => _onDestroyed.AsObservable();
    }
}