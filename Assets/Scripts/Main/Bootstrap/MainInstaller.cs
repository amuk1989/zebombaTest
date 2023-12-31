﻿using AnimationDemo;
using Circle;
using Effects;
using Environment;
using Flasks;
using GameStage.Bootstrap;
using Input;
using Pendulum.Bootstrap;
using UI.Bootstrap;
using Zenject;

namespace Main.Bootstrap
{
    public class MainInstaller: MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Install<PendulumInstaller>();
            Container.Install<InputInstaller>();
            Container.Install<GameStageInstaller>();
            Container.Install<EnvironmentInstaller>();
            Container.Install<FlasksInstaller>();
            Container.Install<CircleInstaller>();
            Container.Install<GameRuleInstaller>();
            Container.Install<EffectsInstaller>();
            Container.Install<UIBootstrap>();
            Container.Install<AnimationDemoInstaller>();
        }
    }
}