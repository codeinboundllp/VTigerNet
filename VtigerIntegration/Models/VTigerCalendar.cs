using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VtigerIntegration.Models
{
    /// <summary>
    /// VTiger-Calendar object
    /// </summary>
    public class VTigerCalendar : VTigerEntity
    {
        public override VTigerEntity CreateNewInstance()
        {
            return (VTigerEntity)new VTigerCalendar();
        }
        public override string RemoteTableName() { return "Calendar"; }
        public override VTigerType GetElementType() { return VTigerType.Calendar; }
        public VTigerCalendar() { }
        public VTigerCalendar(string subject, string assigned_user_id, string date_start, string time_start, string due_date, TaskStatus taskstatus)
        {
            this.subject = subject;
            this.assigned_user_id = assigned_user_id;
            this.date_start = date_start;
            this.due_date = due_date;
            this.taskstatus = taskstatus;
            this.time_start = time_start;
        }
        public string subject; //mandatory
        public string assigned_user_id; //mandatory
        public string date_start; //mandatory
        public string time_start;
        public string time_end;
        public string due_date; //mandatory
        public string parent_id;
        public string contact_id;
        public TaskStatus taskstatus; //mandatory
        public Eventstatus eventstatus;
        public Taskpriority taskpriority;
        public bool sendnotification;
        public DateTime createdtime;
        public DateTime modifiedtime;
        public Activitytype activitytype;
        public Visibility visibility;
        public string description;
        public string duration_hours;
        public Duration_minutes duration_minutes;
        public string location;
        public int reminder_time;
        public RecurringType recurringtype;
        public bool notime;
    }
}
