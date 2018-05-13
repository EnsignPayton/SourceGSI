using System;
using System.Collections.Generic;
using System.Windows;
using Caliburn.Micro;
using CommonServiceLocator.StructureMapAdapter.Unofficial;
using Microsoft.Practices.ServiceLocation;
using SourceGSI.UI.Core;
using SourceGSI.UI.Screens;
using StructureMap;

namespace SourceGSI.UI
{
    public class AppBootstrapper : BootstrapperBase
    {
        private IServiceLocator _serviceLocator;
        private IGameStateServer _gameStateServer;

        public AppBootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            var container = new Container(_ =>
            {
                _.For<IServiceLocator>().Use(__ => _serviceLocator);
                _.For<IEventAggregator>().Singleton().Use<EventAggregator>();
                _.For<IWindowManager>().Singleton().Use<WindowManager>();
                _.For<IWindowConductor>().Singleton().Use<ShellViewModel>();
                _.For<IGameStateServer>().Singleton().Use<GameStateServer>();
            });

            _serviceLocator = new StructureMapServiceLocator(container);
            _gameStateServer = _serviceLocator.GetInstance<IGameStateServer>();
            _gameStateServer.Port = 3001; // TODO: Read from config
            _gameStateServer.Start();

            DisplayRootViewFor<ShellViewModel>();
        }

        protected override void OnExit(object sender, EventArgs e)
        {
            _gameStateServer.Stop();
            var disposableServer = _gameStateServer as IDisposable;
            disposableServer?.Dispose();

            base.OnExit(sender, e);
        }

        protected override object GetInstance(Type service, string key)
        {
            return _serviceLocator.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _serviceLocator.GetAllInstances(service);
        }
    }
}
