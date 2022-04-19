using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VtigerIntegration.Models
{
    /// <summary>
    /// VTiger-SMSNotifier object
    /// </summary>
    public class VTigerSMSNotifier : VTigerEntity
    {
        public override VTigerEntity CreateNewInstance()
        {
            return (VTigerEntity)new VTigerSMSNotifier();
        }
        public override string RemoteTableName() { return "SMSNotifier"; }
        public override VTigerType GetElementType() { return VTigerType.SMSNotifier; }
        public VTigerSMSNotifier() { }
        public VTigerSMSNotifier(string assigned_user_id, string message)
        {
            this.assigned_user_id = assigned_user_id;
            this.message = message;
        }
        public string assigned_user_id; //mandatory
        public DateTime createdtime;
        public DateTime modifiedtime;
        public string message; //mandatory
    }
}
