using Float.BaseModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Float.Component.Home
{
    public class HomeViewModel : BaseViewModel
    {

        public HomeViewModel()
        {

        }


     

        #region Properties

        private ObservableCollection<object> myProperty;
        public ObservableCollection<object> MyProperty 
        {
            get { return myProperty; }
            set
            {
                myProperty = value;
                RaisedPropertyChanged(nameof(MyProperty));
            }
        }

        #endregion


        #region Commands




        #endregion



        private void InitializeFields()
        { }
    }
}
