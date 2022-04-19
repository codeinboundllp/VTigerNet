using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VtigerIntegration.Models
{
    /// <summary>
    /// VTiger-Users object
    /// </summary>
    public class VTigerUser : VTigerEntity
    {
        public override VTigerEntity CreateNewInstance()
        {
            return (VTigerEntity)new VTigerUser();
        }
        public override string RemoteTableName() { return "User"; }
        public override VTigerType GetElementType() { return VTigerType.Users; }
        public VTigerUser() { }
        public VTigerUser(string user_name, string user_password, string confirm_password, string last_name, string roleid, string email1)
        {
            this.user_name = user_name;
            this.user_password = user_password;
            this.confirm_password = confirm_password;
            this.last_name = last_name;
            this.roleid = roleid;
            this.email1 = email1;
        }
        public string user_name; //mandatory
        public bool is_admin;
        public string user_password; //mandatory
        public string confirm_password; //mandatory
        public string first_name;
        public string last_name; //mandatory
        public string roleid; //mandatory
        public string email1; //mandatory
        public string status;
        public Activity_view activity_view;
        public Lead_view lead_view;
        public string currency_id;
        public string hour_format;
        public string end_hour;
        public string start_hour;
        public string title;
        public string phone_work;
        public string department;
        public string phone_mobile;
        public string reports_to_id;
        public string phone_other;
        public string email2;
        public string phone_fax;
        public string yahoo_id;
        public string phone_home;
        public Date_format date_format;
        public string signature;
        public string description;
        public string address_street;
        public string address_city;
        public string address_state;
        public string address_postalcode;
        public string address_country;
        public string accesskey;
        public bool internal_mailer;
        public Reminder_interval reminder_interval;
        public string asterisk_extension;
        public bool use_asterisk;
    }
}
