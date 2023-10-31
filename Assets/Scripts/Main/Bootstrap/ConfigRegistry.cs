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

        public override void InstallBindings()
        {
            Container.InstallRegistry(_pendulumConfig);
            Container.InstallRegistry(_circleConfig);
        }
    }
}