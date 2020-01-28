using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using TimeToSpeech.Application;

namespace TimeToSpeech.Functions
{
    public static class TimeToSpeechApi
    {
        [FunctionName("TimeToSpeech")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req)
        {
            var time = req.Query.ContainsKey("time") ? req.Query["time"].ToString() : DateTime.Now.ToString("hh:mm");
            var timeAsSpeech = new WrittenTimeProcessor().Process(time);

            return !timeAsSpeech.StartsWith("Invalid")
                ? (ActionResult)new OkObjectResult(timeAsSpeech)
                : new BadRequestObjectResult(timeAsSpeech);
        }
    }
}
