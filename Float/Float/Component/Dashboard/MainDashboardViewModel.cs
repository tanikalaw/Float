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
            ShowRightUserControls = new ObservableCollection<object>();
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

        public ICommand OpenHomeControlCommand => new DelegateCommand(OpenHomeControl);


        private void ShowControlsOnRight(object window)
        {
            ShowRightUserControls.Clear();
            ShowRightUserControls.Add(window);
        }

        private void OpenHomeControl()
        {
            HomeView homeView = new HomeView();
            ShowControlsOnRight(homeView);
        }
    }
}
