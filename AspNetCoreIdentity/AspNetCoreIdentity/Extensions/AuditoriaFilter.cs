using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AspNetCoreIdentity.Extensions
{
    public class AuditoriaFilter : TypeFilterAttribute
    {
        public AuditoriaFilter() : base(typeof(SampleActionFilterImpl))
        {
        }

        private class SampleActionFilterImpl : IActionFilter
        {
            private readonly ILogger _logger;
            public SampleActionFilterImpl(ILoggerFactory loggerFactory)
            {
                _logger = loggerFactory.CreateLogger<AuditoriaFilter>();
            }

            public void OnActionExecuting(ActionExecutingContext context) { }

            public void OnActionExecuted(ActionExecutedContext context)
            {
                if (context.HttpContext.User.Identity.IsAuthenticated)
                {
                    var message = context.HttpContext.User.Identity.Name + " Acessou: " +
                                  context.HttpContext.Request.GetDisplayUrl();
                    _logger.LogInformation(message);
                }
            }
        }
    }
}
