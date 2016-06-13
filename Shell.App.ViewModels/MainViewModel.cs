using Shell.Core;
using System.Collections.Generic;

namespace Shell.App.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region Fields



        #endregion

        #region Constructor

        public MainViewModel()
        {

        }

        #endregion

        #region Property

        public List<MenuItemViewModel> MenuItems
        {
            get { return Get<List<MenuItemViewModel>>("MenuItems"); }
            set { Set(value, "MenuItems"); }
        }

        #endregion

        #region Commands

        #endregion

        #region Methods

        public void Initialize()
        {

        }

        #endregion
    }
}
