using System;
using Circle;
using UnityEngine;
using Zenject;

namespace Flasks
{
    public class FlaskTriggerView : MonoBehaviour
    {
        private FlaskModel _flaskModel;
        private FlaskRepository _repository;
        
        [Inject]
        private void Construct(FlaskRepository repository)
        {
            _repository = repository;
        }

        private void Start()
        {
            _flaskModel = _repository.RegistryFlask(transform.position);
        }

        private void OnDestroy()
        {
            _repository.RemoveFlask(_flaskModel);
        }
    }
}