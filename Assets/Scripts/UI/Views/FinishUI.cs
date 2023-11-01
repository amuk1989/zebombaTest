using System;
using Circle;
using GameStage.Controllers;
using GameStage.Interfaces;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Views
{
    public class FinishUI: BaseUI
    {
        [SerializeField] private TMP_Text _score;
        [SerializeField] private Button _repeat;
        
        [Inject] private IGameStageService _gameStageController;
        [Inject] private GameRuleController _gameRuleController;

        private void Start()
        {
            _score.text = _gameRuleController.GamePoints.ToString();
            _repeat
                .OnClickAsObservable()
                .Subscribe(_ =>
                {
                    _gameStageController.NextStage();
                    Destroy(gameObject);
                })
                .AddTo(this);
        }
    }
}