
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;

namespace Tba.Sql
{
    public class WidgetsApi
    {
        private const string ApiName = "widgets";
        private readonly IWidgetRepository _widgetRepository;

        public WidgetsApi(IWidgetRepository widgetRepository)
        {
            _widgetRepository = widgetRepository;
        }

        [FunctionName(ApiName + "-get")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = ApiName + "/widgetId?")] HttpRequest req,
            string widgetId)
        {
            var result = await _widgetRepository.GetWidget(widgetId);
            return new OkObjectResult(result); 
        }
    }
}

