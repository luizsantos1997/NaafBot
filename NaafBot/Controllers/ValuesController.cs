using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IBM.Cloud.SDK.Core.Authentication.Iam;
using IBM.Cloud.SDK.Core.Http;
using IBM.Watson.Assistant.v2;
using IBM.Watson.Assistant.v2.Model;
using Microsoft.AspNetCore.Mvc;

namespace NaafBot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        public IamAuthenticator authenticator;
        public AssistantService assistant;
        public  DetailedResponse<SessionResponse> session;
        
        public ValuesController()
        {
            authenticator = new IamAuthenticator(
                apikey: "9YDQZj58_EAexMTol16xNlmzEAAjAXJuEcK8iBkmAJY9"
                );
            assistant = new AssistantService("2019-02-28", authenticator);

            session = assistant.CreateSession(
                assistantId: "b5b2f398-3741-40ea-a87f-36538b94773f");
            assistant.SetServiceUrl("https://gateway.watsonplatform.net/assistant/api");
        }
        // GET api/values
        [HttpGet]
        public async Task<ActionResult> Get(string text)
        {
            try
            {
                var result = assistant.Message(
                    assistantId: "b5b2f398-3741-40ea-a87f-36538b94773f",
                    sessionId: session.Result.SessionId,
                    input: new MessageInput()
                    {
                    Text = text
                    }
                );
                var jsonresult = new JsonResult(result.Result);
                if(result.Response.Contains("não sei"))
                {
                   await QuestionsController.NewQuestion(text);
                }
                return Ok(jsonresult);
            }
            catch (Exception e)
            {
                return NotFound(e);

            }
        }

        
    }
}
