﻿namespace Microservices.WebMVC.Infrastructure
{
    using System;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    public class HttpClientRequestIdDelegatingHandler
       : DelegatingHandler
    {

        public HttpClientRequestIdDelegatingHandler()
        {
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.Method == HttpMethod.Post || request.Method == HttpMethod.Put)
            {
                request.Headers.Add("x-requestid", Guid.NewGuid().ToString());
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
