using System.Collections.Generic;
using Flasks.Interfaces;
using UnityEngine;
using Zenject;

namespace Flasks
{
    internal class FlaskModel
    {
        internal class Factory:PlaceholderFactory<Vector3, FlaskModel>
        {
        }

        private readonly FlasksConfig _config;
        private readonly Vector3 _flaskPosition;
        private readonly List<IFlaskContent> _flaskContents = new();

        public FlaskModel(Vector3 flaskPosition, FlasksConfig config)
        {
            _config = config;
            _flaskPosition = flaskPosition;
        }

        private bool _isFull;
        private uint _countOfContent;

        public Vector3 FlaskPosition => _flaskPosition;

        internal void AddItem(IFlaskContent item)
        {
            _flaskContents.Add(item);
        }
        
        internal void TryRemoveItem(IFlaskContent item)
        {
            if (_flaskContents.Contains(item)) _flaskContents.Remove(item);
        }
        
        internal void RemoveAllItems()
        {
            _flaskContents.Clear();
        }

        internal bool IsFool() => _flaskContents.Count >= _config.FlaskCapacity;
    }
}