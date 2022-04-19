using Jayrock.Json.Conversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VtigerIntegration.Models
{
    /// <summary>
    /// VTiger-Emails object
    /// </summary>
    public class VTigerEmail : VTigerEntity
    {
        public override VTigerEntity CreateNewInstance()
        {
            return (VTigerEntity)new VTigerEmail();
        }
        public override string RemoteTableName() { return "Emails"; }
        public override VTigerType GetElementType() { return VTigerType.Emails; }
        public VTigerEmail() { }
        public VTigerEmail(string subject, DateTime date_start, string from_email, string[] saved_toid, string assigned_user_id)
        {
            this.date_start = VTiger.DateTimeToVtDate(date_start);
            this.assigned_user_id = assigned_user_id;
            this.subject = subject;
            this.from_email = from_email;
            //this.saved_toid = JsonConvert.ExportToString(saved_toid);
            this.saved_toid.Adresses = saved_toid;
            this.activitytype = "Emails";
        }
        public string date_start; //mandatory
        [JsonExcludeExportAttribute]
        public string parent_type; //Read-only
        public string activitytype;
        public string assigned_user_id; //mandatory
        public string subject; //mandatory
        public string filename;
        public string description;
        public string time_start;
        public DateTime createdtime;
        public DateTime modifiedtime;
        public string access_count;
        public string from_email; //mandatory
        public EmailAdresses saved_toid; //mandatory
        public EmailAdresses ccmail;
        public EmailAdresses bccmail;
        public string parent_id;
        public Email_flag email_flag;
    }
}
