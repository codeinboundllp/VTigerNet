using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VtigerIntegration.Models
{
    /// <summary>
    /// VTiger-Faq object
    /// </summary>
    public class VTigerFaq : VTigerEntity
    {
        public override VTigerEntity CreateNewInstance()
        {
            return (VTigerEntity)new VTigerFaq();
        }
        public override string RemoteTableName() { return "Faq"; }
        public override VTigerType GetElementType() { return VTigerType.Faq; }
        public VTigerFaq() { }
        public VTigerFaq(Faqstatus faqstatus, string question, string faq_answer)
        {
            this.faqstatus = faqstatus;
            this.question = question;
            this.faq_answer = faq_answer;
        }
        public string product_id;
        public string faq_no;
        public Faqcategories faqcategories;
        public Faqstatus faqstatus; //mandatory
        public string question; //mandatory
        public string faq_answer; //mandatory
        public DateTime createdtime;
        public DateTime modifiedtime;
    }
}
