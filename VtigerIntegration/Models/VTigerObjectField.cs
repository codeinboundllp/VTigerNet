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
    public class VTigerObjectField
    {
        public string label;
        public string name;
        public bool mandatory;
        public VTigerTypeDesc type;
        public bool nullable;
        public bool editable;
    }
}
