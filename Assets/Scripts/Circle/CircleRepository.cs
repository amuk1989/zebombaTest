using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;

namespace Circle
{
    public class CircleRepository
    {
        private readonly ReactiveDictionary<string, CircleModel> _models = new();

        private readonly CircleModel.Factory _circleFactory;
        private int _modelId;

        public CircleRepository(CircleModel.Factory circleFactory)
        {
            _circleFactory = circleFactory;
        }

        public IDictionary<string, CircleModel> Models => _models;
        public IObservable<CircleModel> ModelAddedAsRx() => _models.ObserveAdd().Select(x => x.Value).AsObservable();
        public IObservable<CircleModel> ModelRemovedAsRx() => _models.ObserveRemove().Select(x => x.Value).AsObservable();

        public CircleModel CreateModel(Vector3 position, Color color)
        {
            var model = _circleFactory.Create(_modelId++.ToString(), position, color);
            _models.Add(model.Id, model);
            return model;
        }
        
        public void DestroyModel(string id)
        {
            if (!_models.ContainsKey(id)) return;
            _models[id].Destroy();
            _models.Remove(id);
        }

        public void Clear()
        {
            foreach (var model in _models)
            {
                model.Value.Destroy();
            }
            
            _models.Clear();
        }
    }
}

