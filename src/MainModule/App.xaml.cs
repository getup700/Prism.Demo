using MainModule.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;
using ModuleB;
using ModuleA;
using DialogSample;
using System.IO;
using Microsoft.Extensions.Configuration;
using Prism.DryIoc;
using MainModule.Handler;
using DryIoc;
using System;

namespace MainModule;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App
{
    public static IContainerProvider ContainerProvider { get; private set; }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json",false,true)
            .Build();
        containerRegistry.RegisterInstance<IConfiguration>(config);
        containerRegistry.Register<CommonMessageHandler>();
        containerRegistry.Register<ErrorMessageHandler>();
    }

    protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
    {
        moduleCatalog.AddModule<ModuleAProfile>();
        moduleCatalog.AddModule<ModuleBProfile>();
        moduleCatalog.AddModule<DialogProfile>();
        base.ConfigureModuleCatalog(moduleCatalog);
    }

    protected override Window CreateShell()
    {
        ContainerProvider = Container;
        return Container.Resolve<MainWindow>();
    }

    protected override void OnExit(ExitEventArgs e)
    {
        base.OnExit(e);
    }
}
