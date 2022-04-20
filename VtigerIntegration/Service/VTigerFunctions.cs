using Jayrock.Json;
using Jayrock.Json.Conversion;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using VtigerIntegration.Interfaces;
using VtigerIntegration.Models;
using VtigerIntegration.Utils;

namespace VtigerIntegration
{
    /// <summary>
    /// Client for the VTiger webservice API
    /// </summary>
    public partial class VTiger
    {
        private string serviceUrl;
        private string baseUrl;
        private readonly VTigerConfiguration _vconfig;
        /// <summary>
        /// The URL of the VTiger-CRM (e.g. http://demo.vtiger.de/)
        /// </summary>
        public string ServiceUrl
        {
            get { return serviceUrl; }
            set
            {
                if (value[value.Length - 1] != '/')
                    value += "/";
                serviceUrl = value;
                baseUrl = value + "webservice.php?operation=";
            }
        }

        private string webserviceVersion;
        /// <summary>
        /// The version of the server's VTiger webservice to which the current user logged in
        /// </summary>
        public Version WebserviceVersion
        {
            get { return new System.Version(webserviceVersion); }
        }

        private Dictionary<string, TitleFields> remoteTables;
        /// <summary>
        /// Available tables at VTiger instance
        /// </summary>
        /// <remarks>
        /// Table list is only available when logged on
        /// </remarks>
        public Dictionary<string, TitleFields> RemoteTables
        {
            get
            {
                if (remoteTables != null)
                    return remoteTables;
                else
                    return new System.Collections.Generic.Dictionary<string, TitleFields>();
            }
        }

        private string vtigerVersion;
        /// <summary>
        /// The version of the server's VTiger software to which the current user logged in
        /// </summary>
        public Version VTigerVersion
        {
            get { return new System.Version(vtigerVersion); }
        }
        private string userID;
        /// <summary>
        /// The ID of the current VTiger user which is logged in
        /// </summary>
        public string UserID
        {
            get { return userID; }
        }

        private string sessionName;

        /// <summary>
        /// The session identifier which is used for authentication
        /// </summary>
        /// <remarks>
        /// This value is automatically set by login
        /// </remarks>
        /// <seealso cref="VTigerApi.VTiger.Login"/>
        public string SessionName
        {
            get { return sessionName; }
        }

        private ImportContext jsonImporter;
        private ExportContext jsonExporter;

        public VTiger(VTigerConfiguration config)
        {
            ServiceUrl = config.Url;
            _vconfig = config;
        }

        /// <summary>
        /// Ignore errors and continue when connecting to a remote server with an invalid certificate
        /// </summary>
        public static bool IgnoreSslCertificateErrors { get; set; }

        #region Basic Access

        /// <summary>
        /// The typical title fields for a table row
        /// </summary>
        public class TitleFields
        {
            public string DefaultTitleField1;
            public string DefaultTitleField2;
            public VTigerType ElementType;
            public TitleFields()
            {
            }
            public TitleFields(string nameOfTitleField, VTigerType elementType)
            {
                DefaultTitleField1 = nameOfTitleField;
                DefaultTitleField2 = null;
                this.ElementType = elementType;
            }
            public TitleFields(string nameOfTitleField1, string nameOfTitleField2, VTigerType elementType)
            {
                DefaultTitleField1 = nameOfTitleField1;
                DefaultTitleField2 = nameOfTitleField2;
                this.ElementType = elementType;
            }
        }

        //====================================================================
        #region Login & Info

        private async Task<VTigerToken> GetChallenge(string username)
        {
            return await VTigerGetJson<VTigerToken>("getchallenge",
                String.Format("username={0}", username), false);
        }

        /// <summary>
        /// Login to the VTiger API.
        /// Neccessary to access any data.
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="accessKey">Personal authentication-key provided on the VTiger website</param>
        public async Task Login(string username, string accessKey)
        {
            string token = (await GetChallenge(username)).token;

            string key = GetMD5Hash(token + accessKey);

            VTigerLogin loginResult = await VTigerGetJson<VTigerLogin>("login",
                String.Format("username={0}&accessKey={1}", username, key), true);

            sessionName = loginResult.sessionName;
            vtigerVersion = loginResult.vtigerVersion;

            switch (vtigerVersion)
            {
                default:
                    {
                        System.Collections.Generic.Dictionary<string, TitleFields> nameFields = new System.Collections.Generic.Dictionary<string, TitleFields>();
                        nameFields.Add("Calendar", new TitleFields("subject", null, VTigerType.Calendar));
                        nameFields.Add("Leads", new TitleFields("firstname", "lastname", VTigerType.Leads));
                        nameFields.Add("Accounts", new TitleFields("accountname", null, VTigerType.Accounts));
                        nameFields.Add("Contacts", new TitleFields("firstname", "lastname", VTigerType.Contacts));
                        nameFields.Add("Potentials", new TitleFields("potentialname", null, VTigerType.Potentials));
                        nameFields.Add("Products", new TitleFields("productname", null, VTigerType.Products));
                        nameFields.Add("Documents", new TitleFields("notes_title", null, VTigerType.Documents));
                        nameFields.Add("Emails", new TitleFields("assigned_user_id", "subject", VTigerType.Emails));
                        nameFields.Add("HelpDesk", new TitleFields("ticket_title", null, VTigerType.HelpDesk));
                        nameFields.Add("Faq", new TitleFields("question", null, VTigerType.Faq));
                        nameFields.Add("Vendors", new TitleFields("vendorname", null, VTigerType.Vendors));
                        nameFields.Add("PriceBooks", new TitleFields("bookname", null, VTigerType.PriceBooks));
                        nameFields.Add("Quotes", new TitleFields("subject", null, VTigerType.Quotes));
                        nameFields.Add("PurchaseOrder", new TitleFields("subject", null, VTigerType.PurchaseOrder));
                        nameFields.Add("SalesOrder", new TitleFields("subject", null, VTigerType.SalesOrder));
                        nameFields.Add("Invoice", new TitleFields("subject", null, VTigerType.Invoice));
                        nameFields.Add("Campaigns", new TitleFields("campaignname", null, VTigerType.Campaigns));
                        nameFields.Add("Events", new TitleFields("subject", null, VTigerType.Events));
                        nameFields.Add("Users", new TitleFields("user_name", null, VTigerType.Users));
                        nameFields.Add("PBXManager", new TitleFields(null, null, VTigerType.PBXManager));
                        nameFields.Add("ServiceContracts", new TitleFields("subject", null, VTigerType.ServiceContracts));
                        nameFields.Add("Services", new TitleFields("servicename", null, VTigerType.Services));
                        nameFields.Add("Assets", new TitleFields("product", "assetname", VTigerType.Assets));
                        nameFields.Add("ModComments", new TitleFields("creator", "related_to", VTigerType.ModComments));
                        nameFields.Add("ProjectMilestone", new TitleFields("projectmilestonename", null, VTigerType.ProjectMilestone));
                        nameFields.Add("ProjectTask", new TitleFields("projecttaskname", null, VTigerType.ProjectTask));
                        nameFields.Add("Project", new TitleFields("projectname", null, VTigerType.Project));
                        nameFields.Add("SMSNotifier", new TitleFields(null, null, VTigerType.SMSNotifier));
                        nameFields.Add("Groups", new TitleFields("groupname", null, VTigerType.Groups));
                        nameFields.Add("Currency", new TitleFields("currency_name", null, VTigerType.Currency));
                        nameFields.Add("DocumentFolders", new TitleFields("foldername", null, VTigerType.DocumentFolders));
                        remoteTables = nameFields;
                        break;
                    }
            }

            webserviceVersion = loginResult.version;
            userID = loginResult.userId;
        }
        /// <summary>
        /// Login to the VTiger API.
        /// Neccessary to access any data.
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="accessKey">Personal authentication-key provided on the VTiger website</param>
        public async Task Login()
        {
            string token = (await GetChallenge(this._vconfig.Username)).token;

            string key = GetMD5Hash(token + this._vconfig.AccessKey);

            VTigerLogin loginResult = await VTigerGetJson<VTigerLogin>("login",
                String.Format("username={0}&accessKey={1}", this._vconfig.Username, key), true);

            sessionName = loginResult.sessionName;
            vtigerVersion = loginResult.vtigerVersion;

            switch (vtigerVersion)
            {
                default:
                    {
                        System.Collections.Generic.Dictionary<string, TitleFields> nameFields = new System.Collections.Generic.Dictionary<string, TitleFields>();
                        nameFields.Add("Calendar", new TitleFields("subject", null, VTigerType.Calendar));
                        nameFields.Add("Leads", new TitleFields("firstname", "lastname", VTigerType.Leads));
                        nameFields.Add("Accounts", new TitleFields("accountname", null, VTigerType.Accounts));
                        nameFields.Add("Contacts", new TitleFields("firstname", "lastname", VTigerType.Contacts));
                        nameFields.Add("Potentials", new TitleFields("potentialname", null, VTigerType.Potentials));
                        nameFields.Add("Products", new TitleFields("productname", null, VTigerType.Products));
                        nameFields.Add("Documents", new TitleFields("notes_title", null, VTigerType.Documents));
                        nameFields.Add("Emails", new TitleFields("assigned_user_id", "subject", VTigerType.Emails));
                        nameFields.Add("HelpDesk", new TitleFields("ticket_title", null, VTigerType.HelpDesk));
                        nameFields.Add("Faq", new TitleFields("question", null, VTigerType.Faq));
                        nameFields.Add("Vendors", new TitleFields("vendorname", null, VTigerType.Vendors));
                        nameFields.Add("PriceBooks", new TitleFields("bookname", null, VTigerType.PriceBooks));
                        nameFields.Add("Quotes", new TitleFields("subject", null, VTigerType.Quotes));
                        nameFields.Add("PurchaseOrder", new TitleFields("subject", null, VTigerType.PurchaseOrder));
                        nameFields.Add("SalesOrder", new TitleFields("subject", null, VTigerType.SalesOrder));
                        nameFields.Add("Invoice", new TitleFields("subject", null, VTigerType.Invoice));
                        nameFields.Add("Campaigns", new TitleFields("campaignname", null, VTigerType.Campaigns));
                        nameFields.Add("Events", new TitleFields("subject", null, VTigerType.Events));
                        nameFields.Add("Users", new TitleFields("user_name", null, VTigerType.Users));
                        nameFields.Add("PBXManager", new TitleFields(null, null, VTigerType.PBXManager));
                        nameFields.Add("ServiceContracts", new TitleFields("subject", null, VTigerType.ServiceContracts));
                        nameFields.Add("Services", new TitleFields("servicename", null, VTigerType.Services));
                        nameFields.Add("Assets", new TitleFields("product", "assetname", VTigerType.Assets));
                        nameFields.Add("ModComments", new TitleFields("creator", "related_to", VTigerType.ModComments));
                        nameFields.Add("ProjectMilestone", new TitleFields("projectmilestonename", null, VTigerType.ProjectMilestone));
                        nameFields.Add("ProjectTask", new TitleFields("projecttaskname", null, VTigerType.ProjectTask));
                        nameFields.Add("Project", new TitleFields("projectname", null, VTigerType.Project));
                        nameFields.Add("SMSNotifier", new TitleFields(null, null, VTigerType.SMSNotifier));
                        nameFields.Add("Groups", new TitleFields("groupname", null, VTigerType.Groups));
                        nameFields.Add("Currency", new TitleFields("currency_name", null, VTigerType.Currency));
                        nameFields.Add("DocumentFolders", new TitleFields("foldername", null, VTigerType.DocumentFolders));
                        remoteTables = nameFields;
                        break;
                    }
            }

            webserviceVersion = loginResult.version;
            userID = loginResult.userId;
        }

        /// <summary>
        /// Terminates the current session
        /// </summary>
        public async Task Logout()
        {
            await VTigerGetJson<JsonObject>("logout",
                 String.Format("sessionName={0}", sessionName), true);
            sessionName = null;
            remoteTables = null;
        }

        /// <summary>
        /// Retrieve a list of the different entity-types supported by VTiger (for development)
        /// </summary>
        /// <returns></returns>
        public async Task<VTigerTypeInfo[]> Listtypes()
        {
            VTigerTypes typeList = await VTigerGetJson<VTigerTypes>("listtypes",
                String.Format("sessionName={0}", sessionName), false);

            typeList.typeInfo = new VTigerTypeInfo[typeList.types.Length];
            for (int i = 0; i < typeList.types.Length; i++)
            {
                string typeName = typeList.types[i];
                if (typeList.information.Contains(typeName))
                {
                    typeList.typeInfo[i] = ImportJson<VTigerTypeInfo>(typeList.information[typeName].ToString());
                    typeList.typeInfo[i].Name = typeName;
                }
            }
            return typeList.typeInfo;
        }

        /// <summary>
        /// Retrieve a list of the different entity-types supported by VTiger (for development)
        /// </summary>
        /// <returns></returns>
        public async Task<DataTable> Listtypes_DataTable()
        {
            VTigerTypeInfo[] types = await Listtypes();
            return JsonArrayToDataTable(ImportJson<JsonArray>(ExportJson(types)));
        }

        /// <summary>
        /// Retrieves detailed information about a VTiger entity-type (for development)
        /// </summary>
        /// <param name="elementType"></param>
        /// <returns></returns>
        public async Task<VTigerObjectType> Describe(VTigerType elementType)
        {
            return await VTigerGetJson<VTigerObjectType>("describe",
                String.Format("sessionName={0}&elementType={1}", sessionName, elementType), false);
        }

        /// <summary>
        /// Retrieves detailed information about a VTiger entity-type (for development)
        /// </summary>
        /// <param name="elementType"></param>
        /// <returns></returns>
        public async Task<DataTable> Describe_DataTable(VTigerType elementType)
        {
            VTigerObjectType obj = await Describe(elementType);
            return JsonArrayToDataTable(ImportJson<JsonArray>(ExportJson(obj.fields)));
        }

        #endregion

        //====================================================================
        #region Query & Retrieve

        /// <summary>
        /// Retrieve a single element with the specified id
        /// </summary>
        /// <typeparam name="T">Expected result-type (derivate of VTigerEntity)</typeparam>
        /// <param name="id">VTiger-ID</param>
        /// <returns></returns>
        public async Task<T> Retrieve<T>(string id) //where T : JsonObject, VTigerEntity
        {
            return await VTigerGetJson<T>("retrieve",
                String.Format("sessionName={0}&id={1}", sessionName, id), false);
        }

        /// <summary>
        /// Retrieve a single element with the specified id as a DataTable with a single row
        /// </summary>
        /// <param name="id">VTiger-ID</param>
        /// <returns></returns>
        public async Task<DataTable> Retrieve(string id)
        {
            return JsonObjectToDataTable(await Retrieve<JsonObject>(id));
        }

        /// <summary>
        /// Performs a query on the VTiger database
        /// </summary>
        /// <typeparam name="T">Expected type</typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<T> VTiger_Query<T>(string query)
        {
            return await VTigerGetJson<T>("query",
                String.Format("sessionName={0}&query={1}", sessionName, HttpUtility.UrlEncode(query)), false);
        }

        /// <summary>
        /// Performs a query on the VTiger database and converts the result to an array of the desired type
        /// </summary>
        /// <typeparam name="T">Expected entity-type</typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        /// <example>
        /// This query will return the first 10 contacts whose firstname begins with an "M"  
        /// <code>Query&lt;VTigerContact&gt;("SELECT * FROM Contacts WHERE firstname LIKE 'M%' ORDER BY firstname LIMIT 0,10");</code></example>      
        public async Task<T[]> Query<T>(string query) where T : VTigerEntity
        {
            //Query<VTigerContact>();  
            return await VTiger_Query<T[]>(query);
        }

        public async Task<T[]> Query<T>() where T : VTigerEntity
        {
            return await Query<T>(0, System.Int32.MaxValue);
        }

        public async Task<T[]> Query<T>(int firstRowIndex, int maxNumberOfRecords) where T : VTigerEntity
        {
            T instance = (T)Activator.CreateInstance(typeof(T));
            string remoteTableName = instance.RemoteTableName();
            string limitClause = " LIMIT " + firstRowIndex.ToString() + ", " + maxNumberOfRecords.ToString();
            string sql = "SELECT * FROM " + remoteTableName + limitClause + ";";
            return await VTiger_Query<T[]>(sql);
        }

        /// <summary>
        /// Performs a query on the VTiger database and converts the result into a DataTable
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<DataTable> Query(string query)
        {
            return JsonArrayToDataTable(await VTiger_Query<JsonArray>(query));
        }

        #endregion

        //====================================================================
        #region Create

        /// <summary>
        /// Creates a new VTiger entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elementType"></param>
        /// <param name="element"></param>
        /// <returns></returns>
        public async Task<T> VTiger_Create<T>(VTigerType elementType, string element)
        {
            return await VTigerGetJson<T>("create",
                String.Format("sessionName={0}&elementType={1}&element={2}", sessionName, elementType, HttpUtility.UrlEncode(element)), true);
        }

        /// <summary>
        /// Creates a new VTiger entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="element"></param>
        /// <returns></returns>
        public async Task<T> Create<T>(T element) where T : VTigerEntity
        {
            if (string.IsNullOrEmpty(this.sessionName))
            {
                await Login();
            }
            return await VTiger_Create<T>(element.elementType, ExportJson(element));
        }

        /// <summary>
        /// Creates a new VTiger entity and return the result as a DataTable
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public async Task<DataTable> Create(VTigerEntity element)
        {
            return JsonObjectToDataTable(await VTiger_Create<JsonObject>(element.elementType, ExportJson(element)));
        }

        /// <summary>
        /// Creates a new VTiger entity and return the result as a DataTable
        /// </summary>
        /// <param name="elementType"></param>
        /// <param name="element"></param>
        /// <returns></returns>
        public async Task<DataTable> Create(VTigerType elementType, DataRow element)
        {
            return JsonObjectToDataTable(await VTiger_Create<JsonObject>(elementType, ExportJson(element)));
        }

        /// <summary>
        /// Creates a new empty, locally stored VTiger entity
        /// </summary>
        /// <param name="elementType"></param>
        /// <returns></returns>
        public DataTable NewElement(VTigerType elementType)
        {
            Type dataType = VTigerTypeClasses[(int)elementType];
            DataTable dt = new DataTable();
            foreach (FieldInfo inf in dataType.GetFields())
                dt.Columns.Add(inf.Name, inf.FieldType);
            dt.Rows.Add(dt.NewRow());
            return dt;
        }
        /// <summary>
        /// Creates a new empty, locally stored VTiger entity with column scheme as provided by remote server
        /// </summary>
        /// <remarks>WARNING: the remote system must return at least 1 row! If the remote system returns 0 rows, there won't be any information on columns (table schema).</remarks>
        /// <param name="remoteTableName"></param>
        /// <returns></returns>
        public async Task<DataTable> NewElementFromRemoteServerScheme(string remoteTableName)
        {
            string query = String.Format("select * from {0} limit 1;", remoteTableName); // we need to query for at least 1 row to recieve a table schema!
            DataTable dt = await this.Query(query);
            dt = dt.Clone(); //empty all rows and start from the very beginning - except that we've got the full table schema now ;-)
            if (dt.Columns.Count == 0)
            {
                return this.NewElement(remoteTables[remoteTableName].ElementType);
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                return dt;
            }
        }

        #endregion

        //====================================================================
        #region Update

        /// <summary>
        /// Updates an existing entity in the VTiger database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="element"></param>
        /// <returns></returns>
        private async Task<T> VTiger_Update<T>(string element)
        {
            return await VTigerGetJson<T>("update",
                String.Format("sessionName={0}&element={1}", sessionName, HttpUtility.UrlEncode(element)), true);
        }

        /// <summary>
        /// Updates an existing entity in the VTiger database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="element"></param>
        /// <returns></returns>
        public async Task<T> Update<T>(T element) where T : VTigerEntity
        {
            return await VTiger_Update<T>(ExportJson(element));
        }

        /// <summary>
        /// Updates an existing entity in the VTiger database
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public async Task<DataTable> Update(DataRow element)
        {
            return JsonObjectToDataTable(await VTiger_Update<JsonObject>(ExportJson(element)));
        }

        /// <summary>
        /// Fetches each entry from a DataTable and updates the corrosponding entities in the VTiger database
        /// </summary>
        /// <param name="elements"></param>
        /// <returns></returns>
        public async Task<DataTable> UpdateTable(DataTable elements)
        {
            if (elements.Rows.Count == 0)
                //return elements;
                throw new Exception("Could not perform update: Empty DataTable");

            DataTable result = elements.Clone();
            result.Clear();
            foreach (DataRow row in elements.Rows)
                result.ImportRow((await Update(row)).Rows[0]);
            return result;
        }

        #endregion

        //====================================================================
        #region Delete & Sync

        /// <summary>
        /// Delete an element from the database
        /// </summary>
        /// <param name="id">VTiger-ID</param>
        public async Task Delete(string id)
        {
            await VTigerGetJson<object>("delete",
                  String.Format("sessionName={0}&id={1}", sessionName, id), true);
        }

        public async Task<JsonObject> Sync(DateTime modifiedTime)
        {
            int time = 0;
            JsonObject result;
            result = await VTigerGetJson<JsonObject>("sync",
                String.Format("sessionName={0}&modifiedTime={1}", sessionName, time), false);
            return result;
        }

        public async Task<JsonObject> Sync(DateTime modifiedTime, VTigerType elementType)
        {
            int time = 0;
            JsonObject result;
            result = await VTigerGetJson<JsonObject>("sync",
                String.Format("sessionName={0}&modifiedTime={1}&elementType={2}", sessionName, time, elementType), false);
            return result;
        }

        #endregion

        //====================================================================
        #region Json-Conversion

        /// <summary>
        /// Exports an object with all accessible properties and fields as a Json-string
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public string ExportJson(object o)
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(o);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Imports all possible properties and fields of a Json-string into a new instance of the desired class
        /// </summary>
        /// <typeparam name="T">Target type</typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public T ImportJson<T>(string json)
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " (" + json + ")");
            }
        }

        /// <summary>
        /// Performs an operation with the VTiger webservice
        /// </summary>
        /// <param name="operation">operation-identifier</param>
        /// <param name="parameters">parameters for the operation</param>
        /// <param name="post">Specifies whether a HTTP-GET or HTTP-POST is used for the operation</param>
        /// <returns>VTiger response as string</returns>
        private async Task<string> VTigerExecuteOperation(string operation, string parameters, bool post)
        {
            string response;
            if (post)
                response = await HttpPost(baseUrl + operation, parameters);
            else
                response = await HttpGet(baseUrl + operation + "&" + parameters);
            if (response == null)
                throw new Exception("Unable to connect to VTiger-Service");
            return response;
        }

        /// <summary>
        /// Performs an operation with the VTiger webservice and converts the result to the desired type
        /// </summary>
        /// <typeparam name="T">Expected type for the result</typeparam>
        /// <param name="operation">operation-identifier</param>
        /// <param name="parameters">parameters for the operation</param>
        /// <param name="post">Specifies whether a HTTP-GET or HTTP-POST is used for the operation</param>
        /// <returns></returns>
        private async Task<T> VTigerGetJson<T>(string operation, string parameters, bool post)
        {
            string response = await VTigerExecuteOperation(operation, parameters, post);
            VTigerResult<T> result = ImportJson<VTigerResult<T>>(response);
            if (!result.success)
            {
                if (result.error.code == "INVALID_SESSIONID")
                {
                    throw new VTigerApiSessionTimedOutException(result.error);
                }
                else
                {
                    throw new VTigerApiException(result.error);
                }
            }
            return result.result;
        }

        /// <summary>
        /// Adds a new row to the DataTable and converts special fields if needed
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="obj"></param>
        private void DtConvertAddRow(DataTable dt, JsonObject obj)
        {
            DataRow dr = dt.NewRow();
            int i = 0;
            foreach (JsonMember member in obj)
            {
                if ((member.Name == "saved_toid") || (member.Name == "ccmail") || (member.Name == "bccmail"))
                {
                    if ((string)member.Value == "")
                        dr[i] = "";
                    else
                    {
                        string[] values = ImportJson<string[]>((string)member.Value);
                        dr[i] = ListStrings(values);
                    }
                }
                else
                    dr[i] = member.Value;
                i++;
            }
            dt.Rows.Add(dr);
        }

        /// <summary>
        /// Converts a JsonArray (from a query) into a DataTable
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public DataTable JsonArrayToDataTable(JsonArray array)
        {
            DataTable dt = new DataTable();
            if (array.Length == 0)
                return dt;

            object o = array[0];
            if (o is JsonObject)
            {
                JsonObject[] items = ImportJson<JsonObject[]>(array.ToString());

                foreach (JsonMember member in items[0])
                    dt.Columns.Add(new DataColumn(member.Name, typeof(string)));

                foreach (JsonObject item in items)
                    DtConvertAddRow(dt, item);

                if (dt.Columns.Contains("id"))
                    dt.Columns["id"].SetOrdinal(0);

                return dt;
            }
            throw new Exception("Only JsonArray of JsonObject can be deserialized to a DataTable");
        }

        /// <summary>
        /// Converts a JsonObject into a DataTable with a single row
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public DataTable JsonObjectToDataTable(JsonObject o)
        {
            DataTable dt = new DataTable();

            foreach (JsonMember member in o)
                dt.Columns.Add(new DataColumn(member.Name, typeof(string)));
            DtConvertAddRow(dt, o);

            if (dt.Columns.Contains("id"))
                dt.Columns["id"].SetOrdinal(0);

            return dt;
        }

        #endregion

        #endregion

        //====================================================================
        #region Searches

        private static string SqlContains = " LIKE '%{0}%'";
        private static string SqlDateFrom = " >= '{0}'";
        private static string SqlDateTo = " <= '{0}'";

        /// <summary>
        /// Creates a new VTigerQueryWriter and initializes it with default search-parameters.
        /// Empty parameters are excluded from the search.
        /// </summary>
        /// <param name="table"></param>
        /// <param name="PrimaryCol">Primary search-column-name</param>
        /// <param name="OptionalCols">Optional search-column-names</param>
        /// <param name="DateCol">Column for date-search</param>
        /// <param name="PrimaryText"></param>
        /// <param name="OptionalText"></param>
        /// <param name="FromDate"></param>
        /// <param name="ToDate"></param>
        /// <returns>Returns the initialized VTigerQueryWriter</returns>       
        public VTigerQueryWriter DefaultSearchQuery(VTigerType table,
            string PrimaryCol, string PrimaryText,
            string[] OptionalCols, string OptionalText,
            string DateCol, DateTime FromDate, DateTime ToDate)
        {
            string optionalCmp = string.Format(" LIKE '%{0}%'", OptionalText.Replace(" ", "%"));
            string FromDateCmp = string.Format(" >= '{0}'", DateTimeToVtDate(FromDate));
            string ToDateCmp = string.Format(" <= '{0}'", DateTimeToVtDate(ToDate));

            VTigerQueryWriter queryWriter = new VTigerQueryWriter(table);

            if ((OptionalText != "") && (OptionalCols.Length != 0))
                foreach (string colName in OptionalCols)
                    queryWriter.AddOrCondition(colName + optionalCmp);

            if ((FromDate != DateTime.FromBinary(0)) && (DateCol != ""))
                queryWriter.AddAndCondition(DateCol + FromDateCmp);

            if ((ToDate != DateTime.FromBinary(0)) && (DateCol != ""))
                queryWriter.AddAndCondition(DateCol + ToDateCmp);

            if ((PrimaryText != "") && (PrimaryCol != ""))
                queryWriter.AddAndCondition(PrimaryCol + string.Format(SqlContains, PrimaryText));

            return queryWriter;
        }

        private string VTigerTableName(VTigerType elementType)
        {
            //return "vtiger_" + String.Format("{0}", elementType);
            return String.Format("{0}", elementType);
        }

        /// <summary>
        /// Searches for an entity which matches the specified condition and retrives it's ID
        /// </summary>
        /// <param name="elementType"></param>
        /// <param name="field">The field of the entity which should match the specified value</param>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task<string> FindEntityID(VTigerType elementType, string field, string value)
        {
            VTigerEntity[] items = await Query<VTigerEntity>(String.Format(
                "SELECT id,{1} FROM {0} WHERE {1}='{2}';", VTigerTableName(elementType), field, value));
            if (items.Length == 0)
                throw new Exception(String.Format(
                    "Could not find an element for the condition {0}='{1}'", field, value));
            if (items.Length != 1)
                throw new Exception(String.Format(
                    "Found multiple elements with the condition {0}='{1}'", field, value));
            return items[0].id;
        }

        // public T Create<T>(T element) where T : VTigerEntity

        /// <summary>
        /// Searches for an entity which matches the specified condition and retrives it's data
        /// </summary>
        /// <param name="field">The field of the entity which should match the specified value</param>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task<T> FindEntity<T>(string field, string value) where T : VTigerEntity, new()
        {
            T[] items = await Query<T>(String.Format(
                "SELECT * FROM {0} WHERE {1}='{2}';", VTigerTableName((new T()).elementType), field, value));
            if (items.Length == 0)
                return null;
            //throw new Exception(String.Format(
            //    "Could not find an element for the condition {0}='{1}'", field, value));
            if (items.Length != 1)
                throw new Exception(String.Format(
                    "Found multiple elements with the condition {0}='{1}'", field, value));
            return items[0];
        }

        #region Default GetID-functions

        public async Task<string> GetUserID(string name)
        {
            return await FindEntityID(VTigerType.Users, "user_name", name);
        }

        public async Task<string> GetAccountID(string name)
        {
            return await FindEntityID(VTigerType.Accounts, "accountname", name);
        }

        public async Task<string> GetProductID(string name)
        {
            return await FindEntityID(VTigerType.Products, "productname", name);
        }

        public async Task<string> GetCampaignID(string name)
        {
            return await FindEntityID(VTigerType.Campaigns, "campaignname", name);
        }

        public async Task<string> GetServiceID(string name)
        {
            return await FindEntityID(VTigerType.Services, "servicename", name);
        }

        public async Task<string> GetAssetID(string name)
        {
            return await FindEntityID(VTigerType.Assets, "assetname", name);
        }

        public async Task<string> GetProjectTaskID(string name)
        {
            return await FindEntityID(VTigerType.ProjectTask, "projecttaskname", name);
        }

        public async Task<string> GetProjectID(string name)
        {
            return await FindEntityID(VTigerType.Project, "projectname", name);
        }

        public async Task<string> GetGroupID(string name)
        {
            return await FindEntityID(VTigerType.Products, "groupname", name);
        }

        public async Task<string> GetCurrencyID(string name)
        {
            return await FindEntityID(VTigerType.Products, "currency_name", name);
        }

        #endregion

        #region Default Searches

        /// <summary>
        /// Returns a default search-query
        /// </summary>
        /// <remarks>
        /// Default search-attributes:
        /// Primary-Column: invoice_no
        /// Optional-Columns: subject, hdnGrandTotal, hdnSubTotal, hdnDiscountAmount, txtAdjustment, terms_conditions
        /// Date-Column: invoicedate
        /// </remarks>
        /// <param name="invoice_no"></param>
        /// <param name="searchText"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        /// <seealso cref="VTigerApi.VTiger.DefaultSearchQuery"/>
        public VTigerQueryWriter DefaultSearchInvoices(string invoice_no, string searchText, DateTime fromDate, DateTime toDate)
        {
            return DefaultSearchQuery(VTigerType.Invoice, "invoice_no", invoice_no,
                new string[] { "subject", "hdnGrandTotal", "hdnSubTotal", "hdnDiscountAmount", "txtAdjustment", "terms_conditions" }, searchText,
                "invoicedate", fromDate, toDate);
        }

        #endregion

        #endregion

        //====================================================================

        #region Default Add-functions

        //public async Task<VTigerCalendar> AddCalendar(string user_id, string subject,
        //    DateTime date_start, DateTime due_date, TaskStatus taskStatus)
        //{
        //    //Todo: For some kind of reason the server returns success, without creating a new element
        //    VTigerCalendar element = new VTigerCalendar(
        //        subject,
        //        user_id,
        //        DateTimeToVtDate(date_start),
        //        DateTimeToVtTime(date_start),
        //        DateTimeToVtDate(due_date),
        //        taskStatus);
        //    return await Create<VTigerCalendar>(element);
        //}


        //public VTigerAccount AddAccount(string accountname, string assigned_user_id)
        //{
        //    VTigerAccount element = new VTigerAccount(
        //        accountname,
        //        assigned_user_id);
        //    return Create<VTigerAccount>(element);
        //}

        //public VTigerContact AddContact(string firstname, string lastname, string assigned_user_id)
        //{
        //    VTigerContact element = new VTigerContact(
        //        lastname,
        //        assigned_user_id);
        //    element.firstname = firstname;
        //    // return Update<VTigerContact>(element);
        //    return Create<VTigerContact>(element);
        //}

        //public VTigerPotential AddPotential(string potentialname, string related_to,
        //    string closingdate, Sales_stage sales_stage, string assigned_user_id)
        //{
        //    VTigerPotential element = new VTigerPotential(
        //        potentialname,
        //        related_to,
        //        closingdate,
        //        sales_stage,
        //        assigned_user_id);
        //    return Create<VTigerPotential>(element);
        //}

        //public VTigerProduct AddProduct(string productname, string assigned_user_id)
        //{
        //    return Create<VTigerProduct>(new VTigerProduct(productname, assigned_user_id));
        //}

        //public VTigerDocument AddDocument(string notes_title, string assigned_user_id)
        //{
        //    VTigerDocument element = new VTigerDocument(
        //        notes_title,
        //        assigned_user_id);
        //    return Create<VTigerDocument>(element);
        //}

        //public VTigerEmail AddEmail(string subject, DateTime date_start,
        //    string from_email, string[] saved_toid, string assigned_user_id)
        //{
        //    VTigerEmail element = new VTigerEmail(
        //        subject,
        //        date_start,
        //        from_email,
        //        saved_toid,
        //        assigned_user_id);
        //    return Create<VTigerEmail>(element);
        //}

        //public VTigerHelpDesk AddHelpDesk(string assigned_user_id, Ticketstatus ticketstatus, string ticket_title)
        //{
        //    VTigerHelpDesk element = new VTigerHelpDesk(
        //        assigned_user_id,
        //        ticketstatus,
        //        ticket_title);
        //    return  Create<VTigerHelpDesk>(element);
        //}

        //public VTigerFaq AddFaq(Faqstatus faqstatus, string question, string faq_answer)
        //{
        //    VTigerFaq element = new VTigerFaq(
        //        faqstatus,
        //        question,
        //        faq_answer);
        //    return Create<VTigerFaq>(element);
        //}

        //public VTigerVendor AddVendor(string vendorname, string assigned_user_id)
        //{
        //    return Create<VTigerVendor>(new VTigerVendor(vendorname, assigned_user_id));
        //}

        //public VTigerPriceBook AddPriceBook(string bookname, string currency_id)
        //{
        //    VTigerPriceBook element = new VTigerPriceBook(
        //        bookname,
        //        currency_id);
        //    return Create<VTigerPriceBook>(element);
        //}

        //public VTigerQuote AddQuote(string subject, Quotestage quotestage, string bill_street,
        //    string ship_street, string account_id, string assigned_user_id)
        //{
        //    VTigerQuote element = new VTigerQuote(
        //        subject,
        //        quotestage,
        //        bill_street,
        //        ship_street,
        //        account_id,
        //        assigned_user_id);
        //    return Create<VTigerQuote>(element);
        //}

        //public VTigerPurchaseOrder AddPurchaseOrder(string subject, string vendor_id, PoStatus postatus,
        //    string bill_street, string ship_street, string assigned_user_id)
        //{
        //    VTigerPurchaseOrder element = new VTigerPurchaseOrder(
        //        subject,
        //        vendor_id,
        //        postatus,
        //        bill_street,
        //        ship_street,
        //        assigned_user_id);
        //    return Create<VTigerPurchaseOrder>(element);
        //}

        //public VTigerSalesOrder AddSalesOrder(string subject, SoStatus sostatus, string bill_street,
        //    string ship_street, Invoicestatus invoicestatus, string account_id, string assigned_user_id)
        //{
        //    VTigerSalesOrder element = new VTigerSalesOrder(
        //        subject,
        //        sostatus,
        //        bill_street,
        //        ship_street,
        //        invoicestatus,
        //        account_id,
        //        assigned_user_id);
        //    return Create<VTigerSalesOrder>(element);
        //}

        //public VTigerInvoice AddInvoice(string subject, string bill_street, string ship_street,
        //    string account_id, string assigned_user_id)
        //{
        //    VTigerInvoice element = new VTigerInvoice(
        //        subject,
        //        bill_street,
        //        ship_street,
        //        account_id,
        //        assigned_user_id);
        //    return Create<VTigerInvoice>(element);
        //}

        //public VTigerCampaign AddCampaign(string campaignname, DateTime closingdate, string assigned_user_id)
        //{
        //    VTigerCampaign element = new VTigerCampaign(
        //        campaignname,
        //        closingdate,
        //        assigned_user_id);
        //    return Create<VTigerCampaign>(element);
        //}

        //public VTigerEvent AddEvent(string subject, string date_start, string time_start, string due_date,
        //    string time_end, int duration_hours, Eventstatus eventstatus,
        //    Activitytype activitytype, string assigned_user_id)
        //{
        //    VTigerEvent element = new VTigerEvent(
        //        subject,
        //        date_start,
        //        time_start,
        //        due_date,
        //        time_end,
        //        duration_hours,
        //        eventstatus,
        //        activitytype,
        //        assigned_user_id);
        //    return Create<VTigerEvent>(element);
        //}

        //public VTigerPBXManager AddPBXManager(string customernumber, string callfrom, string callto, string assigned_user_id)
        //{
        //    VTigerPBXManager element = new VTigerPBXManager(
        //        customernumber,
        //        callfrom,
        //        callto,
        //        assigned_user_id);
        //    return Create<VTigerPBXManager>(element);
        //}

        //public VTigerServiceContract AddServiceContract(string subject, string assigned_user_id)
        //{
        //    VTigerServiceContract element = new VTigerServiceContract(
        //        subject,
        //        assigned_user_id);
        //    return Create<VTigerServiceContract>(element);
        //}

        //public VTigerService AddService(string servicename)
        //{
        //    return Create<VTigerService>(new VTigerService(servicename));
        //}

        //public VTigerAsset AddAsset(string product, string serialnumber, string datesold,
        //    string dateinservice, Assetstatus assetstatus, string assetname,
        //    string account, string assigned_user_id)
        //{
        //    VTigerAsset element = new VTigerAsset(
        //        product,
        //        serialnumber,
        //        datesold,
        //        dateinservice,
        //        assetstatus,
        //        assetname,
        //        account,
        //        assigned_user_id);
        //    return Create<VTigerAsset>(element);
        //}

        //public VTigerDocument Add()
        //{
        //    VTigerDocument element = new VTigerDocument(
        //        account_id,
        //        assigned_user_id);
        //    return Create<VTigerDocument>(element);
        //}

        #endregion

        //====================================================================
        #region Helpers

        private static string GetMD5Hash(string input)
        {
            if ((input == null) || (input.Length == 0))
            {
                return string.Empty;
            }
            byte[] data;
            using (MD5 md5Hasher = MD5.Create())
                data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        private static async Task<string> HttpGet(string url)
        {
            HttpWebRequest webRequest = GetWebRequest(url);
            if (IgnoreSslCertificateErrors)
            {
                ServicePointManager.ServerCertificateValidationCallback += delegate { return true; };
            }
            else
            {
                ServicePointManager.ServerCertificateValidationCallback = null;
            }
            HttpWebResponse response = (HttpWebResponse)(await webRequest.GetResponseAsync());
            string jsonResponse = string.Empty;
            using (StreamReader sr = new StreamReader(response.GetResponseStream()))
            {
                jsonResponse = sr.ReadToEnd();
            }
            return jsonResponse;
        }

        private static async Task<string> HttpPost(string url, string parameters)
        {
            HttpWebRequest webRequest = GetWebRequest(url);
            if (IgnoreSslCertificateErrors)
            {
                ServicePointManager.ServerCertificateValidationCallback += delegate { return true; };
            }
            else
            {
                ServicePointManager.ServerCertificateValidationCallback = null;
            }
            webRequest.ContentType = "application/x-www-form-urlencoded";

            webRequest.Method = "POST";
            byte[] data = Encoding.ASCII.GetBytes(parameters);
            webRequest.ContentLength = data.Length;
            using (Stream stream = webRequest.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            try
            {
                // get the response
                WebResponse webResponse = await webRequest.GetResponseAsync();
                if (webResponse == null)
                { return null; }
                StreamReader sr = new StreamReader(webResponse.GetResponseStream());
                return sr.ReadToEnd().Trim();
            }
            catch (WebException)
            {
                throw;
                //MessageBox.Show(ex.Message, "HttpPost: Response error",
                //   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static HttpWebRequest GetWebRequest(string formattedUri)
        {
            if (IgnoreSslCertificateErrors)
            {
                ServicePointManager.ServerCertificateValidationCallback += delegate { return true; };
            }
            else
            {
                ServicePointManager.ServerCertificateValidationCallback = null;
            }
            // Create the request’s URI.      
            Uri serviceUri = new Uri(formattedUri, UriKind.Absolute);
            // Return the HttpWebRequest.        
            return (HttpWebRequest)System.Net.WebRequest.Create(serviceUri);
        }

        public static VTigerType VTigerTypeParse(string text)
        {
            return (VTigerType)Enum.Parse(typeof(VTigerType), text, true);
        }

        public static string DateTimeToVtDate(DateTime date)
        {
            return date.ToString("yyyy-MM-dd");
        }

        public static string DateTimeToVtTime(DateTime time)
        {
            return time.ToString("hh:mm:ss");
        }

        public string ListStrings(string[] strings)
        {
            if (strings.Length == 0)
                return "";
            if (strings.Length == 1)
                return strings[0];
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < strings.Length - 1; i++)
                sb.Append(strings[i] + ",");
            sb.Append(strings[strings.Length - 1]);
            return sb.ToString();
        }

        #endregion
    }

    public class VTigerQueryWriter
    {
        public string[] columns = { "*" };
        public VTigerType table;
        public int limitStart = 0;
        public int limitCount = 100;
        public string[][] conditions;// = new string[0][];

        public VTigerQueryWriter(VTigerType aTable)
        {
            table = aTable;
        }

        public override string ToString()
        {
            return Query;
        }

        public string Query
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("SELECT ");
                if (columns.Length > 0)
                {
                    foreach (string item in columns)
                        sb.Append(item + ", ");
                    sb.Remove(sb.Length - 2, 2);
                    sb.AppendLine();
                }
                else
                    sb.AppendLine("*");

                sb.Append("FROM ");
                sb.AppendLine(table.ToString());

                if ((conditions != null) && (conditions.Length > 0))
                {
                    sb.Append("WHERE ");
                    foreach (string[] orCond in conditions)
                    {
                        foreach (string andCond in orCond)
                        {
                            sb.Append(andCond);
                            sb.Append(" AND ");
                        }
                        sb.Remove(sb.Length - 5, 5);
                        sb.Append(" OR ");
                    }
                    sb.Remove(sb.Length - 4, 4);
                    sb.AppendLine();
                }
                sb.Append("LIMIT ");
                sb.Append(limitStart.ToString());
                sb.Append(", ");
                sb.Append(limitCount.ToString());

                sb.Append(";");
                return sb.ToString();
            }
        }

        public void AddAndCondition(string condition)
        {
            if ((conditions == null) || (conditions.Length == 0))
            {
                conditions = new string[1][];
                conditions[0] = new string[1];
                conditions[0][0] = condition;
            }
            else
            {
                for (int i = 0; i < conditions.Length; i++)
                {
                    string[] newList = new string[conditions[i].Length + 1];
                    for (int j = 0; j < conditions[i].Length; j++)
                        newList[j] = conditions[i][j];
                    newList[newList.Length - 1] = condition;
                    conditions[i] = newList;
                }
            }
        }

        public void AddOrCondition(string condition)
        {
            if ((conditions == null) || (conditions.Length == 0))
            {
                conditions = new string[1][];
                conditions[0] = new string[1];
                conditions[0][0] = condition;
            }
            else
            {
                string[][] newList = new string[conditions.Length + 1][];
                for (int i = 0; i < conditions.Length; i++)
                {
                    newList[i] = conditions[i];
                }
                newList[conditions.Length] = new string[1];
                newList[conditions.Length][0] = condition;
                conditions = newList;
            }
        }
    }
}
