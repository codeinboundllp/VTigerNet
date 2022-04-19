using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VtigerIntegration.Models
{
    /// <summary>
    /// VTiger-Assets object
    /// </summary>
    public class VTigerAsset : VTigerEntity
    {
        public override VTigerEntity CreateNewInstance()
        {
            return (VTigerEntity)new VTigerAsset();
        }
        public override string RemoteTableName() { return "Assets"; }
        public override VTigerType GetElementType() { return VTigerType.Assets; }
        public VTigerAsset() { }
        public VTigerAsset(string product, string serialnumber, string datesold,
            string dateinservice, Assetstatus assetstatus, string assetname,
            string account, string assigned_user_id)
        {
            this.product = product;
            this.serialnumber = serialnumber;
            this.datesold = datesold;
            this.dateinservice = dateinservice;
            this.assetstatus = assetstatus;
            this.assigned_user_id = assigned_user_id;
            this.assetname = assetname;
            this.account = account;
        }
        public string asset_no;
        public string product; //mandatory
        public string serialnumber; //mandatory
        public string datesold; //mandatory
        public string dateinservice; //mandatory
        public Assetstatus assetstatus; //mandatory
        public string tagnumber;
        public string invoiceid;
        public string shippingmethod;
        public string shippingtrackingnumber;
        public string assigned_user_id; //mandatory
        public string assetname; //mandatory
        public string account; //mandatory
        public DateTime createdtime;
        public DateTime modifiedtime;
        public string description;
    }
}
