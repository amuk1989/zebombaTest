using System;
using UniRx;
using UnityEngine;
using Zenject;

namespace Circle
{
    public sealed class CircleModel
    {
        public class Factory:PlaceholderFactory<string, Vector3, Color, CircleModel>
        {
        }
        
        private readonly ReactiveCommand _onDestroyed = new();
        private readonly ReactiveProperty<bool> _isFell = new(false);

        private Vector3 _position;
        private readonly Color _color;

        public CircleModel(string id, Vector3 position, Color color)
        {
            _position = position;
            _color = color;
            Id = id;
        }

        public Vector3 Position => _position;
        public Color Color => _color;
        public string Id { get; private set; }

        public IObservable<Unit> OnDestroyedAsRx() => _onDestroyed.AsObservable();
        public IObservable<bool> IsFellAsRx() => _isFell.AsObservable();

        public void Destroy()
        {
            _onDestroyed.Execute();
        }

        public void SetVelocity(Vector3 velocity)
        {
            if (!_isFell.Value) _isFell.Value = velocity.sqrMagnitude < 0.01f;
        }
        
        public void SetPosition(Vector3 velocity)
        {
            _position = velocity;
        }
    }
}