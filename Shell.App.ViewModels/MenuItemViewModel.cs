using Shell.Core;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Input;

namespace Shell.App.ViewModels
{
    public class MenuItemViewModel : ViewModelBase
    {
        //private readonly CommandParameter parameter;

        public MenuItemViewModel(/*MenuItem menuItem*/)
        {
            //this.Header = menuItem.Header;
            this.Command = new RelayCommand(Navigate);
            //this.parameter = menuItem.Command;
           // this.ChildMenuItems = menuItem.MenuItems == null ? new List<MenuItemViewModel>() : menuItem.MenuItems.Select(y => new MenuItemViewModel(y)).ToList();
        }

        public ICommand Command
        {
            get { return Get<ICommand>("Command"); }
            private set { Set(value, "Command"); }
        }

        public string Header
        {
            get { return Get<string>("Header"); }
            private set { Set(value, "Header"); }
        }

        public List<MenuItemViewModel> ChildMenuItems
        {
            get { return Get<List<MenuItemViewModel>>("MenuItems"); }
            private set { Set(value, "MenuItems"); }
        }

        private void Navigate()
        {
            //if (parameter != null)
            //{
            //    var assembly = Assembly.Load(parameter.Assembly);
            //    var type = assembly.GetType(parameter.Type);

            //    if (parameter.Method == string.Empty)
            //    {
            //        //open new window
            //    }
            //    else
            //    {
            //        var method = type.GetMethod(parameter.Method, BindingFlags.Public | BindingFlags.Static);

            //        method.Invoke(this, null);
            //    }
            //}
        }
    }
}
