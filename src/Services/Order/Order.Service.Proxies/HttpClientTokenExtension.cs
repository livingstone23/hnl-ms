using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Order.Service.Proxies
{
    /// <summary>
    /// Permite acceder al request para lectura del valor e inyectar en httpclient para que adicione el token
    /// Funcion muy importante para que funcion order una vez habilitada la seguridad
    /// </summary>
    public static class HttpClientTokenExtension
    {
        public static void AddBearerToken(this HttpClient client, IHttpContextAccessor context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated && context.HttpContext.Request.Headers.ContainsKey("Authorization"))
            {
                var token = context.HttpContext.Request.Headers["Authorization"].ToString();

                if (!string.IsNullOrEmpty(token))
                {
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", token);
                }
            }
        }
    }
}
