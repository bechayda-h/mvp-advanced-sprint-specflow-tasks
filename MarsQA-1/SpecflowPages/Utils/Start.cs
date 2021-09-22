﻿using MarsQA_1.Helpers;
using MarsQA_1.Pages;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;
using static MarsQA_1.Helpers.CommonMethods;

namespace MarsQA_1.Utils
{
    [Binding]
    public class Start : Driver
    {

        [BeforeScenario]
        public void Setup()
        {
            // launch the browser
            Initialize();
            
            // go to Home page
            NavigateUrl();

            // Initialize Report logging
            CommonMethods.ExtentReports();
        }

        [AfterScenario]
        public void TearDown()
        {           
            // Screenshot
            string img = SaveScreenShotClass.SaveScreenshot(driver, "Report");
            test.Log(LogStatus.Info, "Snapshot Path: " + test.AddScreenCapture(Path.GetFullPath(img)));

            // Close the browser
            Close();
             
            // end test. (Reports)
            Extent.EndTest(test);
            
            // calling Flush writes everything to the log file (Reports)
            Extent.Flush();
           

        }
    }
}
