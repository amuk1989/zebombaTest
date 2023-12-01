using System;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Flasks.Interfaces;
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
        private readonly IFlaskService _flaskService;

        private Transform _circleSpawnTransform;
        private IDisposable _inputFlow;
        private bool _canCreateCircle = true;
        
        private readonly ReactiveProperty<Color> _nextColor = new();

        public CircleController(IInputProvider inputProvider, 
            CircleRepository circleRepository, CircleConfig config, IFlaskService flaskService)
        {
            _inputProvider = inputProvider;
            _circleRepository = circleRepository;
            _circleConfig = config;
            _flaskService = flaskService;
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
                .Subscribe(async inputPosition =>
                {
                    if (!_canCreateCircle) return;

                    _canCreateCircle = false;
                    
                    var position = _circleSpawnTransform == null ? inputPosition : _circleSpawnTransform.position;
                    
                    if (!_flaskService.CanAcceptContent(position)) return;

                    var model = _circleRepository.CreateModel(position, _nextColor.Value);

                    _nextColor.Value = _circleConfig.ColorsVariations[Random.Range(0, _circleConfig.ColorsVariations.Length)];

                    await model.IsFellAsRx().Where(x => x).ToUniTask(useFirstValue:true);

                    _canCreateCircle = true;
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