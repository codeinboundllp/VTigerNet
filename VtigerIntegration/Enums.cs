using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VtigerIntegration
{
    #region enums

    public enum TaskStatus { Not_Started, In_Progress, Completed, Pending_Input, Deferred, Planned }
    public enum Eventstatus { Planned, Held, Not_Held }
    public enum Taskpriority { High, Medium, Low }
    public enum Activitytype { Call, Meeting }
    public enum Visibility { Private, Public }
    public enum Duration_minutes { _00, _15, _30, _45 }
    public enum RecurringType { None, Daily, Weekly, Monthly, Yearly }
    public enum Leadsource
    {
        None, Cold_Call, Existing_Customer, Self_Generated,
        Employee, Partner, Public_Relations, Direct_Mail,
        Conference, Trade_Show, Web_Site, Word_of_mouth, Other
    }
    public enum Industry
    {
        None, Apparel, Banking, Biotechnology, Chemicals,
        Communications, Construction, Consulting, Education,
        Electronics, Energy, Engineering, Entertainment,
        Environmental, Finance, Food_Beverage, Government,
        Healthcare, Hospitality, Insurance, Machinery,
        Manufacturing, Media, Not_For_Profit, Recreation,
        Retail, Shipping, Technology, Telecommunications,
        Transportation, Utilities, Other
    }
    public enum Leadstatus
    {
        None, Attempted_to_Contact, Cold, Contact_in_Future,
        Contacted, Hot, Junk_Lead, Lost_Lead, Not_Contacted,
        Pre_Qualified, Qualified, Warm
    }
    public enum Rating { None, Acquired, Active, Market_Failed, Project_Cancelled, Shutdown }
    public enum Accounttype { None, Analyst, Competitor, Customer, Integrator, Investor, Partner, Press, Prospect, Reseller, Other }
    public enum Opportunity_type { None, Existing_Business, New_Business }
    public enum Sales_stage { Prospecting, Qualification, Needs_Analysis, Value_Proposition, Id_Decision_Makers, Perception_Analysis, Proposal_Price_Quote, Negotiation_Review, Closed_Won, Closed_Lost }
    public enum Email_flag { SAVED, SENT }
    public enum Ticketpriorities { Low, Normal, High, Urgent }
    public enum Ticketseverities { Minor, Major, Feature, Critical }
    public enum Ticketstatus { Open, In_Progress, Wait_For_Response, Closed }
    public enum Ticketcategories { Big_Problem, Small_Problem, Other_Problem }
    public enum Faqcategories { General }
    public enum Faqstatus { Draft, Reviewed, Published, Obsolete }
    public enum Quotestage { Created, Delivered, Reviewed, Accepted, Rejected }
    public enum HdnTaxType { Individual, Group }
    public enum PoStatus { Created, Approved, Delivered, Cancelled, Received_Shipment }
    public enum SoStatus { Created, Approved, Delivered, Cancelled }
    public enum Recurring_frequency { None, Daily, Weekly, Monthly, Quarterly, Yearly }
    public enum Payment_duration { Net_30_days, Net_45_days, Net_60_days }
    public enum Invoicestatus { AutoCreated, Created, Approved, Sent, Credit_Invoice, Paid }
    public enum Campaigntype { None, Conference, Webinar, Trade_Show, Public_Relations, Partners, Referral_Program, Advertisement, Banner_Ads, Direct_Mail, Email, Telemarketing, Others }
    public enum Campaignstatus { None, Planning, Active, Inactive, Completed, Cancelled }
    public enum Expectedresponse { None, Excellent, Good, Average, Poor }
    public enum Activity_view { Today, This_Week, This_Month, This_Year }
    public enum Lead_view { Today, Last_2_Days, Last_Week }
    public enum Date_format { ddmmyyyy, mmddyyyy, yyyymmdd }
    public enum Reminder_interval { None, _1_Minute, _5_Minutes, _15_Minutes, _30_Minutes, _45_Minutes, _1_Hour, _1_Day }
    public enum Tracking_unit { None, Hours, Days, Incidents }
    public enum Contract_status { Undefined, In_Planning, In_Progress, On_Hold, Complete, Archived }
    public enum Contract_priority { Low, Normal, High }
    public enum Contract_type { Support, Services, Administrative }
    public enum Service_usageunit { Hours, Days, Incidents }
    public enum Servicecategory { None, Support, Installation, Migration, Customization, Training }
    public enum Assetstatus { In_Service, Outofservice }
    public enum Projectmilestonetype { none, administrative, operative, other }
    public enum Projecttasktype { none, administrative, operative, other }
    public enum Projecttaskpriority { none, low, normal, high }
    public enum Projecttaskprogress { none, _10_Percent, _20_Percent, _30_Percent, _40_Percent, _50_Percent, _60_Percent, _70_Percent, _80_Percent, _90_Percent, _100_Percent }
    public enum Projectstatus { none, Prospecting, Initiated, In_Progress, waiting_for_feedback, On_Hold, Completed, Delivered, Archived }
    public enum Projecttype { none, administrative, operative, other }
    public enum Projectpriority { none, low, normal, high }
    public enum Progress { none, _10_Percent, _20_Percent, _30_Percent, _40_Percent, _50_Percent, _60_Percent, _70_Percent, _80_Percent, _90_Percent, _100_Percent }

    public enum VTigerType
    {
        Undefined = 0,
        Calendar = 1, Leads = 2, Accounts = 3,
        Contacts = 4, Potentials = 5, Products = 6,
        Documents = 7, Emails = 8, HelpDesk = 9,
        Faq = 10, Vendors = 11, PriceBooks = 12,
        Quotes = 13, PurchaseOrder = 14, SalesOrder = 15,
        Invoice = 16, Campaigns = 17, Events = 18,
        Users = 19, PBXManager = 20, ServiceContracts = 21,
        Services = 22, Assets = 23, ModComments = 24,
        ProjectMilestone = 25, ProjectTask = 26,
        Project = 27, SMSNotifier = 28, Groups = 29,
        Currency = 30, DocumentFolders = 31
    }
    #endregion

}
