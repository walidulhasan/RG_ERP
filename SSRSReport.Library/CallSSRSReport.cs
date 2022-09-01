using Microsoft.Data.SqlClient;
using RG.Application.Common.Models;
using RG.Application.Enums;
using ServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Threading.Tasks;

namespace SSRSReport.Library
{
    public class CallSSRSReport
    {

        /// <summary>
        /// </summary>
        /// <param name="reportName">
        ///  report name.
        /// </param>
        /// <param name="parameters">report's required parameters</param>
        /// <param name="exportFormat">value = "PDF" or "EXCEL". By default it is pdf.</param>
        /// <param name="languageCode">
        ///   value = 'en-us', 'fr-ca', 'es-us', 'zh-chs'. 
        /// </param>
        /// <returns></returns>
        public async Task<byte[]> RenderReport(string reportName, IDictionary<string, object> parameters, string languageCode, string exportFormat, int ServerConnectionString = 0)
        {
            //
            // SSRS report path. Note: Need to include parent folder directory and report name.
            // Such as value = "/[report folder]/[report name]".
            //
            //string reportPath = string.Format("{0}{1}", ConfigSettings.ReportingServiceReportFolder, reportName);
            string reportPath = reportName;// string.Format("/{0}/{1}", StaticConfigs.GetConfig("ReportingServiceReportFolder"), reportName);
            //
            // Binding setup, since ASP.NET Core apps don't use a web.config file
            //
            var binding = new BasicHttpBinding(BasicHttpSecurityMode.TransportCredentialOnly);
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Ntlm;
            //binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Ntlm; // May Be Change
            binding.MaxReceivedMessageSize = 100000000; //this.ConfigSettings.ReportingServiceReportMaxSize; //It is 10MB size limit on response to allow for larger PDFs
            binding.SendTimeout = new TimeSpan(0, 50, 0);
            //Create the execution service SOAP Client
            //  ReportExecutionServiceSoapClient reportClient = new ReportExecutionServiceSoapClient(binding, new EndpointAddress(this.ConfigSettings.ReportingServiceUrl));
            ReportExecutionServiceSoapClient reportClient = new ReportExecutionServiceSoapClient(binding, new EndpointAddress(StaticConfigs.GetConfig("ReportingServiceUrl")));
            //Setup access credentials. Here use windows credentials.
            // var clientCredentials = new NetworkCredential(this.ConfigSettings.ReportingServiceUserAccount, this.ConfigSettings.ReportingServiceUserAccountPassword, this.ConfigSettings.ReportingServiceUserAccountDomain);
            var clientCredentials = new NetworkCredential(StaticConfigs.GetConfig("ReportingServiceUserAccount"), StaticConfigs.GetConfig("ReportingServiceUserAccountPassword"));
            reportClient.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;
            reportClient.ClientCredentials.Windows.ClientCredential = clientCredentials;

            //This handles the problem of "Missing session identifier"
            reportClient.Endpoint.EndpointBehaviors.Add(new ReportingServiceEndPointBehavior());
            string historyID = null;
            TrustedUserHeader trustedUserHeader = new TrustedUserHeader();
            ExecutionHeader execHeader = new ExecutionHeader();

            trustedUserHeader.UserName = clientCredentials.UserName;

            //
            // Load the report
            //
            var taskLoadReport = await reportClient.LoadReportAsync(trustedUserHeader, reportPath, historyID);

            // Fixed the exception of "session identifier is missing".
            execHeader.ExecutionID = taskLoadReport.executionInfo.ExecutionID;

            //
            //Set the parameteres asked for by the report
            //
            ParameterValue[] reportParameters = null;
            if (parameters != null && parameters.Count > 0)
            {
                reportParameters = taskLoadReport.executionInfo.Parameters
                    .Where(x => parameters.ContainsKey(x.Name))
                    .Select(x => new ParameterValue() { Name = x.Name, Value = parameters[x.Name]==null? null: parameters[x.Name].ToString() })
                    .ToArray();
            }

            /*Database Security*/
            var connectionBuilder = new SqlConnectionStringBuilder(GetServerConnectionString(ServerConnectionString));
            var user = connectionBuilder.UserID;
            var pwd = connectionBuilder.Password;
            var datasource = connectionBuilder.DataSource;
            var dbname = connectionBuilder.InitialCatalog;

            var dbParm = new List<ParameterValue>(); ;
            dbParm.Add(new ParameterValue() { Name = "ServerName", Value = datasource });
            dbParm.Add(new ParameterValue() { Name = "DatabaseName", Value = dbname });
            if (reportParameters != null && reportParameters.Count() > 0)
            {
                dbParm.AddRange(reportParameters);
            }

            DataSourceCredentials dataSourceCredentials = new DataSourceCredentials();
            if (taskLoadReport.executionInfo.DataSourcePrompts.Length > 0)
            {
                dataSourceCredentials.DataSourceName = taskLoadReport.executionInfo.DataSourcePrompts[0].Name;
            }
            else
                dataSourceCredentials.DataSourceName = "AK-JT";

            dataSourceCredentials.UserName = user;
            dataSourceCredentials.Password = pwd;

            DataSourceCredentials[] dsCredentials = new DataSourceCredentials[] { dataSourceCredentials };
            await reportClient.SetExecutionCredentialsAsync(execHeader, trustedUserHeader, dsCredentials);

            /*End Database Security*/

            //reportClient.SetExecutionCredentialsAsync();
            await reportClient.SetExecutionParametersAsync(execHeader, trustedUserHeader, dbParm.ToArray(), languageCode);
            // run the report
            const string deviceInfo = @"<DeviceInfo><Toolbar>False</Toolbar></DeviceInfo>";

            var response = await reportClient.RenderAsync(new RenderRequest(execHeader, trustedUserHeader, exportFormat ?? "PDF", deviceInfo));

            //spit out the result
            return response.Result;
        }


        public string GetServerConnectionString(int ServerConnectionString)
        {
            string _connectionString = "";
            switch (ServerConnectionString)
            {
                case 0:
                    _connectionString = StaticConfigs.GetConnectionString("MaxcoConnection");
                    break;
                case (int)enum_ServerType.MaxcoConnection:
                    _connectionString = StaticConfigs.GetConnectionString("MaxcoConnection");
                    break;

                case (int)enum_ServerType.MaterialsManagementConnection:
                    _connectionString = StaticConfigs.GetConnectionString("MaterialsManagementConnection");
                    break;
                case (int)enum_ServerType.EMSConnection:
                    _connectionString = StaticConfigs.GetConnectionString("EMSConnection");
                    break;
                case (int)enum_ServerType.FiniteSchedulerConnection:
                    _connectionString = StaticConfigs.GetConnectionString("FiniteSchedulerConnection");
                    break;
                case (int)enum_ServerType.EmbroConnection:
                    _connectionString = StaticConfigs.GetConnectionString("EmbroConnection");
                    break;
                case (int)enum_ServerType.AuthConnection:
                    _connectionString = StaticConfigs.GetConnectionString("AuthConnection");
                    break;
                case (int)enum_ServerType.Algo_HRM:
                    _connectionString = StaticConfigs.GetConnectionString("AlgoHRConnection");
                    break;
                default:
                    _connectionString = StaticConfigs.GetConnectionString("MaxcoConnection");
                    break;
            }



            return _connectionString;
        }
    }
    public class ReportingServiceEndPointBehavior : IEndpointBehavior
    {
        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters) { }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            clientRuntime.ClientMessageInspectors.Add(new ReportingServiceExecutionInspector());
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher) { }

        public void Validate(ServiceEndpoint endpoint) { }
    }
    public class ReportingServiceExecutionInspector : IClientMessageInspector
    {
        private MessageHeaders headers;

        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
            var index = reply.Headers.FindHeader("ExecutionHeader", "http://schemas.microsoft.com/sqlserver/2005/06/30/reporting/reportingservices");
            if (index >= 0 && headers == null)
            {
                headers = new MessageHeaders(MessageVersion.Soap11);
                headers.CopyHeaderFrom(reply, reply.Headers.FindHeader("ExecutionHeader", "http://schemas.microsoft.com/sqlserver/2005/06/30/reporting/reportingservices"));
            }
        }

        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            if (headers != null)
                request.Headers.CopyHeadersFrom(headers);

            return Guid.NewGuid(); //https://msdn.microsoft.com/en-us/library/system.servicemodel.dispatcher.iclientmessageinspector.beforesendrequest(v=vs.110).aspx#Anchor_0
        }
    }
}
