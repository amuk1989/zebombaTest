using System;
using Input.Interfaces;
using UniRx;
using UnityEngine;
using Zenject;

namespace Input
{
    public class InputService : IInputProvider, IInitializable, IDisposable
    {
        private IDisposable _inputFlow;

        private readonly ReactiveCommand<Vector3> _onTapped = new();

        public void Dispose()
        {
            _inputFlow?.Dispose();
        }

        public void Initialize()
        {
            _inputFlow = Observable
                .EveryUpdate()
                .Subscribe(_ =>
                {
                    var touch = UnityEngine.Input.GetTouch(0);

                    if (touch.phase == TouchPhase.Began) _onTapped.Execute(touch.position);
                });
        }

        public IObservable<Vector3> ClickAsObservable()
        {
            return _onTapped.AsObservable();
        }
    }
}

