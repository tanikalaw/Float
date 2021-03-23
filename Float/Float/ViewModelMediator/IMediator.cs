using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Float.ViewModelMediator
{
    interface IMediator
    {
        void Register(Action<object> callback, string message);
        void NotifyViewModel(string message, object args);

    }
}
