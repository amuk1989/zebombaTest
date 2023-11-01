using AnimationDemo.Models;
using AnimationDemo.Views;
using UnityEngine;
using Zenject;

namespace AnimationDemo
{
    public class AnimationDemoInstaller: Installer
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<CharacterModel>()
                .AsSingle()
                .NonLazy();

            Container
                .BindFactory<Vector3, CharacterDemo, CharacterDemo.Factory>()
                .FromComponentInNewPrefabResource("Prefabs/VampireSimple");
            
            Container
                .BindFactory<Vector3, CharacterVATDemo, CharacterVATDemo.Factory>()
                .FromComponentInNewPrefabResource("Prefabs/VampireVAT");
        }
    }
}