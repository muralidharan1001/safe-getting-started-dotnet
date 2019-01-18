using SafeApp;
#if SAFE_APP_MOCK
using SafeApp.MockAuthBindings;
#endif
using System;
using System.Threading.Tasks;
using SafeApp.Utilities;
using SharedDemoCode;

namespace App.Network
{
    public class Authentication
    {
#if SAFE_APP_MOCK
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public static async Task<Session> MockAuthenticationAsync()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            try
            {
                // Create a mock safe account to perform authentication.
                // We use this method while developing the app or working with tests.
                // This way we don't have to authenticate using safe-browser.

                // Generating random credentials
                // Insert "Create a mock account" here

                // Insert "Authentication and Logging" here

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                throw ex;
            }
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public static async Task MockAuthenticationWithBrowserAsync()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            try
            {
                // Send request to mock safe-browser for authentication.
                // Use a mock account credentials in safe-browser and authenticate using the same.
                Console.WriteLine("Requesting authentication from mock Safe browser");

                // Insert "Send AuthReq to the Authenticator" here
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                throw ex;
            }
        }
#else
        public static async Task NonMockAuthenticationWithBrowserAsync()
        {
            try
            {
                // Send request to safe-browser for authentication.
                // Login in safe-browser to authenticate.
                Console.WriteLine("Requesting authentication from Safe browser");
                var encodedReq = await Helpers.GenerateEncodedAppRequestAsync();
                var url = Helpers.UrlFormat(encodedReq.Item2, true);
                System.Diagnostics.Process.Start(url);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                throw ex;
            }
        }
#endif

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public static async Task ProcessAuthenticationResponse(string authResponse)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            try
            {
                // Insert "Grant access" here
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }
    }
}
