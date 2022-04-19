using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VtigerIntegration.Models
{
    /// <summary>
    /// VTiger-Events object
    /// </summary>
    public class VTigerEvent : VTigerEntity
    {
        public override VTigerEntity CreateNewInstance()
        {
            return (VTigerEntity)new VTigerEvent();
        }
        public override string RemoteTableName() { return "Events"; }
        public override VTigerType GetElementType() { return VTigerType.Events; }
        public VTigerEvent() { }
        public VTigerEvent(string subject, string date_start, string time_start, string due_date,
            string time_end, int duration_hours, Eventstatus eventstatus,
            Activitytype activitytype, string assigned_user_id)
        {
            this.subject = subject;
            this.assigned_user_id = assigned_user_id;
            this.date_start = date_start;
            this.time_start = time_start;
            this.due_date = due_date;
            this.time_end = time_end;
            this.duration_hours = duration_hours;
            this.eventstatus = eventstatus;
            this.activitytype = activitytype;
        }
        public string subject; //mandatory
        public string assigned_user_id; //mandatory
        public string date_start; //mandatory
        public string time_start; //mandatory
        public string due_date; //mandatory
        public string time_end; //mandatory
        public RecurringType recurringtype;
        public int duration_hours; //mandatory
        public Duration_minutes duration_minutes;
        public string parent_id;
        public Eventstatus eventstatus; //mandatory
        public bool sendnotification;
        public Activitytype activitytype; //mandatory
        public string location;
        public DateTime createdtime;
        public DateTime modifiedtime;
        public Taskpriority taskpriority;
        public bool notime;
        public Visibility visibility;
        public string description;
        public int reminder_time;
        public string contact_id;
    }
}
