using System;
using AnimationDemo.Views;
using Circle;
using Environment;
using Flasks;
using GameStage.Controllers;
using GameStage.Data;
using GameStage.Interfaces;
using Pendulum.Views;
using UniRx;
using Zenject;

namespace GameRule
{
    public class EnvironmentRule: IInitializable, IDisposable
    {
        private readonly IGameStageService _gameStageController;
        private readonly FlasksView.Factory _flasksFactory;
        private readonly PendulumView.Factory _pendulumFactory;
        private readonly WorldUtility _worldUtility;
        private readonly CharacterDemo.Factory _characterFactory;
        private readonly CharacterVATDemo.Factory _characterVATFactory;
        private readonly CircleRepository _circleRepository;

        private FlasksView _flasksView;
        private PendulumView _pendulumView;
        private CharacterDemo _character;
        private CharacterVATDemo _characterVat;
        
        private readonly CompositeDisposable _compositeDisposable = new();

        public EnvironmentRule(IGameStageService gameStageController, FlasksView.Factory flasksFactory, 
            PendulumView.Factory pendulumFactory, WorldUtility worldUtility, CharacterDemo.Factory characterFactory,
            CharacterVATDemo.Factory characterVatFactory, CircleRepository repository)
        {
            _gameStageController = gameStageController;
            _flasksFactory = flasksFactory;
            _pendulumFactory = pendulumFactory;
            _worldUtility = worldUtility;
            _characterFactory = characterFactory;
            _characterVATFactory = characterVatFactory;
            _circleRepository = repository;
        }

        public void Initialize()
        {
            _gameStageController
                .GameStageAsObservable()
                .Subscribe(OnStateChanged)
                .AddTo(_compositeDisposable);
        }
        
        private void OnStateChanged(GameStageId stageId)
        {
            switch (stageId)
            {
                case GameStageId.StartMenu:
                    _character = _characterFactory.Create(_worldUtility.TopCenterPosition);
                    _characterVat = _characterVATFactory.Create(_worldUtility.BottomCenterPosition);
                    break;
                case GameStageId.Game:
                    if (_character != null) _character.Dispose();
                    if (_characterVat != null) _characterVat.Dispose();
                    
                    _flasksView = _flasksFactory.Create(_worldUtility.BottomCenterPosition);
                    _pendulumView = _pendulumFactory.Create(_worldUtility.TopCenterPosition);
                    break;
                case GameStageId.Finish:
                    if (_flasksView != null) _flasksView.Dispose();
                    if (_pendulumView != null) _pendulumView.Dispose();
                    _circleRepository.Clear();
                    break;
                default:
                    break;
            }
        }

        public void Dispose()
        {
            _compositeDisposable?.Dispose();
        }
    }
}