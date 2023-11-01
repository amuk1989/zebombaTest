using System;
using UniRx;

namespace AnimationDemo.Models
{
    public class CharacterModel
    {
        private readonly ReactiveProperty<CharacterState> _state = new();

        internal void ChangeState(CharacterState state)
        {
            _state.Value = state;
        }
        
        public IObservable<CharacterState> StateAsRx() => _state.AsObservable();
    }

    public enum CharacterState
    {
        Idle,
        Dance
    }
}