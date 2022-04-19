using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VtigerIntegration.Models
{
    /// <summary>
    /// VTiger-SalesOrder object
    /// </summary>
    public class VTigerSalesOrder : VTigerEntity
    {
        public override VTigerEntity CreateNewInstance()
        {
            return (VTigerEntity)new VTigerSalesOrder();
        }
        public override string RemoteTableName() { return "SalesOrder"; }
        public override VTigerType GetElementType() { return VTigerType.SalesOrder; }
        public VTigerSalesOrder() { }
        public VTigerSalesOrder(string subject, SoStatus sostatus, string bill_street,
            string ship_street, Invoicestatus invoicestatus, string account_id, string assigned_user_id)
        {
            this.subject = subject;
            this.sostatus = sostatus;
            this.account_id = account_id;
            this.assigned_user_id = assigned_user_id;
            this.bill_street = bill_street;
            this.ship_street = ship_street;
            this.invoicestatus = invoicestatus;
        }
        public string salesorder_no;
        public string subject; //mandatory
        public string potential_id;
        public string customerno;
        public string quote_id;
        public string vtiger_purchaseorder;
        public string contact_id;
        public string duedate;
        public string carrier;
        public string pending;
        public SoStatus sostatus; //mandatory
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
        public string account_id; //mandatory
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
        public bool enable_recurring;
        public Recurring_frequency recurring_frequency;
        public string start_period;
        public string end_period;
        public Payment_duration payment_duration;
        public Invoicestatus invoicestatus; //mandatory
        public string productid;
        public double quantity;
        public double listprice;
        public string comment;
        public string tax1;
        public string tax2;
        public string tax3;
        public double pre_tax_total;
    }
}
