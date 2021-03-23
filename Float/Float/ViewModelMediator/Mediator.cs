using Float.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Float.ViewModelMediator
{
    public class Mediator : BaseViewModel
    {

        static readonly Mediator instance = new Mediator();
        MultiDictionary<string, BaseViewModel> internalList = new MultiDictionary<string, BaseViewModel>();

        static Mediator()
        {

        }
        public Mediator()
        {

        }

        public static Mediator Instance
        {
            get { return instance; }
        }

        public void Register(BaseViewModel viewModel, string message)
        {
            internalList.AddValue(message, viewModel);
        }

        public void Unregister(BaseViewModel viewModel, string message)
        {
            if (internalList.ContainsKey(message))
            {
                internalList.Remove(message);
            }
        }

        public void NotifyViewModel(string viewModelName, string message, object args)
        {
            if (internalList.ContainsKey(viewModelName))
            {
                foreach(BaseViewModel viewModel in internalList[viewModelName])
                {
                    viewModel.SendData(message, args);
                }
            }
        }
    }
}
