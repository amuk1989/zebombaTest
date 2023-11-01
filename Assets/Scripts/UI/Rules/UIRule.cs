using System;
using GameStage.Data;
using GameStage.Interfaces;
using UI.Views;
using UniRx;
using Zenject;

namespace UI.Rules
{
    internal class UIRule: IInitializable, IDisposable
    {
        private readonly CompositeDisposable _compositeDisposable = new();
        
        private readonly IGameStageService _gameStageService;
        private readonly UIComponent _uiComponent;
        private readonly BaseUI.Factory _uiPrefabFactory;
        private BaseUI _changeAnimation;

        public UIRule(IGameStageService gameStageService, 
            UIComponent uiComponent, BaseUI.Factory uiPrefabFactory)
        {
            _gameStageService = gameStageService;
            _uiComponent = uiComponent;
            _uiPrefabFactory = uiPrefabFactory;
        }

        public void Initialize()
        {
            _gameStageService
                .GameStageAsObservable()
                .Subscribe(OnStateChanged)
                .AddTo(_compositeDisposable);
        }

        public void Dispose()
        {
            _compositeDisposable?.Dispose();
        }

        private void OnStateChanged(GameStageId stageId)
        {
            switch (stageId)
            {
                case GameStageId.StartMenu:
                    _uiPrefabFactory.Create("Prefabs/UI/NextStage", _uiComponent.Transform);
                    _changeAnimation = _uiPrefabFactory.Create("Prefabs/UI/AnimationState", _uiComponent.Transform);
                    break;
                case GameStageId.Game:
                    if (_changeAnimation != null) _changeAnimation.Dispose();
                    break;
                case GameStageId.Finish:
                    break;
                default:
                    break;
            }
        }
    }
}