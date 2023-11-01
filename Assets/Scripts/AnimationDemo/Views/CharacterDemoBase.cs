using System;
using AnimationDemo.Models;
using UniRx;
using UnityEngine;
using UnityEngine.XR;
using Zenject;

namespace AnimationDemo.Views
{
    public abstract class CharacterDemoBase: MonoBehaviour, IDisposable
    {
        private CharacterModel _characterModel;
        
        [Inject]
        private void Construct(Vector3 position, CharacterModel model)
        {
            _characterModel = model;
            transform.position = position;
        }

        public void Dispose()
        {
            Destroy(gameObject);
        }

        private void Start()
        {
            _characterModel
                .StateAsRx()
                .Subscribe(ChangeAnimationState)
                .AddTo(this);
        }

        protected abstract void ChangeAnimationState(CharacterState state);
    }
}