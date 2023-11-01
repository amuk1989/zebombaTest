using System;
using AnimationDemo.Models;
using UI.Views;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace AnimationDemo.Views
{
    public class AnimationSwitchUI : BaseUI
    {
        [SerializeField] protected Toggle _stateSwitch;

        [Inject] private CharacterModel _model;

        private void Start()
        {
            _stateSwitch
                .OnValueChangedAsObservable()
                .Subscribe(value => { _model.ChangeState(value ? CharacterState.Dance : CharacterState.Idle); })
                .AddTo(this);
        }
    }
}