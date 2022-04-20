using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VtigerIntegration.Models
{
    /// <summary>
    /// VTiger-Leads object
    /// </summary>
    public class VTigerLead : VTigerEntity
    {
        public override VTigerEntity CreateNewInstance()
        {
            return (VTigerEntity)new VTigerLead();
        }
        public override string RemoteTableName() { return "Leads"; }
        public override VTigerType GetElementType() { return VTigerType.Leads; }
        public VTigerLead() { }
        public VTigerLead(string lastname, string company, string assigned_user_id)
        {
            this.lastname = lastname;
            this.company = company;
            this.assigned_user_id = assigned_user_id;
        }
       
        public string salutationtype;
        public string firstname;
        public string lead_no;
        public string phone;
        [Required]
        public string lastname; //mandatory
        public string mobile;
        [Required]
        public string company; //mandatory
        public string fax;
        public string designation;
        public string email;
        public Leadsource leadsource;
        public string website;
        public Industry? industry = Industry.Other;
        public Leadstatus? leadstatus = Leadstatus.Hot;
        public double annualrevenue;
        public Rating? rating = Rating.None;
        public int noofemployees;
        [Required]
        public string assigned_user_id; //mandatory
        public string yahooid;
        public DateTime createdtime;
        public DateTime modifiedtime;
        public string lane;
        public string code;
        public string city;
        public string country;
        public string state;
        public string pobox;
        public string description;
    }
}
