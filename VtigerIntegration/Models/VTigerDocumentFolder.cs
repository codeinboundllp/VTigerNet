using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VtigerIntegration.Models
{
    /// <summary>
    /// VTiger-DocumentFolders object
    /// </summary>
    public class VTigerDocumentFolder : VTigerEntity
    {
        public override VTigerEntity CreateNewInstance()
        {
            return (VTigerEntity)new VTigerDocumentFolder();
        }
        public override string RemoteTableName() { return "DocumentFolders"; }
        public override VTigerType GetElementType() { return VTigerType.DocumentFolders; }
        public VTigerDocumentFolder() { }
        public VTigerDocumentFolder(string foldername, string createdby)
        {
            this.foldername = foldername;
            this.createdby = createdby;
        }
        public string foldername; //mandatory
        public string description;
        public string createdby; //mandatory
        public int sequence;
    }
}
