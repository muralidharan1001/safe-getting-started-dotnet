﻿using System;

namespace SafeTodoExample.Helpers
{
    public static class UrlFormat
    {
        public static string Format(string appId, string encodedString, bool toAuthenticator)
        {
            string scheme = toAuthenticator ? "safe-auth" : $"{appId}";
            return $"{scheme}://{appId}/{encodedString}";
        }

        public static string GetRequestData(string url)
        {
            return new Uri(url).PathAndQuery.Replace("/", string.Empty);
        }
    }
}
