﻿using Hangfire.Dashboard;
using KwikNesta.Infrastruture.Svc.API.Settings;
using Microsoft.AspNetCore.Http;
using System.Diagnostics.CodeAnalysis;

namespace KwikNesta.Contracts.Filters
{
    public class HangfireAuthFilter : IDashboardAuthorizationFilter
    {
        private readonly HangfireSettings _settings;

        public HangfireAuthFilter(HangfireSettings settings)
        {
            _settings = settings;
        }

        public bool Authorize([NotNull] DashboardContext context)
        {
            var httpContext = context.GetHttpContext();

            var header = httpContext.Request.Headers["Authorization"];

            if (string.IsNullOrEmpty(header))
            {
                SetResponse(httpContext);
                return false;
            }

            var authValues = System.Net.Http.Headers.AuthenticationHeaderValue.Parse(header!);

            if (!"Basic".Equals(authValues.Scheme, StringComparison.InvariantCultureIgnoreCase))
            {
                SetResponse(httpContext);
                return false;
            }

            var parameter = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(authValues.Parameter!));
            var parts = parameter.Split(':');

            var username = parts[0];
            var password = parts[1];


            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                SetResponse(httpContext);
                return false;
            }

            if (password == _settings.Password && username == _settings.UserName)
            {
                return true;
            }

            SetResponse(httpContext);
            return false;
        }

        private static void SetResponse(HttpContext httpContext)
        {
            httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
            httpContext.Response.Headers.Append("WWW-Authenticate", "Basic realm=\"Hangfire Dashboard\"");
            httpContext.Response.WriteAsync("Authentication is required");
        }
    }
}