using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POC.Models;
using POC.ViewModels;

namespace POC
{


    public interface IRestService : IService
    {
    }

    public class ServiceProxy
    {
        private ServiceProxy()
        {
            Service = new RestService();
        }

        public IService Service
        {
            get;
            private set;
        }

        private static ServiceProxy _instance;
        public static ServiceProxy Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ServiceProxy();
                return _instance;
            }
        }
    }

}
