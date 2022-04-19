using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VtigerIntegration.Models
{
    /// <summary>
    /// VTiger-ProjectTask object
    /// </summary>
    public class VTigerProjectTask : VTigerEntity
    {
        public override VTigerEntity CreateNewInstance()
        {
            return (VTigerEntity)new VTigerProjectTask();
        }
        public override string RemoteTableName() { return "ProjectTask"; }
        public override VTigerType GetElementType() { return VTigerType.ProjectTask; }
        public VTigerProjectTask() { }
        public VTigerProjectTask(string projecttaskname, string projectid, string assigned_user_id)
        {
            this.projecttaskname = projecttaskname;
            this.projectid = projectid;
            this.assigned_user_id = assigned_user_id;
        }
        public string projecttaskname; //mandatory
        public Projecttasktype projecttasktype;
        public Projecttaskpriority projecttaskpriority;
        public string projectid; //mandatory
        public string assigned_user_id; //mandatory
        public int projecttasknumber;
        public string projecttask_no;
        public Projecttaskprogress projecttaskprogress;
        public string projecttaskhours;
        public string startdate;
        public string enddate;
        public DateTime createdtime;
        public DateTime modifiedtime;
        public string description;
    }
}
