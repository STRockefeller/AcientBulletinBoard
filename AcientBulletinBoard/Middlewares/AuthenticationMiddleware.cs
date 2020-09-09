using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AcientBulletinBoard.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace AcientBulletinBoard.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class AuthenticationMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            string path = context.Request.Path.Value.ToLower();
            if (context.Request.Method == "POST" && path.EndsWith("/Login".ToLower()))
            {
                IFormCollection form = await context.Request.ReadFormAsync();
                string account = form["account"];
                string password = form["password"];
                Services.UserData user = new Services.UserData();
                if (user.logIn(account, password))
                {
                    context.Response.Cookies.Delete("User");
                    context.Response.Cookies.Append("User", user.name);
                    Helper.setUser(user);
                    context.Response.StatusCode = 200;
                    await context.Response.WriteAsync("Authorized");
                }
                else
                {
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync("Unauthorized");
                }
            }
            else if (path.EndsWith("/Logout".ToLower()))
            {
                context.Response.Cookies.Delete("User");
                Helper.resetUser();
                context.Response.Redirect("/");
            }
            else
            {
                await next.Invoke(context);
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class AuthenticationMiddlewareExtensions
    {
        public static IApplicationBuilder UseAuthenticationMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthenticationMiddleware>();
        }
    }
}