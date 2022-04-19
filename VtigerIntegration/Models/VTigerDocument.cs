using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VtigerIntegration.Models
{
    /// <summary>
    /// VTiger-Documents object
    /// </summary>
    public class VTigerDocument : VTigerEntity
    {
        public override VTigerEntity CreateNewInstance()
        {
            return (VTigerEntity)new VTigerDocument();
        }
        public override string RemoteTableName() { return "Documents"; }
        public override VTigerType GetElementType() { return VTigerType.Documents; }
        public VTigerDocument() { }
        public VTigerDocument(string notes_title, string assigned_user_id)
        {
            this.notes_title = notes_title;
            this.assigned_user_id = assigned_user_id;
        }
        public string notes_title; //mandatory
        public DateTime createdtime;
        public DateTime modifiedtime;
        public string filename;
        public string assigned_user_id; //mandatory
        public string notecontent;
        public string filetype;
        public int filesize;
        public string filelocationtype;
        public string fileversion;
        public bool filestatus;
        public int filedownloadcount;
        public string folderid;
        public string note_no;
    }
}
