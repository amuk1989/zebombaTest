using System;
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
        
        [Inject]
        private void Construct(PendulumModel model)
        {
            _model = model;
        }

        private void Start()
        {
            _model
                .RotationAsObservable()
                .Subscribe(value => transform.rotation = value)
                .AddTo(this);
        }
    }
}