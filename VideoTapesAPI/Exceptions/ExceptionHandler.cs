using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Models.Exceptions;

namespace VideoTapesAPI.Exceptions
{/// <summary>
 /// This class handles exceptions and returns the appropriate status code
 /// </summary>
    public static class ExceptionHandler
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            
            app.UseExceptionHandler(error =>
            {
                
                error.Run(async context =>
                {
                    var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var exception = exceptionHandlerFeature.Error;
                    var statusCode = (int) HttpStatusCode.InternalServerError;
                    
                    // handle different exceptions
                    if (exception is ResourceNotFoundException)
                    {
                        statusCode = (int) HttpStatusCode.NotFound;
                    }
                    else if (exception is ModelFormatException)
                    {
                        statusCode = (int) HttpStatusCode.PreconditionFailed;
                    }
                    else if (exception is ArgumentOutOfRangeException)
                    {
                        statusCode = (int) HttpStatusCode.BadRequest;
                    }

                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = statusCode;
                    var exmodel = new ExceptionModel
                    {
                        StatusCode = statusCode,
                        ExceptionMessage = exception.Message
                        
                    };
                    
                    await context.Response.WriteAsync(exmodel.ToString());
                });
                
            });
        }
    }
}