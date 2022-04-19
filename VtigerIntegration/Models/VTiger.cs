using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VtigerIntegration.Models;

namespace VtigerIntegration
{
    public partial class VTiger
    {
        public static Type[] VTigerTypeClasses =
        {
            typeof(VTigerEntity),
            typeof(VTigerCalendar), typeof(VTigerLead), typeof(VTigerAccount),
            typeof(VTigerContact), typeof(VTigerPotential), typeof(VTigerProduct),
            typeof(VTigerDocument), typeof(VTigerEmail), typeof(VTigerHelpDesk),
            typeof(VTigerFaq), typeof(VTigerVendor), typeof(VTigerPriceBook),
            typeof(VTigerQuote), typeof(VTigerPurchaseOrder), typeof(VTigerSalesOrder),
            typeof(VTigerInvoice), typeof(VTigerCampaign), typeof(VTigerEvent),
            typeof(VTigerUser), typeof(VTigerPBXManager), typeof(VTigerServiceContract),
            typeof(VTigerService), typeof(VTigerAsset), typeof(VTigerModComment),
            typeof(VTigerProjectMilestone), typeof(VTigerProjectTask),
            typeof(VTigerProject), typeof(VTigerSMSNotifier), typeof(VTigerGroup),
            typeof(VTigerCurrency), typeof(VTigerDocumentFolder)
        };
    }
    public struct EmailAdresses
    {
        public string[] Adresses;
    }
}
