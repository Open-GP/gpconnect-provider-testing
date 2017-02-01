﻿// ReSharper disable ClassNeverInstantiated.Global
namespace GPConnect.Provider.AcceptanceTests.Constants
{
    internal static class HttpConst
    {
        internal static class ContentTypes
        {
            public const string kJson = "application/json";
            public const string kXml = "application/xml";
        }

        internal static class Headers
        {
            public const string kAccept = "Accept";
            public const string kAuthorization = "Authorization";
            public const string kSspFrom = "Ssp-From";
            public const string kSspTo = "Ssp-To";
            public const string kSspInteractionId = "Ssp-InteractionId";
            public const string kSspTraceId = "Ssp-TraceID";
            public const string kContentType = "Content-Type";
            public const string kAcceptEncoding = "Accept-Encoding";
            public const string kContentEncoding = "Content-Encoding";
        }
    }
}
