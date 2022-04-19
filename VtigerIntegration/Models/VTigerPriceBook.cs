using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VtigerIntegration.Models
{
    /// <summary>
    /// VTiger-PriceBooks object
    /// </summary>
    public class VTigerPriceBook : VTigerEntity
    {
        public override VTigerEntity CreateNewInstance()
        {
            return (VTigerEntity)new VTigerPriceBook();
        }
        public override string RemoteTableName() { return "PriceBooks"; }
        public override VTigerType GetElementType() { return VTigerType.PriceBooks; }
        public VTigerPriceBook() { }
        public VTigerPriceBook(string bookname, string currency_id)
        {
            this.bookname = bookname;
            this.currency_id = currency_id;
        }
        public string bookname; //mandatory
        public string pricebook_no;
        public bool active;
        public DateTime createdtime;
        public DateTime modifiedtime;
        public string currency_id; //mandatory
        public string description;
    }
}
