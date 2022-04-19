using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VtigerIntegration.Models
{
    /// <summary>
    /// VTiger-Services object
    /// </summary>
    public class VTigerService : VTigerEntity
    {
        public override VTigerEntity CreateNewInstance()
        {
            return (VTigerEntity)new VTigerService();
        }
        public override string RemoteTableName() { return "Services"; }
        public override VTigerType GetElementType() { return VTigerType.Services; }
        public VTigerService() { }
        public VTigerService(string servicename)
        {
            this.servicename = servicename;
        }
        public string servicename; //mandatory
        public string service_no;
        public bool discontinued;
        public string sales_start_date;
        public string sales_end_date;
        public string start_date;
        public string expiry_date;
        public string website;
        public DateTime createdtime;
        public DateTime modifiedtime;
        public Service_usageunit service_usageunit;
        public double qty_per_unit;
        public string assigned_user_id;
        public Servicecategory servicecategory;
        public double unit_price;
        public string taxclass;
        public double commissionrate;
        public string description;
    }
}
