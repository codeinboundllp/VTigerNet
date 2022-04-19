using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VtigerIntegration.Models
{
    /// <summary>
    /// VTiger-PBXManager object
    /// </summary>
    public class VTigerPBXManager : VTigerEntity
    {
        public override VTigerEntity CreateNewInstance()
        {
            return (VTigerEntity)new VTigerPBXManager();
        }
        public override string RemoteTableName() { return "PBXManager"; }
        public override VTigerType GetElementType() { return VTigerType.PBXManager; }
        public VTigerPBXManager() { }
        public VTigerPBXManager(string customernumber, string callfrom, string callto, string assigned_user_id)
        {
            this.callfrom = callfrom;
            this.callto = callto;
            this.customernumber = customernumber;
            this.assigned_user_id = assigned_user_id;
        }
        public string callfrom; //mandatory
        public string callto; //mandatory
        public string customernumber; //mandatory
        public string assigned_user_id; //mandatory
        public string timeofcall;
        public string status;
    }
}
