using System;
using Input.Interfaces;
using Pendulum.Models;
using Pendulum.Repositories;
using Pendulum.Views;
using UniRx;
using UnityEngine;
using Zenject;

namespace Pendulum.Controllers
{
    public class CircleController: IInitializable
    {
        private readonly IInputProvider _inputProvider;
        private readonly CircleModel.Factory _circleFactory;
        private readonly CircleRepository _circleRepository;

        private Transform _circleSpawnTransform;
        private IDisposable _inputFlow;

        public CircleController(IInputProvider inputProvider, CircleModel.Factory circleFactory, CircleRepository circleRepository)
        {
            _inputProvider = inputProvider;
            _circleFactory = circleFactory;
            _circleRepository = circleRepository;
        }

        public void Initialize()
        {
            StartSpawnFlow();
        }

        public void StartSpawnFlow()
        {
            _inputFlow = _inputProvider
                .ClickAsObservable()
                .Subscribe(inputPosition =>
                {
                    var position = _circleSpawnTransform == null ? inputPosition : _circleSpawnTransform.position;
                    _circleRepository.CreateModel(position);
                });
        }

        public void StopSpawnFlow()
        {
            _inputFlow?.Dispose();
        }

        public void SetSpawnTransform(Transform transform) => _circleSpawnTransform = transform;
    }
}