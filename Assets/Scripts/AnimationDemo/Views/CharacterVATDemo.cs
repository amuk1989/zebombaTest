using AnimationDemo.Models;
using UnityEngine;
using Zenject;

namespace AnimationDemo.Views
{
    public class CharacterVATDemo : CharacterDemoBase
    {
        public class Factory: PlaceholderFactory<Vector3, CharacterVATDemo>
        {
        }
        
        [SerializeField] private Renderer _renderer;
        
        private static readonly int IsDance = Shader.PropertyToID("_IsDance");

        protected override void ChangeAnimationState(CharacterState state)
        {
            switch (state)
            {
                case CharacterState.Dance: _renderer.sharedMaterial.SetInt(IsDance, 1);
                    break;
                case CharacterState.Idle: _renderer.sharedMaterial.SetInt(IsDance, 0);
                    break;
                default:
                    break;
            }
        }
    }
}