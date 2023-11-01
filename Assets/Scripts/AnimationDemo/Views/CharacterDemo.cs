using AnimationDemo.Models;
using UnityEngine;
using Zenject;

namespace AnimationDemo.Views
{
    public class CharacterDemo : CharacterDemoBase
    {
        public class Factory: PlaceholderFactory<Vector3, CharacterDemo>
        {
        }
        
        [SerializeField] private Animator _animatorController;
        
        private static readonly int Dance = Animator.StringToHash("Dance");
        private static readonly int Idle = Animator.StringToHash("Idle");

        protected override void ChangeAnimationState(CharacterState state)
        {
            switch (state)
            {
                case CharacterState.Dance: 
                    _animatorController.ResetTrigger(Idle);
                    _animatorController.SetTrigger(Dance);
                    break;
                case CharacterState.Idle: 
                    _animatorController.ResetTrigger(Dance);
                    _animatorController.SetTrigger(Idle);
                    break;
                default:
                    break;
            }
        }
    }
}