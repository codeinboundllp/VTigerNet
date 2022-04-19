using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VtigerIntegration.Models
{
    /// <summary>
    /// VTiger-Accounts object
    /// </summary>
    public class VTigerAccount : VTigerEntity
    {
        public override VTigerEntity CreateNewInstance()
        {
            return (VTigerEntity)new VTigerAccount();
        }
        public override string RemoteTableName() { return "Accounts"; }
        public override VTigerType GetElementType() { return VTigerType.Accounts; }
        public VTigerAccount() { }
        public VTigerAccount(string accountname, string assigned_user_id)
        {
            this.accountname = accountname;
            this.assigned_user_id = assigned_user_id;
        }
        public string accountname; //mandatory
        public string account_no;
        public string phone;
        public string website;
        public string fax;
        public string tickersymbol;
        public string otherphone;
        public string account_id;
        public string email1;
        public int employees;
        public string email2;
        public string ownership;
        public Rating rating;
        public Industry industry;
        public string siccode;
        public Accounttype accounttype;
        public int annual_revenue;
        public bool emailoptout;
        public bool notify_owner;
        public string assigned_user_id; //mandatory
        public DateTime createdtime;
        public DateTime modifiedtime;
        public string bill_street;
        public string ship_street;
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
        public string modifiedby;
        public string isconvertedfromlead;
    }
}
