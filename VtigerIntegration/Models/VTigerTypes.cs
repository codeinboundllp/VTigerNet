using Jayrock.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VtigerIntegration.Models
{
    public class VTigerTypes
    {
        public string[] types;
        public VTigerTypeInfo[] typeInfo;
        public JsonObject information;
    }
}
