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
            // TODO: Get port from config file / args
            _gameStateServer = new GameStateServer {Port = 3001};

            var container = new Container(_ =>
            {
                _.For<IServiceLocator>().Use(__ => _serviceLocator);
                _.For<IWindowManager>().Singleton().Use<WindowManager>();
                _.For<IGameStateServer>().Use(__ => _gameStateServer);
            });

            _serviceLocator = new StructureMapServiceLocator(container);

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
