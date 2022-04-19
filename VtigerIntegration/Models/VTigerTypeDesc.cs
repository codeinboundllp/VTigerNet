using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VtigerIntegration.Models
{
    /// <summary>
    /// Part of VTigerObjectType
    /// </summary>
    public class VTigerTypeDesc
    {
        public string name;
        public VTigerPicklistItem[] picklistValues;
        public string[] refersTo;
    }
}
