using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WireMock
{
    using System.Net;
    using RequestBuilders;
    using ResponseBuilders;
    using Util;

    class Program
    {
        static void Main(string[] args)
        {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            Console.WriteLine("Hello World!");

            MockServer.Initialize();
            MockServer.ArrangeResponseForRequest(Request.Create().WithPath("/ping").UsingGet(),
                Response.Create().WithCallback(GetResponse));


            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }

        private static ResponseMessage GetResponse(RequestMessage request)
        {
            var response = new ResponseMessage
            {
                StatusCode = (int)HttpStatusCode.OK,
                BodyData = new BodyData
                {
                    DetectedBodyType = BodyType.Json,
                    BodyAsJsonIndented = false,
                    BodyAsJson = new { message = "hello" }
                }
            };

            response.AddHeader("Content-Type", "application/json");
            return response;
        }
    }
}
