using System.Collections.Generic;
using System.Linq;
using Flasks.Interfaces;
using UnityEngine;

namespace Flasks
{
    public class FlaskService: IFlaskService
    {
        private readonly FlaskRepository _repository;

        private FlaskService(FlaskRepository repository)
        {
            _repository = repository;
        }

        public void AddFlaskContent(IFlaskContent content)
        {
            GetNearbyModel(content.Position).AddItem(content);
        }

        public void RemoveFlaskContent(IFlaskContent content)
        {
            foreach (var model in _repository.FlaskModels())
            {
                model.TryRemoveItem(content);
            }
        }

        public bool CanAcceptContent(Vector3 position)
        {
            return !GetNearbyModel(position).IsFool();
        }

        private FlaskModel GetNearbyModel(Vector3 position)
        {
            FlaskModel result = null;
            foreach (var model in _repository.FlaskModels())
            {
                if (result == null ||
                    Mathf.Abs(position.x - model.FlaskPosition.x) < Mathf.Abs(position.x - result.FlaskPosition.x)) result = model;
            }

            return result;
        }
    }
}