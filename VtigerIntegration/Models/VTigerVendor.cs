using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VtigerIntegration.Models
{
    /// <summary>
    /// VTiger-Vendors object
    /// </summary>
    public class VTigerVendor : VTigerEntity
    {
        public override VTigerEntity CreateNewInstance()
        {
            return (VTigerEntity)new VTigerVendor();
        }
        public override string RemoteTableName() { return "Vendors"; }
        public override VTigerType GetElementType() { return VTigerType.Vendors; }
        public VTigerVendor() { }
        public VTigerVendor(string vendorname, string assigned_user_id)
        {
            this.vendorname = vendorname;
            this.assigned_user_id = assigned_user_id;
        }
        public string vendorname; //mandatory
        public string vendor_no;
        public string phone;
        public string email;
        public string website;
        public string glacct;
        public string category;
        public DateTime createdtime;
        public DateTime modifiedtime;
        public string modifiedby;
        public string street;
        public string pobox;
        public string city;
        public string state;
        public string postalcode;
        public string country;
        public string description;
        public string assigned_user_id;
    }
}
