using Float.BaseModel;
using Float.Command;
using Float.Component.Home;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Float.Components.Dashboard
{
    public class MainDashboardViewModel : BaseViewModel
    {
        public MainDashboardViewModel()
        {
            HomeView = new HomeView();
            ShowRightUserControls = new ObservableCollection<object>();
            ShowControlsOnRight(HomeView);
        }

        private ObservableCollection<object> showRightUserControls;
        public ObservableCollection<object> ShowRightUserControls

        {
            get => showRightUserControls;
            set
            {
                showRightUserControls = value;
                RaisedPropertyChanged(nameof(ShowRightUserControls));
            }
        }

        private HomeView homeView;
        public HomeView HomeView

        {
            get => homeView;
            set
            {
                homeView = value;
                RaisedPropertyChanged(nameof(HomeView));
            }
        }

        public int MyProperty { get; set; }

        public ICommand OpenHomeControlCommand => new DelegateCommand(OpenHomeControl);


        private void ShowControlsOnRight(object window)
        {
            ShowRightUserControls.Clear();
            ShowRightUserControls.Add(window);
        }

        private void OpenHomeControl()
        {
            ShowControlsOnRight(HomeView);
        }
    }
}
