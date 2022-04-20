using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VtigerIntegration.Models;

namespace VtigerIntegration.Interfaces
{
    public interface IVTigerService
    {
        Task<VTigerLead> AddLead(VTigerLead lead);

    }
}
