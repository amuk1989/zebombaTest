using System;
using Pendulum.Models;
using UniRx;

public class CircleRepository
{
    private readonly ReactiveCollection<CircleModel> _models = new();

    public IObservable<CircleModel> ModdelAddedAsRX() => _models.ObserveAdd.AsObservable();
}

