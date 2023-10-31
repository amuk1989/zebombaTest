using System;
using UniRx;
using UnityEngine;
using Zenject;

namespace Circle
{
    public class CircleView : MonoBehaviour, IDisposable
    {
        public class Factory : PlaceholderFactory<CircleModel, CircleView>
        {
            
        }

        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Rigidbody2D _rigidbody;

        private CircleModel _model;

        [Inject]
        private void Construct(CircleModel model)
        {
            _model = model;
        }

        private void Start()
        {
            transform.position = _model.Position;
            _spriteRenderer.color = _model.Color;
            
            _model
                .OnDestroyedAsRx()
                .Subscribe(_ => Dispose())
                .AddTo(this);
            
            _rigidbody.velocity = Vector2.down;
        }

        private void Update()
        {
            _model.SetVelocity(_rigidbody.velocity);
            _model.SetPosition(transform.position);
        }

        public void Dispose()
        {
            Destroy(gameObject);
        }
    }
}