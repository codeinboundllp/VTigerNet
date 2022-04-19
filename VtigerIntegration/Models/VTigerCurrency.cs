using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VtigerIntegration.Models
{
    /// <summary>
    /// VTiger-Currency object
    /// </summary>
    public class VTigerCurrency : VTigerEntity
    {
        public override VTigerEntity CreateNewInstance()
        {
            return (VTigerEntity)new VTigerCurrency();
        }
        public override string RemoteTableName() { return "Currency"; }
        public override VTigerType GetElementType() { return VTigerType.Currency; }
        public VTigerCurrency() { }
        public VTigerCurrency(string defaultid, int deleted)
        {
            this.defaultid = defaultid;
            this.deleted = deleted;
        }
        public string currency_name;
        public string currency_code;
        public string currency_symbol;
        public double conversion_rate;
        public string currency_status;
        public string defaultid; //mandatory
        public int deleted; //mandatory
    }
}
