using System;
using Caliburn.Micro;

namespace SourceGSI.UI.Core
{
    public interface IWindowConductor
    {
        /// <summary>
        /// Show a screen as the ActiveItem.
        /// </summary>
        /// <typeparam name="T">ViewModel</typeparam>
        /// <param name="initAction">Initialization Action</param>
        void Show<T>(Action<T> initAction = null) where T : IScreen;

        /// <summary>
        /// Show a screen in a modal dialog.
        /// </summary>
        /// <typeparam name="T">ViewModel</typeparam>
        /// <param name="initAction">Initialization Action</param>
        /// <returns>ViewModel</returns>
        T ShowDialog<T>(Action<T> initAction = null) where T : IScreen;

        /// <summary>
        /// Show a screen in a non-modal window.
        /// </summary>
        /// <typeparam name="T">ViewModel</typeparam>
        /// <param name="initAction">Initialization Action</param>
        /// <returns>ViewModel</returns>
        T ShowWindow<T>(Action<T> initAction = null) where T : IScreen;

        /// <summary>
        /// Show a screen in a popup control at the current mouse position.
        /// </summary>
        /// <typeparam name="T">ViewModel</typeparam>
        /// <param name="initAction">Initialization Action</param>
        /// <returns>ViewModel</returns>
        T ShowPopup<T>(Action<T> initAction = null) where T : IScreen;
    }
}
