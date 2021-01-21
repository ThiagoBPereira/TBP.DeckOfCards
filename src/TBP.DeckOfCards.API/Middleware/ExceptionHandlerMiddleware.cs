using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using TBP.DeckOfCards.Domain.Exceptions;

namespace TBP.DeckOfCards.API.Middleware
{
    /// <summary>
    /// Implemented a middleware to handle specific exceptions
    /// </summary>
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }

        private static Task HandleException(HttpContext context, Exception ex)
        {
            if (ex is MissingCardsException)
            {
                //TODO create the viewmodel for errors
                var errorModel = new
                {
                    Errors = new List<string> { ex.Message }
                };

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                return context.Response.WriteAsJsonAsync(errorModel);
            }

            return Task.CompletedTask;
        }
    }
}
