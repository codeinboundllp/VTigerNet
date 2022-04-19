using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VtigerIntegration.Models
{
    /// <summary>
    /// VTiger-Contacts object
    /// </summary>
    public class VTigerContact : VTigerEntity
    {
        public override VTigerEntity CreateNewInstance()
        {
            return (VTigerEntity)new VTigerContact();
        }
        public override string RemoteTableName() { return "Contacts"; }
        public override VTigerType GetElementType() { return VTigerType.Contacts; }
        public VTigerContact() { }
        public VTigerContact(string lastname, string assigned_user_id)
        {
            this.lastname = lastname;
            this.assigned_user_id = assigned_user_id;
        }
        public string salutationtype;
        public string firstname;
        public string contact_no;
        public string phone;
        public string lastname; //mandatory
        public string mobile;
        public string account_id;
        public string homephone;
        public Leadsource leadsource;
        public string otherphone;
        public string title;
        public string fax;
        public string department;
        public string birthday;
        public string email;
        public string contact_id;
        public string assistant;
        public string yahooid;
        public string assistantphone;
        public bool donotcall;
        public bool emailoptout;
        public string assigned_user_id; //mandatory
        public bool reference;
        public bool notify_owner;
        public DateTime createdtime;
        public DateTime modifiedtime;
        public bool portal;
        public string support_start_date;
        public string support_end_date;
        public string mailingstreet;
        public string otherstreet;
        public string mailingcity;
        public string othercity;
        public string mailingstate;
        public string otherstate;
        public string mailingzip;
        public string otherzip;
        public string mailingcountry;
        public string othercountry;
        public string mailingpobox;
        public string otherpobox;
        public string description;
        public string secondaryemail;
        public string modifiedby;
        public string imagename;
        public string isconvertedfromlead;
    }
}
