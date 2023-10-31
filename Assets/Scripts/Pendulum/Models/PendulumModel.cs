using System;
using Pendulum.Configs;
using UniRx;
using UnityEngine;
using Zenject;

namespace Pendulum.Models
{
    public class PendulumModel:IDisposable
    {
        private readonly PendulumConfig _config;
        
        private readonly ReactiveProperty<Quaternion> _rotation = new();

        private IDisposable _movingFlow;

        public PendulumModel(PendulumConfig config)
        {
            _config = config;
        }

        public IObservable<Quaternion> RotationAsObservable() => _rotation.AsObservable();

        public void StartMoving()
        {
            var startAngle = 0 - _config.RangeAngle / 2f;
            var stopAngle = _config.RangeAngle / 2f;
            var currentAngle = startAngle;
            var direction = 1f;
            
            _movingFlow = Observable
                .EveryUpdate()
                .Subscribe(_ =>
                {
                    currentAngle += Time.deltaTime * direction * _config.MaxSpeed;
                    
                    if (currentAngle >= stopAngle) direction = -1;
                    if (currentAngle <= startAngle) direction = 1;
                    
                    _rotation.Value = Quaternion.Euler(0, 0, currentAngle);
                });
        }

        public void StopMoving()
        {
            _movingFlow?.Dispose();
        }

        public void Dispose()
        {
            _movingFlow?.Dispose();
        }
    }
}