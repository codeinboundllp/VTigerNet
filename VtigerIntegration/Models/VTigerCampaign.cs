using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VtigerIntegration.Models
{
    /// <summary>
    /// VTiger-Campaigns object
    /// </summary>
    public class VTigerCampaign : VTigerEntity
    {
        public override VTigerEntity CreateNewInstance()
        {
            return (VTigerEntity)new VTigerCampaign();
        }
        public override string RemoteTableName() { return "Campaigns"; }
        public override VTigerType GetElementType() { return VTigerType.Campaigns; }
        public VTigerCampaign() { }
        public VTigerCampaign(string campaignname, DateTime closingDate, string assigned_user_id)
        {
            this.campaignname = campaignname;
            this.closingdate = VTiger.DateTimeToVtDate(closingDate);
            this.assigned_user_id = assigned_user_id;
        }
        public string campaignname; //mandatory
        public string campaign_no;
        public Campaigntype campaigntype;
        public string product_id;
        public Campaignstatus campaignstatus;
        public string closingdate; //mandatory
        public string assigned_user_id; //mandatory
        public double numsent;
        public string sponsor;
        public string targetaudience;
        public int targetsize;
        public DateTime createdtime;
        public DateTime modifiedtime;
        public Expectedresponse expectedresponse;
        public double expectedrevenue;
        public double budgetcost;
        public double actualcost;
        public int expectedresponsecount;
        public int expectedsalescount;
        public double expectedroi;
        public int actualresponsecount;
        public int actualsalescount;
        public double actualroi;
        public string description;
    }
}
