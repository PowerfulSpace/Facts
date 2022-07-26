using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerfulSpace.Facts.Web.Extensions
{
    public static class HttpContextExtensions
    {


        public static string GetReturnUrl(this HttpContext source) =>
            string.IsNullOrWhiteSpace(source.Request.Path)
                ? "~/"
                : $"~{source.Request.Path.Value}{source.Request.QueryString}";


        public static string BaseUrl(this IUrlHelper helper) =>
            $"{helper.ActionContext.HttpContext.Request.Scheme}://{helper.ActionContext.HttpContext.Request.Host.ToUriComponent()}";


        public static string FulUrl(this IUrlHelper helper, string virtualPath) =>
            $"{helper.ActionContext.HttpContext.Request.Scheme}://{helper.ActionContext.HttpContext.Request.Host.ToUriComponent()}{helper.Content(virtualPath)}";

    }
}
