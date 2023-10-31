using System;
using UnityEngine;

namespace Input.Interfaces
{
    public interface IInputProvider
    {
        public IObservable<Vector3> ClickAsObservable();
        public void StartInputFlow();
        public void StopInputFlow();
    }
}

