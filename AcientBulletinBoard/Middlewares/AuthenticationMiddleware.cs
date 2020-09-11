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
                    Helper.SetUser(user);
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
                Helper.ResetUser();
                context.Response.Redirect("/");
            }
            if (context.Request.Method == "POST" && path.EndsWith("/SignUp".ToLower()))
            {
                IFormCollection form = await context.Request.ReadFormAsync();
                UserData user = new UserData();
                user.account = form["account"];
                user.password = form["password"];
                user.emailAddress = form["emailAddress"];
                user.name = form["name"];
                user.role = enumRole.normal;
                switch(form["camp"])
                {
                    case "Wei":
                        user.camp = enumCamp.Wei;
                        break;
                    case "Shu":
                        user.camp = enumCamp.Shu;
                        break;
                    case "Wu":
                        user.camp = enumCamp.Wu;
                        break;
                    case "Neutral":
                        user.camp = enumCamp.Neutral;
                        break;
                    case "God":
                        user.camp = enumCamp.God;
                        break;
                    case "Foreign":
                        user.camp = enumCamp.Foreign;
                        break;
                }
                if (Helper.IsValidEmail(user.emailAddress))
                    Helper.CreateUser(user);
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