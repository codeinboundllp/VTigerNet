using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VtigerIntegration.Models
{
    /// <summary>
    /// VTiger-Project object
    /// </summary>
    public class VTigerProject : VTigerEntity
    {
        public override VTigerEntity CreateNewInstance()
        {
            return (VTigerEntity)new VTigerProject();
        }
        public override string RemoteTableName() { return "Project"; }
        public override VTigerType GetElementType() { return VTigerType.Project; }
        public VTigerProject() { }
        public VTigerProject(string projectname, string assigned_user_id)
        {
            this.projectname = projectname;
            this.assigned_user_id = assigned_user_id;
        }
        public string projectname; //mandatory
        public string startdate;
        public string targetenddate;
        public string actualenddate;
        public Projectstatus projectstatus;
        public Projecttype projecttype;
        public string linktoaccountscontacts;
        public string assigned_user_id; //mandatory
        public string project_no;
        public string targetbudget;
        public string projecturl;
        public Projectpriority projectpriority;
        public Progress progress;
        public DateTime createdtime;
        public DateTime modifiedtime;
        public string description;
    }
}
