using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._source.Observer
{
    interface IObserver
    {
        void Invoke(string eventName);
    }
}
