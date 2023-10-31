using Pendulum.Configs;
using Pendulum.Models;
using Pendulum.Views;
using UnityEngine;
using Zenject;

namespace Pendulum.Factories
{
    public class CircleViewFactory: IFactory<CircleModel, CircleView>
    {
        private readonly DiContainer _container;
        private readonly CircleConfig _config;

        public CircleViewFactory(DiContainer container, CircleConfig config)
        {
            _container = container;
            _config = config;
        }

        public CircleView Create(CircleModel model)
        {
            return _container.InstantiatePrefabForComponent<CircleView>(_config.CirclePrefab, new object[] {model});
        }
    }
}