using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VtigerIntegration.Models
{
    /// <summary>
    /// Containts the description of a VTiger-object
    /// </summary>
    public class VTigerObjectType
    {
        public string label;
        public string name;
        public bool createable;
        public bool updateable;
        public bool deleteable;
        public bool retrieveable;
        public VTigerObjectField[] fields;
        public string idPrefix;
        public string isEntity;
        public string labelFields;
    }
}
