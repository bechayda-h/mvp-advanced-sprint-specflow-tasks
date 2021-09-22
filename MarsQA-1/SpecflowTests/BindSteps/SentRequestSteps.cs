using MarsQA_1.Helpers;
using MarsQA_1.SpecflowPages.Pages;
using NUnit.Framework;
using System.Threading;
using TechTalk.SpecFlow;

namespace MarsQA_1.SpecflowTests.BindSteps
{
    [Binding]
    public class SentRequestSteps
    {
        string _title;
        string _recipient;
        string _url;

        #region Withdraw
        [When(@"user clicks Withdraw of a sent request")]
        public void WhenUserClicksWithdrawOfASentRequest()
        {
            SentRequest.ClickWithdrawButtonRow1();
        }

        [Then(@"the Status field of the sent request should change to Withdrawn")]
        public void ThenTheStatusFieldOfTheSentRequestShouldChangeToWithdrawn()
        {
            // Wait a bit
            Thread.Sleep(500);

            // Get the status
            string status = SentRequest.GetStatusRow1();

            // Log test result
            bool passCondition = "Withdrawn" == status;
            CommonMethods.LogResult(passCondition, "Withdraw Sent Request Passed", "Withdraw Sent Request Failed");

            // Assert
            Assert.AreEqual("Withdrawn", status);
        }
        #endregion

        #region Completed
        [When(@"user clicks Completed of a sent request")]
        public void WhenUserClicksCompletedOfASentRequest()
        {
            SentRequest.ClickCompletedButtonRow1();
        }

        [Then(@"the Status field of the sent request should change to Completed")]
        public void ThenTheStatusFieldOfTheSentRequestShouldChangeToCompleted()
        {
            // Wait a bit
            Thread.Sleep(500);

            // Get the status
            string status = SentRequest.GetStatusRow1();

            // Log test result
            bool passCondition = "Completed" == status;
            CommonMethods.LogResult(passCondition, "Completed Sent Request Passed", "Completed Sent Request Failed");

            // Assert
            Assert.AreEqual("Completed", status);
        }
        #endregion

        #region Review
        [Given(@"user clicks Review of a sent request")]
        public void GivenUserClicksReviewOfASentRequest()
        {
            SentRequest.ClickReviewButtonRow1();
        }

        [Given(@"user inputs a review ""(.*)""")]
        public void GivenUserInputsAReview(string review)
        {
            // Wait a bit
            Thread.Sleep(500);

            SentRequest.InputReview(review);
        }

        [Given(@"user inputs seller rating ""(.*)"", service rating ""(.*)"", and recommend rating ""(.*)""")]
        public void GivenUserInputsSellerRatingServiceRatingAndRecommendRating(string commRate , string servRate, string recoRate)
        {
            // Input ratings
            SentRequest.ClickCommunicationRating(commRate);
            SentRequest.ClickServiceRating(servRate);
            SentRequest.ClickRecommendRating(recoRate);
        }

        [When(@"user clicks Save in the Rate this Service page modal")]
        public void WhenUserClicksSaveInTheRateThisServicePageModal()
        {
            SentRequest.ClickSaveButton();
        }

        #endregion

        #region access title link
        [Given(@"user navigates to SentRequest page")]
        public void GivenUserNavigatesToSentRequestPage()
        {
            Profile.ClickSentRequests();
        }

        [When(@"user clicks the title link of a sent request")]
        public void WhenUserClicksTheTitleLinkOfASentRequest()
        {
            // Get SentRequest page service details
            _title = SentRequest.GetTitleRow1();
            _recipient = SentRequest.GetRecipientRow1();
            _url = SentRequest.GetTitleLinkRow1Url();

            SentRequest.ClickTitleLinkRow1();
        }

        [Then(@"the ServiceDetail page of the service entry should be displayed")]
        public void ThenTheServiceDetailPageOfTheServiceEntryShouldBeDisplayed()
        {
            // Wait a bit
            Thread.Sleep(1000);

            // Get ServiceDetail page details
            string serviceDetailTitle = ServiceDetail.GetTitle();
            string serviceDetailRecipient = ServiceDetail.GetName();
            string serviceDetailUrl = Driver.driver.Url;

            // Log test result
            bool passCondition = _title == serviceDetailTitle &&
                             _recipient == serviceDetailRecipient &&
                                   _url == serviceDetailUrl;
            CommonMethods.LogResult(passCondition, "Sent Request Title link Passed", "Sent Request Title link Failed");

            // Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(_title, serviceDetailTitle);
                Assert.AreEqual(_recipient, serviceDetailRecipient);
                Assert.AreEqual(_url, serviceDetailUrl);
            });
        }
        #endregion

        #region access recipient link
        [When(@"user clicks the recipient link of a sent request")]
        public void WhenUserClicksTheRecipientLinkOfASentRequest()
        {
            // Get the link url before accessing
            _url = SentRequest.GetRecipientLinkRow1Url();
            
            SentRequest.ClickRecipientLinkRow1();
        }

        [Then(@"the Profile page of the recipient should be displayed")]
        public void ThenTheProfilePageOfTheRecipientShouldBeDisplayed()
        {
            // Wait a bit
            Thread.Sleep(1000);

            // Get the actual recipient link
            string serviceDetailUrl = Driver.driver.Url;

            // Log test result
            CommonMethods.LogResult(_url == serviceDetailUrl, "Sent Request Recipient link Passed", "Sent Request Recipient link Failed");

            // Assert
            Assert.AreEqual(_url, serviceDetailUrl);
        }
        #endregion
    }
}
