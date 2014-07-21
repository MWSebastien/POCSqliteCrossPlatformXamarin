using POC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC
{
    public interface IService
    {
        Task<List<Velib>> GetVelib();
    }
}
