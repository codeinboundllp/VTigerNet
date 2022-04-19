using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VtigerIntegration.Models
{
    /// <summary>
    /// VTiger-Invoice object
    /// </summary>
    public class VTigerInvoice : VTigerEntity
    {
        public override VTigerEntity CreateNewInstance()
        {
            return (VTigerEntity)new VTigerInvoice();
        }
        public override string RemoteTableName() { return "Invoice"; }
        public override VTigerType GetElementType() { return VTigerType.Invoice; }
        public VTigerInvoice() { }
        public VTigerInvoice(string subject, string bill_street, string ship_street,
            string account_id, string assigned_user_id)
        {
            this.subject = subject;
            this.account_id = account_id;
            this.assigned_user_id = assigned_user_id;
            this.bill_street = bill_street;
            this.ship_street = ship_street;
        }
        public string subject; //mandatory
        public string salesorder_id;
        public string customerno;
        public string contact_id;
        public string invoicedate;
        public string duedate;
        public string vtiger_purchaseorder;
        public double txtAdjustment;
        public double salescommission;
        public double exciseduty;
        public double hdnSubTotal;
        public double hdnGrandTotal;
        public double hdnS_H_Amount;
        public double hdnS_H_Percent;
        public HdnTaxType hdnTaxType;
        public double hdnDiscountPercent;
        public double hdnDiscountAmount;
        public double discount_percent;
        public double discount_amount;
        public string account_id; //mandatory
        public Invoicestatus invoicestatus;
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
        public string invoice_no;
        public string productid;
        public double quantity;
        public double listprice;
        public string comment;
        public string tax1;
        public string tax2;
        public string tax3;
        public double pre_tax_total;
        public double received;
        public double balance;
    }
}
