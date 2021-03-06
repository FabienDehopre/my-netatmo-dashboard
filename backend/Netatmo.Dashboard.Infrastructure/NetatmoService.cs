﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Netatmo.Dashboard.Application.Interfaces;
using Netatmo.Dashboard.Application.Netatmo.DTOs;
using Netatmo.Dashboard.Infrastructure.Options;

namespace Netatmo.Dashboard.Infrastructure
{
    public class NetatmoService : INetatmoService
    {
        private readonly HttpClient httpClient;
        private readonly IOptionsMonitor<NetatmoOptions> options;
        private readonly RNGCryptoServiceProvider rng;

        public NetatmoService(HttpClient httpClient, IOptionsMonitor<NetatmoOptions> options)
        {
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            this.options = options ?? throw new ArgumentNullException(nameof(options));
            rng = new RNGCryptoServiceProvider();
            this.httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public AuthorizeUrlDto BuildAuthorizationUrl(string returnUrl)
        {
            var state = GenerateRandomString(32);
            return new AuthorizeUrlDto { Url = $"https://api.netatmo.com/oauth2/authorize?client_id={options.CurrentValue.ClientId}&redirect_uri={WebUtility.UrlEncode(returnUrl)}&scope=read_station&state={state}", State = state };
        }

        public async Task<AuthorizationDto> ExchangeCodeForAccessToken(ExchangeCodeDto exchangeCode, CancellationToken cancellationToken = default)
        {
            var data = new Dictionary<string, string>
            {
                { "grant_type", "authorization_code" },
                { "client_id", options.CurrentValue.ClientId },
                { "client_secret", options.CurrentValue.ClientSecret },
                { "code", exchangeCode.Code },
                { "redirect_uri", exchangeCode.ReturnUrl },
                { "scope", "read_station" }
            };
            httpClient.DefaultRequestHeaders.Authorization = null;
            using (var response = await httpClient.PostAsync("https://api.netatmo.com/oauth2/token", new FormUrlEncodedContent(data), cancellationToken))
            {
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsAsync<AuthorizationDto>(cancellationToken);
            }
        }

        public async Task<AuthorizationDto> RefreshToken(string refreshToken, CancellationToken cancellationToken = default)
        {
            var nameValueCollection = new Dictionary<string, string>
            {
                { "grant_type", "refresh_token" },
                { "client_id", options.CurrentValue.ClientId },
                { "client_secret", options.CurrentValue.ClientSecret },
                { "refresh_token", refreshToken }
            };
            httpClient.DefaultRequestHeaders.Authorization = null;
            using (var response = await httpClient.PostAsync("https://api.netatmo.com/oauth2/token", new FormUrlEncodedContent(nameValueCollection), cancellationToken))
            {
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsAsync<AuthorizationDto>(cancellationToken);
            }
        }

        public async Task<WeatherDataDto> GetStationData(string accessToken, CancellationToken cancellationToken = default)
        {
            var nameValueCollection = new Dictionary<string, string>
            {
                { "access_token", accessToken }
            };
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            using (var response = await httpClient.PostAsync("https://api.netatmo.com/api/getstationsdata", new FormUrlEncodedContent(nameValueCollection), cancellationToken))
            {
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsAsync<WeatherDataDto>(cancellationToken);
            }
        }

        private string GenerateRandomString(int length)
        {
            var buffer = new byte[length * 2];
            rng.GetNonZeroBytes(buffer);
            return Convert.ToBase64String(buffer).Replace("/", "").Replace("+", "").Replace("=", "").Substring(0, length);
        }
    }
}
