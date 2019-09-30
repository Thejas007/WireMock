using System;

namespace WireMock
{
    using RequestBuilders;
    using ResponseBuilders;
    using Server;
    using Settings;

    public class MockServer
    {
        private static FluentMockServer _mockServer;

        private static string _url;

        private MockServer()
        {
            // This method is intentionally left blank
        }

        public static FluentMockServer Server
        {
            get
            {
                if (_mockServer == null)
                {
                    Initialize();
                }
                return _mockServer;
            }
        }

        public static void Initialize()
        {
            if (_mockServer == null)
            {
                _mockServer = FluentMockServer.Start(new FluentMockServerSettings()
                {
                    Urls = new[] { new UriBuilder("http", "localhost", 6000).ToString() },
                    StartAdminInterface = true,
                    ReadStaticMappings = true,
                });

                _url = new UriBuilder("http", "localhost", 6000).ToString();
            }
        }

        public static string GetMockServerUrl()
        {
            return _url;
        }

        public static void ArrangeResponseForRequest(IRequestBuilder expectedRequest, IResponseBuilder expectedResponse)
        {

            // Add the request match pattern with the correlation Id
            //expectedRequest.WithHeader(CORRELATION_LOOKUP_KEY, correlationId);

            Server.Given(expectedRequest)
                .RespondWith(expectedResponse);
        }
    }
}
