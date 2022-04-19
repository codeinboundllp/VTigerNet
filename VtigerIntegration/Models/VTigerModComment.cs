using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VtigerIntegration.Models
{
    /// <summary>
    /// VTiger-ModComments object
    /// </summary>
    public class VTigerModComment : VTigerEntity
    {
        public override VTigerEntity CreateNewInstance()
        {
            return (VTigerEntity)new VTigerModComment();
        }
        public override string RemoteTableName() { return "ModComments"; }
        public override VTigerType GetElementType() { return VTigerType.ModComments; }
        public VTigerModComment() { }
        public VTigerModComment(string commentcontent, string assigned_user_id, string related_to)
        {
            this.commentcontent = commentcontent;
            this.assigned_user_id = assigned_user_id;
            this.related_to = related_to;
        }
        public string commentcontent; //mandatory
        public string assigned_user_id; //mandatory
        public DateTime createdtime;
        public DateTime modifiedtime;
        public string related_to; //mandatory
        public string creator;
        public string parent_comments;
    }
}
