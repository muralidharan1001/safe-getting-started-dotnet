﻿using Acr.UserDialogs;
using Android.App;
using Android.Content.PM;
using Android.OS;
using NUnit.Runner.Services;
using Xamarin.Forms;

namespace SafetodoExample.Tests.Android
{
    [Activity(Name = "net.maidsafe.SafetodoExampleTests.MainActivity", Label = "NUnit", Icon = "@drawable/icon", Theme = "@android:style/Theme.Holo.Light", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Rg.Plugins.Popup.Popup.Init(this, savedInstanceState);
            UserDialogs.Init(this);
            Forms.Init(this, savedInstanceState);

            // This will load all tests within the current project
            var nunit = new NUnit.Runner.App
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
                    TcpWriterParameters = new TcpWriterInfo("10.0.2.2", 10500),

                    // Creates a NUnit Xml result file on the host file system using PCLStorage library.
                    // CreateXmlResultFile = true,

                    // Choose a different path for the xml result file
                    // ResultFilePath = Path.Combine(Environment.ExternalStorageDirectory.Path, Environment.DirectoryDownloads, "Nunit", "Results.xml")
                }
            };

            LoadApplication(nunit);
        }
    }
}

