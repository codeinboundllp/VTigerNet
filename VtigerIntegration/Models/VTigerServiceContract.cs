using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VtigerIntegration.Models
{
    /// <summary>
    /// VTiger-ServiceContracts object
    /// </summary>
    public class VTigerServiceContract : VTigerEntity
    {
        public override VTigerEntity CreateNewInstance()
        {
            return (VTigerEntity)new VTigerServiceContract();
        }
        public override string RemoteTableName() { return "ServiceContracts"; }
        public override VTigerType GetElementType() { return VTigerType.ServiceContracts; }
        public VTigerServiceContract() { }
        public VTigerServiceContract(string subject, string assigned_user_id)
        {
            this.assigned_user_id = assigned_user_id;
            this.subject = subject;
        }
        public string assigned_user_id; //mandatory
        public string createdtime;
        public string modifiedtime;
        public string start_date;
        public string end_date;
        public string sc_related_to;
        public Tracking_unit tracking_unit;
        public string total_units;
        public string used_units;
        public string subject; //mandatory
        public string due_date;
        public string planned_duration;
        public string actual_duration;
        public Contract_status contract_status;
        public Contract_priority contract_priority;
        public Contract_type contract_type;
        public double progress;
        public string contract_no;
    }
}
