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
        private BaseUI _progressUI;

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
                .Where(x => x == GameStageId.StartMenu)
                .Subscribe(_ => _uiPrefabFactory.Create("Prefabs/UI/NextStage", _uiComponent.Transform))
                .AddTo(_compositeDisposable);
        }

        public void Dispose()
        {
            _compositeDisposable?.Dispose();
        }
    }
}