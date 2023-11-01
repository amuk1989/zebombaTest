using System;
using Circle;
using Pendulum.Controllers;
using Pendulum.Models;
using UniRx;
using UnityEngine;
using Zenject;

namespace Pendulum.Views
{
    public class PendulumView : MonoBehaviour, IDisposable
    {
        public class Factory : PlaceholderFactory<Vector3, PendulumView>{}
        
        [SerializeField] private Transform _circlePosition;
        [SerializeField] private SpriteRenderer _circleRenderer;
        
        private PendulumModel _model;
        private CircleController _circleController;
        
        [Inject]
        private void Construct(Vector3 position, PendulumModel model, CircleController controller)
        {
            _model = model;
            _circleController = controller;

            transform.position = position;
        }

        private void Start()
        {
            _circleController.SetSpawnTransform(_circlePosition);
            
            _model
                .RotationAsObservable()
                .Subscribe(value => transform.rotation = value)
                .AddTo(this);

            _circleController
                .NextColorAsRx()
                .Subscribe(color => _circleRenderer.color = color)
                .AddTo(this);
        }

        public void Dispose()
        {
            Destroy(gameObject);
        }
    }
}