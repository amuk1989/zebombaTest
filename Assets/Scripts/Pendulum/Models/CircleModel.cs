using System;
using UniRx;
using UnityEngine;
using Zenject;

namespace Pendulum.Models
{
    public class CircleModel
    {
        public class Factory:PlaceholderFactory<Vector3, Color, CircleModel>
        {
        }
        
        private readonly ReactiveCommand _onDestroyed = new();

        private readonly Vector3 _startPosition;
        private readonly Color _color;

        public CircleModel(Vector3 position, Color color)
        {
            _startPosition = position;
            _color = color;
        }

        public Vector3 StartPosition => _startPosition;
        public Color Color => _color;

        public IObservable<Unit> OnDestroyedAsRx() => _onDestroyed.AsObservable();
    }
}