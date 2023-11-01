using System;
using Circle;
using TMPro;
using UnityEngine;
using Zenject;

namespace UI.Views
{
    public class FinishUI: BaseUI
    {
        [SerializeField] private TMP_Text _score;

        [Inject] private GameRuleController _gameRuleController;

        private void Start()
        {
            _score.text = _gameRuleController.GamePoints.ToString();
        }
    }
}