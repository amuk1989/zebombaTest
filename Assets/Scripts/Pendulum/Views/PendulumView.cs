using System;
using Pendulum.Controllers;
using Pendulum.Models;
using UniRx;
using UnityEngine;
using Zenject;

namespace Pendulum.Views
{
    public class PendulumView : MonoBehaviour
    {
        [SerializeField] private Transform _circlePosition;
        
        private PendulumModel _model;
        private CircleController _circleController;
        
        [Inject]
        private void Construct(PendulumModel model, CircleController controller)
        {
            _model = model;
            _circleController = controller;
        }

        private void Start()
        {
            _circleController.SetSpawnTransform(transform);
            
            _model
                .RotationAsObservable()
                .Subscribe(value => transform.rotation = value)
                .AddTo(this);
        }
    }
}