using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VtigerIntegration.Models
{
    /// <summary>
    /// VTiger-HelpDesk object
    /// </summary>
    public class VTigerHelpDesk : VTigerEntity
    {
        public override VTigerEntity CreateNewInstance()
        {
            return (VTigerEntity)new VTigerHelpDesk();
        }
        public override string RemoteTableName() { return "HelpDesk"; }
        public override VTigerType GetElementType() { return VTigerType.HelpDesk; }
        public VTigerHelpDesk() { }
        public VTigerHelpDesk(string assigned_user_id, Ticketstatus ticketstatus, string ticket_title)
        {
            this.assigned_user_id = assigned_user_id;
            this.ticketstatus = ticketstatus;
            this.ticket_title = ticket_title;
        }
        public string ticket_no;
        public string assigned_user_id; //mandatory
        public string parent_id;
        public Ticketpriorities ticketpriorities;
        public string product_id;
        public Ticketseverities ticketseverities;
        public Ticketstatus ticketstatus; //mandatory
        public Ticketcategories ticketcategories;
        public string update_log;
        public int hours;
        public int days;
        public DateTime createdtime;
        public DateTime modifiedtime;
        public string ticket_title; //mandatory
        public string description;
        public string solution;
    }
}
