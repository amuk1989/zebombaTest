using System;
using UniRx;
using Zenject;

namespace Pendulum.Models
{
    public class CircleModel
    {
        public class Factory:PlaceholderFactory<CircleModel>
        {
        }
        
        private readonly ReactiveCommand _onDestroyed = new();


        public IObservable<Unit> OnDestroyedAsRx() => _onDestroyed.AsObservable();
    }
}