using System;
using System.Collections.Generic;
using Pendulum.Views;
using UniRx;
using Zenject;

namespace Pendulum.Repositories
{
	public class CircleViewsRepository: IInitializable, IDisposable
	{
		private readonly CircleRepository _circleRepository;
		private readonly CircleView.Factory _circleViewFactory;

		private List<CircleView> _circleViews = new();
		private readonly CompositeDisposable _compositeDisposable = new();

		public CircleViewsRepository(CircleRepository circleRepository, CircleView.Factory circleViewFactory)
		{
			_circleRepository = circleRepository;
			_circleViewFactory = circleViewFactory;
		}

		public void Initialize()
		{
			_circleRepository
				.ModelAddedAsRx()
				.Subscribe(model => _circleViews.Add(_circleViewFactory.Create(model)))
				.AddTo(_compositeDisposable);
		}

		public void Dispose()
		{
			_compositeDisposable?.Dispose();
		}
	}
}

