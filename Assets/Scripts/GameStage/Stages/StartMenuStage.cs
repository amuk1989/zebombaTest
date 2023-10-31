using System;
using GameStage.Interfaces;
using UniRx;

namespace GameStage.Stages
{
    internal class StartMenuStage: IGameStage
    {
        public IObservable<Unit> StageCompletedAsRx()
        {
            return Observable.Empty<Unit>();
        }

        public void Execute()
        {
        }

        public void Complete()
        {
        }
    }
}