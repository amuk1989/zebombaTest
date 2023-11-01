using System;
using Circle;
using UniRx;
using Zenject;

namespace Effects
{
    public class EffectRule: IInitializable, IDisposable
    {
        private readonly CircleRepository _circleRepository;
        private readonly EffectsController _effectsController;
        private readonly CompositeDisposable _compositeDisposable = new();

        public EffectRule(CircleRepository circleRepository, EffectsController effectsController)
        {
            _circleRepository = circleRepository;
            _effectsController = effectsController;
        }

        public void Initialize()
        {
            _circleRepository
                .ModelRemovedAsRx()
                .Subscribe(model => _effectsController.CreateEffect(model.Position))
                .AddTo(_compositeDisposable);
        }

        public void Dispose()
        {
            _compositeDisposable?.Dispose();
        }
    }
}