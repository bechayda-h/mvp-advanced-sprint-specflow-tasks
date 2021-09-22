using MarsQA_1.Helpers;
using MarsQA_1.SpecflowPages.Pages;
using NUnit.Framework;
using System.Threading;
using TechTalk.SpecFlow;

namespace MarsQA_1.SpecflowTests.BindSteps
{
    [Binding]
    class ReceivedRequestSteps
    {
        private string _title;
        private string _url;

        #region Accept
        [When(@"user clicks Accept of a received request")]
        public void WhenUserClicksAcceptOfAReceivedRequest()
        {
            ReceivedRequest.ClickAcceptButtonRow1();
        }

        [Then(@"the received request status will become Accepted")]
        public void ThenTheReceivedRequestStatusWillBecomeAccepted()
        {
            // Wait until popup message disappears
            Thread.Sleep(5000);

            // Get status
            string status = ReceivedRequest.GetStatusRow1();

            // Log test result
            CommonMethods.LogResult("Accepted" == status, "Accept Received Request Passed", "Accept Received Request Failed");

            // Assert
            Assert.AreEqual("Accepted", status);
        }
        #endregion

        #region Decline
        [When(@"user clicks Decline of a received request")]
        public void WhenUserClicksDeclineOfAReceivedRequest()
        {
            ReceivedRequest.ClickDeclineButtonRow1();
        }

        [Then(@"the received request status will become Declined")]
        public void ThenTheReceivedRequestStatusWillBecomeDeclined()
        {
            // Wait until popup message disappears
            Thread.Sleep(5000);

            // Get status
            string status = ReceivedRequest.GetStatusRow1();

            // Log test result
            CommonMethods.LogResult("Declined" == status, "Decline Received Request Passed", "Decline Received Request Failed");

            // Assert
            Assert.AreEqual("Declined", status);
        }
        #endregion

        #region Complete
        [When(@"user clicks Complete of a received request")]
        public void WhenUserClicksCompleteOfAReceivedRequest()
        {
            ReceivedRequest.ClickCompleteButtonRow1();
        }

        [Then(@"the sender rating should be displayed")]
        public void ThenTheSenderRatingShouldBeDisplayed()
        {
            // Is sender rating displayed
            bool isSenderRatingDisplayed = ReceivedRequest.IsSenderRatingRow1Displayed();

            // Log test result
            CommonMethods.LogResult(isSenderRatingDisplayed, "Complete Received Request Passed", "Complete Received Request Failed");

            // Assert
            Assert.IsTrue(isSenderRatingDisplayed);
        }
        #endregion

        #region access title link
        [Given(@"user navigates to ReceivedRequest page")]
        public void GivenUserNavigatesToReceivedRequestPage()
        {
            Profile.ClickReceivedRequests();
        }

        [When(@"user clicks the title link of a received request")]
        public void WhenUserClicksTheTitleLinkOfAReceivedRequest()
        {
            // Get ReceivedRequest page service details
            _title = ReceivedRequest.GetTitleRow1();
            _url = ReceivedRequest.GetTitleLinkRow1Url();
            
            ReceivedRequest.ClickTitleLinkRow1();
        }

        [Then(@"the ServiceDetail page of the service entry from ReceivedRequest page should be displayed")]
        public void ThenTheServiceDetailPageOfTheServiceEntryFromReceivedRequestPageShouldBeDisplayed()
        {
            // Wait a bit
            Thread.Sleep(1000);

            // Get ServiceDetail page details
            string serviceDetailTitle = ServiceDetail.GetTitle();
            string serviceDetailUrl = Driver.driver.Url;

            // Log test result
            bool passCondition = _title == serviceDetailTitle && _url == serviceDetailUrl;
            CommonMethods.LogResult(passCondition, "Received Request Title link Passed", "Received Request Title link Failed");

            // Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(_title, serviceDetailTitle);
                Assert.AreEqual(_url, serviceDetailUrl);
            });
        }
        #endregion

        #region access sender link
        [When(@"user clicks the sender link of a received request")]
        public void WhenUserClicksTheSenderLinkOfAReceivedRequest()
        {
            // Get the sender link
            _url = ReceivedRequest.GetSenderLinkRow1Url();

            ReceivedRequest.ClickSenderLinkRow1();
        }

        [Then(@"the Profile page of the sender should be displayed")]
        public void ThenTheProfilePageOfTheSenderShouldBeDisplayed()
        {
            // Wait a bit
            Thread.Sleep(1000);

            // Get the actual sender link
            string serviceDetailUrl = Driver.driver.Url;

            // Log test result
            CommonMethods.LogResult(_url == serviceDetailUrl, "Received Request Sender link Passed", "Received Request Sender link Failed");

            // Assert
            Assert.AreEqual(_url, serviceDetailUrl);
        }
        #endregion
    }
}
