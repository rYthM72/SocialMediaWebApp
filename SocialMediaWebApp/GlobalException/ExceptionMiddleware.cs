using Microsoft.AspNetCore.Http.HttpResults;
using SocialMediaWebApp.Models;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SocialMediaWebApp.GlobalException
{
    public class ExceptionMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleWare> _logger;

        public ExceptionMiddleWare(RequestDelegate next, ILogger<ExceptionMiddleWare> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        public async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            string errorMessage = ex.Message;
            int statusCode = 400;
            switch (ex)
            {
            
            }
            context.Response.StatusCode = statusCode;
            await context.Response.WriteAsJsonAsync(errorMessage);
        }
    }
}

