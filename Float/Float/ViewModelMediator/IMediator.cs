using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Float.ViewModelMediator
{
    interface IMediator
    {
        void Register(object vm);
        void NotifyViewModel(string viewModel, string message, object args);

    }
}
