using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VtigerIntegration.Models
{
    /// <summary>
    /// VTiger-Potentials object
    /// </summary>
    public class VTigerPotential : VTigerEntity
    {
        public override VTigerEntity CreateNewInstance()
        {
            return (VTigerEntity)new VTigerPotential();
        }
        public override string RemoteTableName() { return "Potentials"; }
        public override VTigerType GetElementType() { return VTigerType.Potentials; }
        public VTigerPotential() { }
        public VTigerPotential(string potentialname, string related_to, string closingdate, Sales_stage sales_stage, string assigned_user_id)
        {
            this.potentialname = potentialname;
            this.related_to = related_to;
            this.closingdate = closingdate;
            this.sales_stage = sales_stage;
            this.assigned_user_id = assigned_user_id;
        }
        public string potentialname; //mandatory
        public string potential_no;
        public double amount;
        public string related_to; //mandatory
        public string closingdate; //mandatory
        public Opportunity_type opportunity_type;
        public string nextstep;
        public Leadsource leadsource;
        public Sales_stage sales_stage; //mandatory
        public string assigned_user_id; //mandatory
        public double probability;
        public string campaignid;
        public DateTime createdtime;
        public DateTime modifiedtime;
        public string description;
    }
}
