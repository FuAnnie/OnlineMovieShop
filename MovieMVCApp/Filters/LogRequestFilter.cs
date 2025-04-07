using Microsoft.AspNetCore.Mvc.Filters;

namespace MovieMVCApp.Filters;

public class LogRequestFilter: IActionFilter
{
    private readonly ILogger<LogRequestFilter> logger;

    public LogRequestFilter(ILogger<LogRequestFilter> logger)
    {
        this.logger = logger;
    }


    public void OnActionExecuting(ActionExecutingContext context)
    {
        var actionName = context.ActionDescriptor.DisplayName;
        var controllerName = context.Controller.GetType().Name;
        var requestUrl = context.HttpContext.Request.Path;
        var requestMethod = context.HttpContext.Request.Method;
            
        logger.LogInformation($"Request to {controllerName}/{actionName} - {requestMethod} {requestUrl} at {DateTime.Now}");
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Exception == null)
        {
            logger.LogInformation($"Action executed successfully.");
        }
        else
        {
            logger.LogError($"An error occurred while executing the action: {context.Exception.Message}");
        }
    }
}