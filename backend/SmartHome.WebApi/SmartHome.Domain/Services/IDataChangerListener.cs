using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Domain.Services
{
    public interface IDataChangerListener
    {
        void RegisterListener(Action<string> callback, string smartHomeId);
        void UnregisterListener(Action<string> callback, string smartHomeId);
        void HandleDataChange(string smartHomeId);
    }

}
