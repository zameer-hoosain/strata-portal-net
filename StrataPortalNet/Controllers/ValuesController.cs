using Rockend.iStrata.StrataCommon.Request;
using Rockend.iStrata.StrataCommon.Response;
using Rockend.iStrata.StrataWebsite.Model;
using Rockend.WebAccess.RockendMessage;
using ServiceReference1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Xml.Serialization;

namespace StrataPortalNet.Controllers
{
    public class ValuesController : ApiController
    {
        [Route("api/logon")]
        public async Task<LoginResponse> Get()
        {
        
            var loginRequest = new LoginRequest();
            loginRequest.UserName = "13000017";
            loginRequest.Password = "gemini";
            loginRequest.Role = Rockend.iStrata.StrataCommon.Role.ExecutiveMember;

            var rockendRequest = new RockendRequest();

            rockendRequest.ActionName = "SMH.LoginCheck";
            rockendRequest.ApplicationCode = "SM";
            rockendRequest.ApplicationKey = 270656;
            rockendRequest.BodyXml = loginRequest.SerializeToXML(); ;
            rockendRequest.ServiceKey = 2000000;
            rockendRequest.ServicePassword = "r0ckend";
            rockendRequest.SessionID = "";

            var response = await executeSOAPRequest(rockendRequest);

            var loginResponse = response.ProcessResult.BodyAs<LoginResponse>();

            

            return loginResponse;
        }

        [Route("api/ownerRequest")]
        public async Task<OwnerResponse> GetOwner()
        {
            var request = new OwnerRequest();
            request.OwnersCorpID = 1;

            var rockendRequest = new RockendRequest();

            rockendRequest.ActionName = "OwnersRequest";
            rockendRequest.ApplicationCode = "SM";
            rockendRequest.ApplicationKey = 270656;
            rockendRequest.BodyXml = request.SerializeToXML();
            rockendRequest.ServiceKey = 2000000;
            rockendRequest.ServicePassword = "r0ckend";
            rockendRequest.SessionID = "";

            var response = await executeSOAPRequest(rockendRequest);

            var ownerResponse = response.ProcessResult.BodyAs<OwnerResponse>();



            return ownerResponse;
        }

        [Route("api/lotRequest")]
        public async Task<LotResponse> GetLot()
        {
            var request = new LotRequest();
            request.LotID = 10;
            request.IsAgent = true;
            request.IsGeneral = true;
            request.IsLevy = true;

            var rockendRequest = new RockendRequest();

            rockendRequest.ActionName = "LotRequest";
            rockendRequest.ApplicationCode = "SM";
            rockendRequest.ApplicationKey = 270656;
            rockendRequest.BodyXml = request.SerializeToXML();
            rockendRequest.ServiceKey = 2000000;
            rockendRequest.ServicePassword = "r0ckend";
            rockendRequest.SessionID = "";

            var response = await executeSOAPRequest(rockendRequest);

            var lotResponse = response.ProcessResult.BodyAs<LotResponse>();



            return lotResponse;
        }

        [Route("api/reports/rptCurrentOwnerAccount")]
        public async Task<ReportResponse> GetRptCurrentOwnerAccount()
        {
            var request = new ReportRequest();
            request.MainCommand = "rptCurrentOwnerAccount";
            request.Parameter0 = "10";
            request.Parameter1 = "1";
            request.ErrorsOccured = "N";
            request.ProgressCounter = 0;
            request.StrataLaunchConfirmed = "N";
            request.TaskIsFinished = "N";

            var rockendRequest = new RockendRequest();

            rockendRequest.ActionName = "";
            rockendRequest.ApplicationCode = "SM";
            rockendRequest.ApplicationKey = 270656;
            rockendRequest.BodyXml = request.SerializeToXML();
            rockendRequest.ServiceKey = 2000000;
            rockendRequest.ServicePassword = "r0ckend";
            rockendRequest.SessionID = "";

            var response = await executeSOAPRequest(rockendRequest);

            var reportResponse = response.ProcessResult.BodyAs<ReportResponse>();

            return reportResponse;
        }

        [Route("api/meetingAgenda")]
        public async Task<MeetingAgendaReponse> GetMeetingAgenda()
        {
            var request = new MeetingAgendaRequest
            {
                LotID = 10,
                MeetingRegisterId = 319
            };

            var rockendRequest = new RockendRequest();

            rockendRequest.ActionName = "GetMeetingAgenda";
            rockendRequest.ApplicationCode = "SM";
            rockendRequest.ApplicationKey = 270656;
            rockendRequest.BodyXml = request.SerializeToXML();
            rockendRequest.ServiceKey = 2000000;
            rockendRequest.ServicePassword = "r0ckend";
            rockendRequest.SessionID = "";

            var response = await executeSOAPRequest(rockendRequest);

            var result = response.ProcessResult.BodyAs<MeetingAgendaReponse>();

            return result;
        }

        [Route("api/castVote")]
        public async Task<MeetingAgendaReponse> VoteOnMeeting()
        {
            var agendaItems = new List<MeetingAgendaItemResponse>
            {
                new MeetingAgendaItemResponse
                {
                    AgendaItemId = 343,
                    Description = "test",
                    MotionText = "testing",
                    SortOrder = 1,
                    MeetingRecordItem = new Rockend.iStrata.StrataCommon.BusinessEntities.MeetingRecord {
                MeetingRecordID= 24,
                MeetingRegisterID= 319,
                LotID= 10,
                AgendaWizardID= 343,
                Vote= "N",
                DateChanged= new DateTime()
            }
                },

                new MeetingAgendaItemResponse
                {
                    AgendaItemId = 344,
                    Description = "tesda",
                    MotionText = "adsfasd",
                    SortOrder = 3,
                    MeetingRecordItem =  new Rockend.iStrata.StrataCommon.BusinessEntities.MeetingRecord {
                MeetingRecordID= 25,
                MeetingRegisterID= 319,
                LotID= 10,
                AgendaWizardID= 344,
                Vote= "N",
                DateChanged= new DateTime()
            }
                }
            };


            var request = new MeetingAgendaReponse
            {
                AgendaItems = agendaItems,
                ProxyName = null
            };

            var rockendRequest = new RockendRequest();

            rockendRequest.ActionName = "SyncVoteResults";
            rockendRequest.ApplicationCode = "SM";
            rockendRequest.ApplicationKey = 270656;
            rockendRequest.BodyXml = SerializeObject<MeetingAgendaReponse>(request);
            rockendRequest.ServiceKey = 2000000;
            rockendRequest.ServicePassword = "r0ckend";
            rockendRequest.SessionID = "";

            var response = await executeSOAPRequest(rockendRequest);

            var result = response.ProcessResult.BodyAs<MeetingAgendaReponse>();

            return result;
        }

        [Route("api/execInfo")]
        public async Task<ExecutiveResponse> GetExecInfo()
        {
            var request = new ExecutiveRequest
            {
                ExecID = 5
            };

            var rockendRequest = new RockendRequest();

            rockendRequest.ActionName = "";
            rockendRequest.ApplicationCode = "SM";
            rockendRequest.ApplicationKey = 270656;
            rockendRequest.BodyXml = request.SerializeToXML();
            rockendRequest.ServiceKey = 2000000;
            rockendRequest.ServicePassword = "r0ckend";
            rockendRequest.SessionID = "";

            var response = await executeSOAPRequest(rockendRequest);

            var result = response.ProcessResult.BodyAs<ExecutiveResponse>();

            return result;
        }

        [Route("api/agencyInfo")]
        public async Task<AgencyResponse> GetAgencyInfo()
        {
            var request = new AgencyRequest
            {
                ApplicationKey = 270656
            };

            var rockendRequest = new RockendRequest();

            rockendRequest.ActionName = "";
            rockendRequest.ApplicationCode = "SM";
            rockendRequest.ApplicationKey = 270656;
            rockendRequest.BodyXml = request.SerializeToXML();
            rockendRequest.ServiceKey = 2000000;
            rockendRequest.ServicePassword = "r0ckend";
            rockendRequest.SessionID = "";

            var response = await executeSOAPRequest(rockendRequest);

            var result = response.ProcessResult.BodyAs<AgencyResponse>();

            return result;
        }

        [Route("api/budgetInfo")]
        public async Task<BudgetReportResponse> GetBudgetInfo()
        {
            var request = new BudgetReportRequest
            {
                OwnerCorpOIDList = new List<int>{ 1 }
            };

            var rockendRequest = new RockendRequest();

            rockendRequest.ActionName = "";
            rockendRequest.ApplicationCode = "SM";
            rockendRequest.ApplicationKey = 270656;
            rockendRequest.BodyXml = request.SerializeToXML();
            rockendRequest.ServiceKey = 2000000;
            rockendRequest.ServicePassword = "r0ckend";
            rockendRequest.SessionID = "";

            var response = await executeSOAPRequest(rockendRequest);

            var result = response.ProcessResult.BodyAs<BudgetReportResponse>();

            return result;
        }

        private static string SerializeObject<T>(T source)
        {
            StringBuilder result = new StringBuilder();

            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (var stream = new StringWriter(result))
            {
                serializer.Serialize(stream, source);
            }

            return result.ToString();
        }

        private async Task<ProcessResponse> executeSOAPRequest(RockendRequest rockendRequest)
        {


            ProcessResponse result = null;
            try
            {

                //ChannelFactory<IRequestService> myChannelFactory = new ChannelFactory<IRequestService>(myBinding, myEndpoint);

                IRequestService client = new RequestServiceClient();//myChannelFactory.CreateChannel();

                result = await client.ProcessAsync(new ProcessRequest(rockendRequest));
            }
            catch (System.Exception e)
            {
                Console.WriteLine($"Error ${e}");
            }

            Console.WriteLine(result);

            return result;
        }
    }
}
