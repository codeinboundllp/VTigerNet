using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VtigerIntegration.Models
{
    /// <summary>
    /// VTiger-Quotes object
    /// </summary>
    public class VTigerQuote : VTigerEntity
    {
        public override VTigerEntity CreateNewInstance()
        {
            return (VTigerEntity)new VTigerQuote();
        }
        public override string RemoteTableName() { return "Quotes"; }
        public override VTigerType GetElementType() { return VTigerType.Quotes; }
        public VTigerQuote() { }
        public VTigerQuote(string subject, Quotestage quotestage, string bill_street,
            string ship_street, string account_id, string assigned_user_id)
        {
            this.subject = subject;
            this.quotestage = quotestage;
            this.account_id = account_id;
            this.assigned_user_id = assigned_user_id;
            this.bill_street = bill_street;
            this.ship_street = ship_street;
        }
        public string quote_no;
        public string subject; //mandatory
        public string potential_id;
        public Quotestage quotestage; //mandatory
        public string validtill;
        public string contact_id;
        public string carrier;
        public double hdnSubTotal;
        public string shipping;
        public string assigned_user_id1;
        public double txtAdjustment;
        public double hdnGrandTotal;
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
