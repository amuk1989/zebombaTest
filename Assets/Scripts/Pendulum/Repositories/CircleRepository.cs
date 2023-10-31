using System;
using Pendulum.Models;
using UniRx;
using UnityEngine;

namespace Pendulum.Repositories
{
    public class CircleRepository
    {
        private readonly ReactiveCollection<CircleModel> _models = new();

        private readonly CircleModel.Factory _circleFactory;

        public CircleRepository(CircleModel.Factory circleFactory)
        {
            _circleFactory = circleFactory;
        }

        public IObservable<CircleModel> ModelAddedAsRx() => _models.ObserveAdd().Select(x => x.Value).AsObservable();

        public void CreateModel(Vector3 position)
        {
            _models.Add(_circleFactory.Create(position));
        }
    }
}

