using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VtigerIntegration.Models
{
    /// <summary>
    /// VTiger-Products object
    /// </summary>
    public class VTigerProduct : VTigerEntity
    {
        public override VTigerEntity CreateNewInstance()
        {
            return (VTigerEntity)new VTigerProduct();
        }
        public override string RemoteTableName() { return "Products"; }
        public override VTigerType GetElementType() { return VTigerType.Products; }
        public VTigerProduct() { }
        public VTigerProduct(string productname, string assigned_user_id)
        {
            this.productname = productname;
            this.assigned_user_id = assigned_user_id;
        }
        public string productname; //mandatory
        public string product_no;
        public string productcode;
        public bool discontinued;
        public string manufacturer;
        public string productcategory;
        public string sales_start_date;
        public string sales_end_date;
        public string start_date;
        public string expiry_date;
        public string website;
        public string vendor_id;
        public string mfr_part_no;
        public string vendor_part_no;
        public string serial_no;
        public string productsheet;
        public string glacct;
        public DateTime createdtime;
        public DateTime modifiedtime;
        public string modifiedby;
        public double unit_price;
        public double commissionrate;
        public string taxclass;
        public string usageunit;
        public double qty_per_unit;
        public double qtyinstock;
        public int reorderlevel;
        public string assigned_user_id; //mandatory
        public int qtyindemand;
        public string description;
        public string imagename;
        public string purchase_cost;
    }
}
