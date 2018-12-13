﻿using Foundation;
using NUnit.Runner.Services;
using System.IO;
using System.Linq;
using UIKit;

namespace NUnit.Runner.Tests
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        private readonly string _tcpListenHost = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList
            .First(f => f.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).ToString();

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            // This will load all tests within the current project
            var nunit = new App
            {

                // If you want to add tests in another assembly
                //nunit.AddTestAssembly(typeof(MyTests).Assembly);

                // Available options for testing
                Options = new TestOptions
                {
                    // If True, the tests will run automatically when the app starts
                    // otherwise you must run them manually.
                    AutoRun = true,

                    // If True, the application will terminate automatically after running the tests.
                    //TerminateAfterExecution = true,

                    // Information about the tcp listener host and port.
                    // For now, send result as XML to the listening server.
                    TcpWriterParameters = new TcpWriterInfo(_tcpListenHost  , 10500),

                    // Creates a NUnit Xml result file on the host file system using PCLStorage library.
                    // CreateXmlResultFile = true,

                    // Choose a different path for the xml result file (ios file share / library directory)
                    // ResultFilePath = Path.Combine(NSFileManager.DefaultManager.GetUrls(NSSearchPathDirectory.LibraryDirectory, NSSearchPathDomain.User)[0].Path, "Results.xml")
                }
            };

            LoadApplication(nunit);

            return base.FinishedLaunching(app, options);
        }
    }
}
