using MarsQA_1.Helpers;
using MarsQA_1.SpecflowPages.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace MarsQA_1.SpecflowTests.BindSteps
{
    [Binding]
    public class ServiceListingSteps
    {
        [Given(@"user clicks Share Skill button")]
        public void GivenUserClicksShareSkillButton()
        {
            Profile.ClickShareSkillButton();
        }

        [Given(@"user inputs skill details: '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)'")]
        public void GivenUserInputsSkillDetails(string title, string description, string category, string subcategory, string tag, string servicetype, string skillexchange)
        {
            ServiceListing.InputTitle(title);
            ServiceListing.InputDescription(description);
            ServiceListing.SelectCategory(category);
            ServiceListing.SelectSubCategory(subcategory);
            ServiceListing.EnterTag(tag);
            ServiceListing.SelectServiceType(servicetype);
            ServiceListing.EnterSkillExchangeTag(tag);
        }

        [When(@"user clicks the Save button in ServiceListing page")]
        public void WhenUserClicksTheSaveButtonInServiceListingPage()
        {
            ServiceListing.ClickSaveButton();
        }

        [Then(@"the skill details '(.*)', '(.*)', '(.*)', '(.*)' will be listed on top in the ListingManagement page")]
        public void ThenTheSkillDetailsWillBeListedOnTopInTheListingManagementPage(string category, string title, string description, string serviceType)
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
                              serviceType == actualServiceType;
            CommonMethods.LogResult(passCondition, "Add Service Entry Passed", "Add Service Entry Failed");

            // Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(category, actualCategory);
                Assert.AreEqual(title, actualTitle);
                Assert.AreEqual(description, actualDescription);
                Assert.AreEqual(serviceType, actualServiceType);
            });
        }
    }
}
