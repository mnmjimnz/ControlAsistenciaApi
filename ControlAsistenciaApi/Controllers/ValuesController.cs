using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;

namespace ControlAsistenciaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly EndpointDataSource _endpointDataSource;

        public ValuesController(EndpointDataSource endpointDataSource)
        {
            _endpointDataSource = endpointDataSource;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var endpoints = _endpointDataSource.Endpoints
                .OfType<RouteEndpoint>()
                .Select(endpoint =>
                {
                    var controllerActionDescriptor =
                        endpoint.Metadata.GetMetadata<ControllerActionDescriptor>();

                    var methods = endpoint.Metadata
                        .OfType<HttpMethodAttribute>()
                        .SelectMany(m => m.HttpMethods)
                        .Distinct();

                    return new
                    {
                        Route = endpoint.RoutePattern.RawText,
                        Methods = methods,
                        Controller = controllerActionDescriptor?.ControllerName,
                        Action = controllerActionDescriptor?.ActionName
                    };
                })
                .OrderBy(e => e.Route)
                .ToList();

            return Ok(endpoints);
        }
    }
}
