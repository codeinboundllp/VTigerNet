using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VtigerIntegration
{
    public class VTigerEnumValues
    {
        public static string[] TaskstatusValues = { "Not Started", "In Progress", "Completed", "Pending Input", "Deferred", "Planned" };
        public static string[] EventstatusValues = { "Planned", "Held", "Not Held" };
        public static string[] TaskpriorityValues = { "High", "Medium", "Low" };
        public static string[] ActivitytypeValues = { "Call", "Meeting" };
        public static string[] VisibilityValues = { "Private", "Public" };
        public static string[] Duration_minutesValues = { "00", "15", "30", "45" };
        public static string[] RecurringtypeValues = { "--None--", "Daily", "Weekly", "Monthly", "Yearly" };
        public static string[] LeadsourceValues = { "--None--", "Cold Call", "Existing Customer", "Self Generated", "Employee", "Partner", "Public Relations", "Direct Mail", "Conference", "Trade Show", "Web Site", "Word of mouth", "Other" };
        public static string[] IndustryValues = { "--None--", "Apparel", "Banking", "Biotechnology", "Chemicals", "Communications", "Construction", "Consulting", "Education", "Electronics", "Energy", "Engineering", "Entertainment", "Environmental", "Finance", "Food & Beverage", "Government", "Healthcare", "Hospitality", "Insurance", "Machinery", "Manufacturing", "Media", "Not For Profit", "Recreation", "Retail", "Shipping", "Technology", "Telecommunications", "Transportation", "Utilities", "Other" };
        public static string[] LeadstatusValues = { "--None--", "Attempted to Contact", "Cold", "Contact in Future", "Contacted", "Hot", "Junk Lead", "Lost Lead", "Not Contacted", "Pre Qualified", "Qualified", "Warm" };
        public static string[] RatingValues = { "--None--", "Acquired", "Active", "Market Failed", "Project Cancelled", "Shutdown" };
        public static string[] AccounttypeValues = { "--None--", "Analyst", "Competitor", "Customer", "Integrator", "Investor", "Partner", "Press", "Prospect", "Reseller", "Other" };
        public static string[] Opportunity_typeValues = { "--None--", "Existing Business", "New Business" };
        public static string[] Sales_stageValues = { "Prospecting", "Qualification", "Needs Analysis", "Value Proposition", "Id. Decision Makers", "Perception Analysis", "Proposal/Price Quote", "Negotiation/Review", "Closed Won", "Closed Lost" };
        public static string[] Email_flagValues = { "SAVED", "SENT" };
        public static string[] TicketprioritiesValues = { "Low", "Normal", "High", "Urgent" };
        public static string[] TicketseveritiesValues = { "Minor", "Major", "Feature", "Critical" };
        public static string[] TicketstatusValues = { "Open", "In Progress", "Wait For Response", "Closed" };
        public static string[] TicketcategoriesValues = { "Big Problem", "Small Problem", "Other Problem" };
        public static string[] FaqcategoriesValues = { "General" };
        public static string[] FaqstatusValues = { "Draft", "Reviewed", "Published", "Obsolete" };
        public static string[] QuotestageValues = { "Created", "Delivered", "Reviewed", "Accepted", "Rejected" };
        public static string[] HdnTaxTypeValues = { "individual", "group" };
        public static string[] PostatusValues = { "Created", "Approved", "Delivered", "Cancelled", "Received Shipment" };
        public static string[] SostatusValues = { "Created", "Approved", "Delivered", "Cancelled" };
        public static string[] Recurring_frequencyValues = { "--None--", "Daily", "Weekly", "Monthly", "Quarterly", "Yearly" };
        public static string[] Payment_durationValues = { "Net 30 days", "Net 45 days", "Net 60 days" };
        public static string[] InvoicestatusValues = { "AutoCreated", "Created", "Approved", "Sent", "Credit Invoice", "Paid" };
        public static string[] CampaigntypeValues = { "--None--", "Conference", "Webinar", "Trade Show", "Public Relations", "Partners", "Referral Program", "Advertisement", "Banner Ads", "Direct Mail", "Email", "Telemarketing", "Others" };
        public static string[] CampaignstatusValues = { "--None--", "Planning", "Active", "Inactive", "Completed", "Cancelled" };
        public static string[] ExpectedresponseValues = { "--None--", "Excellent", "Good", "Average", "Poor" };
        public static string[] Activity_viewValues = { "Today", "This Week", "This Month", "This Year" };
        public static string[] Lead_viewValues = { "Today", "Last 2 Days", "Last Week" };
        public static string[] Date_formatValues = { "dd-mm-yyyy", "mm-dd-yyyy", "yyyy-mm-dd" };
        public static string[] Reminder_intervalValues = { "None", "1 Minute", "5 Minutes", "15 Minutes", "30 Minutes", "45 Minutes", "1 Hour", "1 Day" };
        public static string[] Tracking_unitValues = { "None", "Hours", "Days", "Incidents" };
        public static string[] Contract_statusValues = { "Undefined", "In Planning", "In Progress", "On Hold", "Complete", "Archived" };
        public static string[] Contract_priorityValues = { "Low", "Normal", "High" };
        public static string[] Contract_typeValues = { "Support", "Services", "Administrative" };
        public static string[] Service_usageunitValues = { "Hours", "Days", "Incidents" };
        public static string[] ServicecategoryValues = { "--None--", "Support", "Installation", "Migration", "Customization", "Training" };
        public static string[] AssetstatusValues = { "In Service", "Out-of-service" };
        public static string[] ProjectmilestonetypeValues = { "--none--", "administrative", "operative", "other" };
        public static string[] ProjecttasktypeValues = { "--none--", "administrative", "operative", "other" };
        public static string[] ProjecttaskpriorityValues = { "--none--", "low", "normal", "high" };
        public static string[] ProjecttaskprogressValues = { "--none--", "10%", "20%", "30%", "40%", "50%", "60%", "70%", "80%", "90%", "100%" };
        public static string[] ProjectstatusValues = { "--none--", "prospecting", "initiated", "in progress", "waiting for feedback", "on hold", "completed", "delivered", "archived" };
        public static string[] ProjecttypeValues = { "--none--", "administrative", "operative", "other" };
        public static string[] ProjectpriorityValues = { "--none--", "low", "normal", "high" };
        public static string[] ProgressValues = { "--none--", "10%", "20%", "30%", "40%", "50%", "60%", "70%", "80%", "90%", "100%" };
    }
}
