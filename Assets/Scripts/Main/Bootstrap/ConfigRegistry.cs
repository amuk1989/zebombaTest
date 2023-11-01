using Circle;
using Effects;
using Flasks;
using GameStage.Bootstrap;
using GameStage.Controllers;
using Pendulum.Bootstrap;
using Pendulum.Configs;
using Pendulum.Models;
using UnityEngine;
using Utils;
using Zenject;

namespace Main.Bootstrap
{
    [CreateAssetMenu(fileName = "ConfigRegistry", menuName = "Registries/ConfigRegistry", order = 0)]
    public class ConfigRegistry : ScriptableObjectInstaller
    {
        [SerializeField] private PendulumConfig _pendulumConfig;
        [SerializeField] private CircleConfig _circleConfig;
        [SerializeField] private GameStageConfig _gameStageConfig;
        [SerializeField] private FlasksConfig _flasksConfig;
        [SerializeField] private GameRuleConfig _gameRuleConfig;
        [SerializeField] private EffectsConfig _effectsConfig;

        public override void InstallBindings()
        {
            Container.InstallRegistry(_pendulumConfig);
            Container.InstallRegistry(_circleConfig);
            Container.InstallRegistry(_gameStageConfig);
            Container.InstallRegistry(_flasksConfig);
            Container.InstallRegistry(_gameRuleConfig);
            Container.InstallRegistry(_effectsConfig);
        }
    }
}