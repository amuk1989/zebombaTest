using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;
using Zenject;

namespace Circle
{
    public class GameRuleController: IInitializable, IDisposable
    {
        private const float TrashHold = 0.3f;

        private readonly List<string> _circlesInMatrix = new();
        private readonly Dictionary<string, IDisposable> _fellCircles = new();
        
        private readonly CompositeDisposable _compositeDisposable = new();
        private readonly ReactiveCommand _gameOver = new();
        private readonly ReactiveProperty<int> _gamePoints = new(0);

        private readonly CircleRepository _circleRepository;
        private readonly GameRuleConfig _gameRuleConfig;

        public GameRuleController(CircleRepository circleRepository, GameRuleConfig config)
        {
            _circleRepository = circleRepository;
            _gameRuleConfig = config;
        }

        public void Initialize()
        {
            _circleRepository
                .ModelRemovedAsRx()
                .Subscribe(model =>
                {
                    if (!_circlesInMatrix.Contains(model.Id)) return;
                    _circlesInMatrix.Remove(model.Id);
                })
                .AddTo(_compositeDisposable);

            _circleRepository
                .ModelAddedAsRx()
                .Subscribe(model =>
                    _fellCircles[model.Id] = model
                        .IsFellAsRx()
                        .Where(x => x)
                        .Subscribe(x => Registry(model)))
                .AddTo(_compositeDisposable);
        }

        public void Dispose()
        {
            _compositeDisposable?.Dispose();
        }

        private void Registry(CircleModel model)
        {
            _circlesInMatrix.Add(model.Id);
            
            var isDestroyed = TryDestroyLines(model.Position, out var destroyCount);

            _gamePoints.Value += destroyCount;

            if (!isDestroyed && _circlesInMatrix.Count >= _gameRuleConfig.MaxCircles) _gameOver.Execute();
        }

        private bool TryDestroyLines(Vector3 position, out int destroyCount)
        {
            destroyCount = 0;
            
            if (!TryGetLines(position, out var circlesId)) return false;

            foreach (var id in circlesId)
            {
                _circleRepository.DestroyModel(id);
            }

            destroyCount = circlesId.Count;

            return true;
        }

        private bool TryGetLines(Vector3 position, out List<string> circles)
        {
            circles = GetRawId(position);
            if (circles.Count < _gameRuleConfig.CirclesCountInLine || !IsSameColor(circles)) circles.Clear();
            
            circles.AddRange(GetColumnId(position));
            if (circles.Count < _gameRuleConfig.CirclesCountInLine || !IsSameColor(circles)) circles.Clear();

            return circles.Count >= _gameRuleConfig.CirclesCountInLine;
        }

        private List<string> GetRawId(Vector3 position)
        {
            var raw = new List<string>();
            foreach (var circleItem in _circlesInMatrix)
            {
                var circle = _circleRepository.Models[circleItem];
                if (Mathf.Abs(position.y - circle.Position.y) < TrashHold) raw.Add(circleItem); 
            }

            return raw;
        }
        
        private List<string> GetColumnId(Vector3 position)
        {
            var column = new List<string>();
            foreach (var circleItem in _circlesInMatrix)
            {
                var circle = _circleRepository.Models[circleItem];
                if (Mathf.Abs(position.x - circle.Position.x) < TrashHold) column.Add(circleItem); 
            }

            return column;
        }

        private bool IsSameColor(List<string> circles)
        {
            var color = _circleRepository.Models[circles[0]].Color;

            for (int i = 1; i < circles.Count; i++)
            {
                if (_circleRepository.Models[circles[i]].Color != color) return false;
            }

            return true;
        }
    }
}