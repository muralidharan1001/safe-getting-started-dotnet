﻿using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Foundation;
using UIKit;
using UnitTests.HeadlessRunner;
using Xunit.Runner;

namespace SafetodoExample.Tests.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : RunnerAppDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            // Invoke the headless test runner if a config was specified
            var testCfg = System.IO.File.ReadAllText("tests.cfg")?.Split(':');
            if (testCfg != null && testCfg.Length > 1)
            {
                var ip = testCfg[0];
                if (int.TryParse(testCfg[1], out var port))
                {
                    // Run the headless test runner for CI
                    Task.Run(() =>
                    {
                        return UnitTests.HeadlessRunner.Tests.RunAsync(new TestOptions
                        {
                            Assemblies = new List<Assembly> { Assembly.GetExecutingAssembly() },
                            NetworkLogHost = ip,
                            NetworkLogPort = port,
                            Format = TestResultsFormat.NUnit
                        });
                    });
                }
            }

            // tests can be inside the main assembly
            AddTestAssembly(Assembly.GetExecutingAssembly());

            // otherwise you need to ensure that the test assemblies will
            // become part of the app bundle
            //    AddTestAssembly(typeof(PortableTests).Assembly);

#if false
            // you can use the default or set your own custom writer (e.g. save to web site and tweet it ;-)
            Writer = new TcpTextWriter("10.0.1.2", 16384);
            // start running the test suites as soon as the application is loaded
            AutoStart = true;
            // crash the application (to ensure it's ended) and return to springboard
            TerminateAfterExecution = true;
#endif
            return base.FinishedLaunching(app, options);
        }
    }
}
