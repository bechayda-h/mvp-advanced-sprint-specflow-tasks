using MarsQA_1.Helpers;
using MarsQA_1.SpecflowPages.Pages;
using NUnit.Framework;
using System.Threading;
using TechTalk.SpecFlow;

namespace MarsQA_1.Feature
{
    [Binding]
    public class ListingManagementSteps
    {
        private string _title;

        #region Edit Service Entry
        [Given(@"user clicks Manage Listings")]
        public void GivenUserClicksManageListings()
        {
            Profile.ClickManageListings();
        }
   
        [Given(@"user clicks the write icon of a service entry")]
        public void GivenUserClicksTheWriteIconOfAServiceEntry()
        {
            ListingManagement.ClickWriteIconRow1();
        }

        [Given(@"user updates the service entry details with '(.*)', '(.*)', '(.*)', '(.*)', and '(.*)'")]
        public void GivenUserUpdatesTheServiceEntryDetailsWithAnd(string title, string description, string category, string subcategory, string servicetype)
        {
            ServiceListing.InputTitle(title);
            ServiceListing.InputDescription(description);
            ServiceListing.SelectCategory(category);
            ServiceListing.SelectSubCategory(subcategory);
            ServiceListing.SelectServiceType(servicetype);
        }

        [Then(@"the '(.*)', '(.*)', '(.*)', and '(.*)' of the service entry will be updated in ListingManagement page")]
        public void ThenTheAndOfTheServiceEntryWillBeUpdatedInListingManagementPage(string category, string title, string description, string servicetype)
        {
            // Get actual values
            string actualCategory = ListingManagement.GetCategoryRow1();
            string actualTitle = ListingManagement.GetTitleRow1();
            string actualDescription = ListingManagement.GetDescriptionRow1();
            string actualServiceType = ListingManagement.GetServiceTypeRow1();

            // Log test result
            bool passCondition = category == actualCategory &&
                                    title == actualTitle &&
                              description == actualDescription &&
                              servicetype == actualServiceType;
            CommonMethods.LogResult(passCondition, "Edit service entry Passed", "Edit service entry Failed");

            // Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(category, actualCategory);
                Assert.AreEqual(title, actualTitle);
                Assert.AreEqual(description, actualDescription);
                Assert.AreEqual(servicetype, actualServiceType);
            });
        }
        #endregion

        #region Remove Service Entry
        [Given(@"user clicks the remove icon")]
        public void GivenUserClicksTheRemoveIcon()
        {
            // Get the title before deleting
            _title = ListingManagement.GetTitleRow1();

            ListingManagement.ClickRemoveIconRow1();
        }

        [When(@"user clicks Yes in the page modal")]
        public void WhenUserClicksYesInThePageModal()
        {
            ListingManagement.ClickPageModalYesButton();
        }

        [Then(@"a service has been deleted message will appear")]
        public void ThenAServiceHasBeenDeletedMessageWillAppear()
        {
            // Wait a bit
            Thread.Sleep(500);
            
            // Get popup message
            string popupMessage = ListingManagement.GetPopupMessage();

            // Set expected message
            string expectedMessage = $"{_title} has been deleted";

            // Log test result
            CommonMethods.LogResult(expectedMessage == popupMessage, "Service entry deleted", "Service entry not deleted");

            // Assert
            Assert.AreEqual(expectedMessage, popupMessage);
        }
        #endregion
    }
}