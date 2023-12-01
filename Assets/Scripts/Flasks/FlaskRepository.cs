using System.Collections.Generic;
using UnityEngine;

namespace Flasks
{
    internal class FlaskRepository
    {
        private readonly List<FlaskModel> _falskModels = new();

        private readonly FlaskModel.Factory _factory;

        public FlaskRepository(FlaskModel.Factory factory)
        {
            _factory = factory;
        }

        internal FlaskModel RegistryFlask(Vector3 position)
        {
            var model = _factory.Create(position);
            _falskModels.Add(model);
            return model;
        }
        
        internal void RemoveFlask(FlaskModel model)
        {
            _falskModels.Remove(model);
        }

        internal IEnumerable<FlaskModel> FlaskModels() => _falskModels;
    }
}