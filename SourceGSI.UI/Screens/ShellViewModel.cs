using Caliburn.Micro;
using SourceGSI.UI.Core;
using System;

namespace SourceGSI.UI.Screens
{
    public class ShellViewModel : Conductor<IScreen>, IWindowConductor
    {
        private readonly IWindowManager _windowManager;

        public ShellViewModel(IWindowManager windowManager)
        {
            _windowManager = windowManager;
        }

        protected override void OnInitialize()
        {
            Show<DashboardViewModel>();

            base.OnInitialize();
        }

        #region IWindowConductor

        public void Show<T>(Action<T> initAction = null) where T : IScreen
        {
            var screen = IoC.Get<T>();
            initAction?.Invoke(screen);
            ActivateItem(screen);
        }

        public T ShowDialog<T>(Action<T> initAction = null) where T : IScreen
        {
            var screen = IoC.Get<T>();
            initAction?.Invoke(screen);
            _windowManager.ShowDialog(screen);
            return screen;
        }

        public T ShowWindow<T>(Action<T> initAction = null) where T : IScreen
        {
            var screen = IoC.Get<T>();
            initAction?.Invoke(screen);
            _windowManager.ShowWindow(screen);
            return screen;
        }

        public T ShowPopup<T>(Action<T> initAction = null) where T : IScreen
        {
            var screen = IoC.Get<T>();
            initAction?.Invoke(screen);
            _windowManager.ShowPopup(screen);
            return screen;
        }

        #endregion
    }
}
