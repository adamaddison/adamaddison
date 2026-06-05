using System;

namespace adamaddison.Middleware;

public class AccessControlMiddleware
{
    private readonly string AccessToken;
    private readonly RequestDelegate _next;

    public AccessControlMiddleware(RequestDelegate next, IConfiguration config)
    {
        _next = next;
        AccessToken = config["aaAccessToken"] ?? string.Empty;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var queryParameter = context.Request.Query["k"].ToString();

        // If the query parameter contains the access token then set cookie with that token and give access
        if(!string.IsNullOrEmpty(queryParameter) && string.Equals(queryParameter, AccessToken, StringComparison.Ordinal))
        {
            context.Response.Cookies.Append("aa-access-token", AccessToken, new CookieOptions()
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict
            });

            await _next(context);
            return;
        }

        // If there is no query parameter but an access token cookie was previously set then give access
        var cookie = context.Request.Cookies["aa-access-token"];
        if(string.Equals(cookie, AccessToken, StringComparison.Ordinal))
        {
            await _next(context);
            return;
        }

        // If there is no cookie or query parameter access token then deny access
        context.Response.StatusCode = StatusCodes.Status410Gone;
    }
}