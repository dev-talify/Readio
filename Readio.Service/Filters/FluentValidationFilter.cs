﻿

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Readio.Core.Model.Response;

namespace Readio.Service.Filters;

public class FluentValidationFilter : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (!context.ModelState.IsValid)
        {
            var errors = context.ModelState.Values
                .SelectMany(e => e.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();

            var resultModel = OperationResponse.Fail(errors);
            context.Result = new BadRequestObjectResult(resultModel);
            return;
        }
        await next();
    }
}
