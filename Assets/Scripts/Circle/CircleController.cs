using System;
using Input.Interfaces;
using UniRx;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Circle
{
    public class CircleController: IInitializable
    {
        private readonly IInputProvider _inputProvider;
        private readonly CircleRepository _circleRepository;
        private readonly CircleConfig _circleConfig;

        private Transform _circleSpawnTransform;
        private IDisposable _inputFlow;
        private ReactiveProperty<Color> _nextColor = new();

        public CircleController(IInputProvider inputProvider, 
            CircleRepository circleRepository, CircleConfig config)
        {
            _inputProvider = inputProvider;
            _circleRepository = circleRepository;
            _circleConfig = config;
        }

        public IObservable<Color> NextColorAsRx() => _nextColor.AsObservable();

        public void Initialize()
        {
        }

        public void StartSpawnFlow()
        {
            _inputProvider.StartInputFlow();
            
            _nextColor.Value = _circleConfig.ColorsVariations[Random.Range(0, _circleConfig.ColorsVariations.Length)];
            
            _inputFlow = _inputProvider
                .ClickAsObservable()
                .Subscribe(inputPosition =>
                {
                    var position = _circleSpawnTransform == null ? inputPosition : _circleSpawnTransform.position;
                    _circleRepository.CreateModel(position, _nextColor.Value);
                    
                    _nextColor.Value = _circleConfig.ColorsVariations[Random.Range(0, _circleConfig.ColorsVariations.Length)];
                });
        }

        public void StopSpawnFlow()
        {
            _inputFlow?.Dispose();
            _inputProvider.StopInputFlow();
        }

        internal void SetSpawnTransform(Transform transform) => _circleSpawnTransform = transform;
    }
}