using System;
using Pendulum.Models;
using UniRx;

namespace Pendulum.Repositories
{
    public class CircleRepository
    {
        private readonly ReactiveCollection<CircleModel> _models = new();

        public IObservable<CircleModel> ModelAddedAsRx() => _models.ObserveAdd().Select(x => x.Value).AsObservable();
    }
}

