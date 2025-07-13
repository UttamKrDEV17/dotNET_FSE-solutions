using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;

namespace WebApiHandson.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            // Create log entry
            var logEntry = new StringBuilder();
            logEntry.AppendLine($"Exception occurred at: {DateTime.Now}");
            logEntry.AppendLine($"Exception Type: {context.Exception.GetType().Name}");
            logEntry.AppendLine($"Exception Message: {context.Exception.Message}");
            logEntry.AppendLine($"Stack Trace: {context.Exception.StackTrace}");
            logEntry.AppendLine($"Request Path: {context.HttpContext.Request.Path}");
            logEntry.AppendLine($"Request Method: {context.HttpContext.Request.Method}");
            logEntry.AppendLine(new string('-', 50));

            // Write to file
            var logPath = Path.Combine(Directory.GetCurrentDirectory(), "exception_log.txt");
            File.AppendAllText(logPath, logEntry.ToString());

            // Set response
            context.Result = new ObjectResult("An internal server error occurred")
            {
                StatusCode = 500
            };

            context.ExceptionHandled = true;
        }
    }
}
