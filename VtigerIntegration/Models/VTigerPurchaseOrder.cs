using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VtigerIntegration.Models
{
    /// <summary>
    /// VTiger-PurchaseOrder object
    /// </summary>
    public class VTigerPurchaseOrder : VTigerEntity
    {
        public override VTigerEntity CreateNewInstance()
        {
            return (VTigerEntity)new VTigerPurchaseOrder();
        }
        public override string RemoteTableName() { return "PurchaseOrder"; }
        public override VTigerType GetElementType() { return VTigerType.PurchaseOrder; }
        public VTigerPurchaseOrder() { }
        public VTigerPurchaseOrder(string subject, string vendor_id, PoStatus postatus,
            string bill_street, string ship_street, string assigned_user_id)
        {
            this.subject = subject;
            this.vendor_id = vendor_id;
            this.postatus = postatus;
            this.assigned_user_id = assigned_user_id;
            this.bill_street = bill_street;
            this.ship_street = ship_street;
        }
        public string purchaseorder_no;
        public string subject; //mandatory
        public string vendor_id; //mandatory
        public string requisition_no;
        public string tracking_no;
        public string contact_id;
        public string duedate;
        public string carrier;
        public double txtAdjustment;
        public double salescommission;
        public double exciseduty;
        public double hdnGrandTotal;
        public double hdnSubTotal;
        public HdnTaxType hdnTaxType;
        public double discount_percent;
        public double discount_amount;
        public double hdnDiscountPercent;
        public double hdnDiscountAmount;
        public double hdnS_H_Amount;
        public double hdnS_H_Percent;
        public PoStatus postatus; //mandatory
        public string assigned_user_id; //mandatory
        public DateTime createdtime;
        public string modifiedby;
        public DateTime modifiedtime;
        public string currency_id;
        public double conversion_rate;
        public string bill_street; //mandatory
        public string ship_street; //mandatory
        public string bill_city;
        public string ship_city;
        public string bill_state;
        public string ship_state;
        public string bill_code;
        public string ship_code;
        public string bill_country;
        public string ship_country;
        public string bill_pobox;
        public string ship_pobox;
        public string description;
        public string terms_conditions;
        public string productid;
        public double quantity;
        public double listprice;
        public string comment;
        public string tax1;
        public string tax2;
        public string tax3;
        public double pre_tax_total;
        public double paid;
        public double balance;
    }
}
