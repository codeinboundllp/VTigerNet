using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VtigerIntegration.Models
{
    /// <summary>
    /// VTiger-ProjectMilestone object
    /// </summary>
    public class VTigerProjectMilestone : VTigerEntity
    {
        public override VTigerEntity CreateNewInstance()
        {
            return (VTigerEntity)new VTigerProjectMilestone();
        }
        public override string RemoteTableName() { return "ProjectMilestone"; }
        public override VTigerType GetElementType() { return VTigerType.ProjectMilestone; }
        public VTigerProjectMilestone() { }
        public VTigerProjectMilestone(string projectmilestonename, string projectid, string assigned_user_id)
        {
            this.projectmilestonename = projectmilestonename;
            this.projectid = projectid;
            this.assigned_user_id = assigned_user_id;
        }
        public string projectmilestonename; //mandatory
        public string projectmilestonedate;
        public string projectid; //mandatory
        public Projectmilestonetype projectmilestonetype;
        public string assigned_user_id; //mandatory
        public string projectmilestone_no;
        public DateTime createdtime;
        public DateTime modifiedtime;
        public string description;
    }
}
