using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VtigerIntegration.Models
{
    /// <summary>
    /// VTiger-Groups object
    /// </summary>
    public class VTigerGroup : VTigerEntity
    {
        public override VTigerEntity CreateNewInstance()
        {
            return (VTigerEntity)new VTigerGroup();
        }
        public override string RemoteTableName() { return "Groups"; }
        public override VTigerType GetElementType() { return VTigerType.Groups; }
        public string groupname;
        public string description;
    }
}
