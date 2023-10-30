using System;
using Zenject;

public class InputInstaller : Installer
{
    public override void InstallBindings()
    {
        Container
            .BindInterfacesTo<InputService>()
            .AsSingle()
            .NonLazy();
    }
}

