// // Copyright (c) Duende Software. All rights reserved.
// // See LICENSE in the project root for license information.

using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace Duende.Bff.Yarp
{
    /// <summary>
    /// Extensions methods to wire up BFF-enhanced YARP
    /// </summary>
    public static class ReverseProxyEndpointConventionBuilderExtensions
    {
        /// <summary>
        /// Adds YARP with anti-forgery protection
        /// </summary>
        /// <param name="endpoints"></param>
        /// <param name="configureAction"></param>
        /// <param name="requireAntiforgeryCheck"></param>
        /// <returns></returns>
        public static ReverseProxyConventionBuilder MapBffReverseProxy(this IEndpointRouteBuilder endpoints,
            Action<IReverseProxyApplicationBuilder> configureAction,
            bool requireAntiforgeryCheck = true)
        {
            return endpoints.MapReverseProxy(configureAction)
                .AsBffApiEndpoint(requireAntiforgeryCheck);
        }

        /// <summary>
        /// Adds YARP with anti-forgery protection 
        /// </summary>
        /// <param name="endpoints"></param>
        /// <param name="requireAntiforgeryCheck"></param>
        /// <returns></returns>
        public static ReverseProxyConventionBuilder MapBffReverseProxy(this IEndpointRouteBuilder endpoints,
            bool requireAntiforgeryCheck = true)
        {
            return endpoints.MapReverseProxy()
                .AsBffApiEndpoint(requireAntiforgeryCheck);
        }
        
        /// <summary>
        /// Adds anti-forgery protection to YARP
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="requireAntiforgeryCheck"></param>
        /// <returns></returns>
        public static ReverseProxyConventionBuilder AsBffApiEndpoint(this ReverseProxyConventionBuilder builder,
            bool requireAntiforgeryCheck = true)
        {
            return builder.WithMetadata(new BffApiAttribute(requireAntiforgeryCheck));
        }
    }
}