using System;
using Pendulum.Models;
using UniRx;
using UnityEngine;
using Zenject;

namespace Pendulum.Views
{
    public class CircleView : MonoBehaviour, IDisposable
    {
        public class Factory : PlaceholderFactory<CircleModel, CircleView>
        {
            
        }

        private CircleModel _model;

        [Inject]
        private void Construct(CircleModel model)
        {
            _model = model;
        }

        private void Start()
        {
            _model
                .OnDestroyedAsRx()
                .Subscribe(_ => Dispose())
                .AddTo(this);
        }

        public void Dispose()
        {
            Destroy(gameObject);
        }
    }
}