using JShop.Api.Models;
using JShop.Infrastructure.Exceptions;
using System.Net.Mime;

namespace JShop.Api.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            List<string> errors = new List<string>();
            try
            {
                context.Response.Headers.ContentType = "application/json";
                await next.Invoke(context);
            }
            catch (ValidationException e)
            {
                int statusCode = 400;
                context.Response.StatusCode = statusCode;

                foreach (var error in e.Errors)
                {
                    errors.Add(error.ToString());
                }

                var response = new ErrorResponse(statusCode, errors).ToString();

                await context.Response.WriteAsync(response);
            }
            catch (UserNotValidException e)
            {
                int statusCode = 403;
                context.Response.StatusCode = statusCode;

                errors.Add(e.Message);

                var response = new ErrorResponse(statusCode, errors).ToString();

                await context.Response.WriteAsync(response);
            }
            catch(UserRegisterException e)
            {
                int statusCode = 400;
                context.Response.StatusCode = statusCode;

                errors.Add(e.Message);

                var response = new ErrorResponse(statusCode, errors).ToString();

                await context.Response.WriteAsync(response);
            }
            catch(BadPasswordException e)
            {
                int statusCode = 401;
                context.Response.StatusCode = statusCode;

                errors.Add(e.Message);

                var response = new ErrorResponse(statusCode, errors).ToString();

                await context.Response.WriteAsync(response);
            }
            catch(NotFoundException e)
            {
                int statusCode = 404;
                context.Response.StatusCode = statusCode;

                errors.Add(e.Message);

                var response = new ErrorResponse(statusCode, errors).ToString();

                await context.Response.WriteAsync(response);
            }
            catch (Exception)
            {
                var statusCode = 500;
                context.Response.StatusCode = statusCode;
                errors.Add("Something went wrong, please try again soon.");

                var response = new ErrorResponse(statusCode, errors).ToString();

                await context.Response.WriteAsync(response);
            }
        }
    }
}
