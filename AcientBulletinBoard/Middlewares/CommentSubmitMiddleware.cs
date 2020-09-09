using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using AcientBulletinBoard.Services;

namespace AcientBulletinBoard.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class CommentSubmitMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            string path = context.Request.Path.Value.ToLower();
            if (context.Request.Method == "POST" && path.EndsWith("/CommentSubmit".ToLower()))
            {
                IFormCollection form = await context.Request.ReadFormAsync();
                string target = form["target"];
                string name = form["name"];
                string comment = form["comment"];
                BulletinBoardData bulletinBoardData = new BulletinBoardData();
                var defaultUsers = Helper.getDefaultUsers();
                if (name == Helper._userData.name)
                    bulletinBoardData.submitComment(target, Helper._userData, comment);
                else if(defaultUsers.Any(user=>user.name==name))
                    bulletinBoardData.submitComment(target, defaultUsers.Where(user=>user.name==name).Single(), comment);

                context.Response.StatusCode = 200;
            }
            else if(context.Request.Method == "POST" && path.EndsWith("/ClearBoard".ToLower()))
            {
                IFormCollection form = await context.Request.ReadFormAsync();
                string target = form["target"];
                BulletinBoardData bulletinBoardData = new BulletinBoardData();
                bulletinBoardData.clearBoard(target);
                context.Response.StatusCode = 200;
            }
            else
                await next.Invoke(context);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class CommentSubmitMiddlewareExtensions
    {
        public static IApplicationBuilder UseCommentSubmitMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CommentSubmitMiddleware>();
        }
    }
}