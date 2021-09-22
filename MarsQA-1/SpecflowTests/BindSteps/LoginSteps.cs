using MarsQA_1.Helpers;
using MarsQA_1.Pages;
using MarsQA_1.SpecflowPages.Pages;
using NUnit.Framework;
using System.Threading;
using TechTalk.SpecFlow;

namespace MarsQA_1.Feature
{
    [Binding]
    class LoginSteps
    {
        #region Sign In
        [Given(@"user clicks Sign In")]
        public void GivenUserClicksSignIn()
        {
            SignIn.ClickSignIn();
        }

        [When(@"user logs in with ""(.*)"" and ""(.*)""")]
        public void WhenUserLogsInWithAnd(string username, string password)
        {
            // Login with username and password
            SignIn.Login(username, password); 
        }

        [Then(@"the user Profile Page ""(.*)"" will be accessed")]
        public void ThenTheUserSProfilePageWillBeAccessed(string name)
        {
            // Wait a bit for the login process to complete
            Thread.Sleep(6000);

            // Log test result
            bool passCondition = "Profile" == Driver.driver.Title && name == Profile.GetUserName();
            CommonMethods.LogResult(passCondition, "SignIn Passed", "SignIn Failed");

            // Assert
            Assert.Multiple(() =>
            {
                StringAssert.IsMatch("Profile", Driver.driver.Title);
                StringAssert.IsMatch(name, Profile.GetUserName());
            });
        }
        #endregion

        #region Join
        [Given(@"user clicks Join")]
        public void GivenUserClicksJoin()
        {
            SignIn.ClickTopRightJoinButton();
        }

        [Given(@"user inputs ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", and ""(.*)""")]
        public void GivenUserInputsAnd(string firstname, string lastname, string email, string password, string confirmpassword)
        {
            // Input user name, email, password
            SignIn.RegistrationFormInputs(firstname, lastname, email, password, confirmpassword);
        }

        [Given(@"user agrees with the terms and condition")]
        public void GivenUserAgreesWithTheTermsAndCondition()
        {
            // Check to agree to the terms
            SignIn.ClickCheckbox();
        }

        [When(@"user clicks the Join button")]
        public void WhenUserClicksTheJoinButton()
        {
            // Click Join button
            SignIn.ClickFormJoinButton();
        }

        [Then(@"a ""(.*)"" message will appear")]
        public void ThenAMessageWillAppear(string message)
        {
            // Get popup message
            string popupMessage = SignIn.GetPopupMessage();

            // Log test result
            CommonMethods.LogResult(message == popupMessage, $"{message} displayed", $"{message} not displayed");
            
            // Assert
            StringAssert.IsMatch(message, popupMessage);
        }
        #endregion
    }
}
