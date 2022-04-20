using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VtigerIntegration.Interfaces;
using VtigerIntegration.Models;

namespace VtigerIntegration.Service
{
    public class VTigerAPIService : IVTigerService
    {
        private readonly VTiger _vtiger;
        public VTigerAPIService(VTigerConfiguration configuration)
        {
            _vtiger = new VTiger(configuration);
        }
       
        public async Task<VTigerLead> AddLead(VTigerLead lead)
        {
            return await _vtiger.Create<VTigerLead>(lead);
        }
    }
}
