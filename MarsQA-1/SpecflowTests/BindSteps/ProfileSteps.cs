using MarsQA_1.Helpers;
using MarsQA_1.Pages;
using MarsQA_1.SpecflowPages.Pages;
using MarsQA_1.SpecflowPages.Pages.ProfileContents;
using NUnit.Framework;
using System.Threading;
using TechTalk.SpecFlow;

namespace MarsQA_1.SpecflowTests.BindSteps
{
    [Binding]
    public class ProfileSteps
    {
        private string _entryName;

        #region Availability
        [Given(@"user logs in to website")]
        public void GivenUserLogsInToWebsite()
        {
            SignIn.SigninSteps();
        }

        [Given(@"user clicks the write icon of Availability")]
        public void GivenUserClicksTheWriteIconOfAvailability()
        {
            Availability.ClickWriteIcon();
        }

        [When(@"user selects '(.*)' as Availability")]
        public void WhenUserSelectsAsAvailability(string option)
        {
            Availability.SelectOption(option);
        }

        [Then(@"the value of Availability will become '(.*)'")]
        public void ThenTheValueOfAvailabilityWillBecome(string option)
        {
            // Get actual value 
            string actualValue = Availability.GetValue();
            
            // Log test result
            CommonMethods.LogResult(option == actualValue, "Availability value updated", "Availability value not updated");
            
            // Assert
            Assert.AreEqual(option, actualValue);
        }
        #endregion
        
        #region Hours
        [Given(@"user clicks the write icon of Hours")]
        public void GivenUserClicksTheWriteIconOfHours()
        {
            Hours.ClickWriteIcon();
        }

        [When(@"user selects '(.*)' as Hours")]
        public void WhenUserSelectsAsHours(string option)
        {
            Hours.SelectOption(option);
        }

        [Then(@"the value of Hours will become '(.*)'")]
        public void ThenTheValueOfHoursWillBecome(string option)
        {
            // Get actual value 
            string actualValue = Hours.GetValue();

            // Log test result
            CommonMethods.LogResult(option == actualValue, "Hours value updated", "Hours value not updated");

            // Assert
            Assert.AreEqual(option, actualValue);
        }
        #endregion

        #region Earn Target
        [Given(@"user clicks the write icon of Earn Target")]
        public void GivenUserClicksTheWriteIconOfEarnTarget()
        {
            EarnTarget.ClickWriteIcon();  
        }

        [When(@"user selects '(.*)' as Earn Target")]
        public void WhenUserSelectsAsEarnTarget(string option)
        {
            EarnTarget.SelectOption(option);
        }

        [Then(@"the value of Earn Target will become '(.*)'")]
        public void ThenTheValueOfEarnTargetWillBecome(string option)
        {
            // Get actual value 
            string actualValue = EarnTarget.GetValue();

            // Log test result
            CommonMethods.LogResult(option == actualValue, "Earn Target value updated", "Earn Target value not updated");

            // Assert
            Assert.AreEqual(option, actualValue);
        }
        #endregion

        #region Add Language
        [Given(@"user clicks the Add New entry in Languages tab")]
        public void GivenUserClicksTheAddNewEntryInLanguagesTab()
        {
            Languages.ClickAddNewButton();
        }

        [Given(@"user inputs '(.*)' and '(.*)' in Languages tab")]
        public void GivenUserInputsAndInLanguagesTab(string name, string level)
        {
            Languages.InputNewName(name);
            Languages.SelectNewLevel(level);
        }

        [When(@"user clicks Add in Langauages tab")]
        public void WhenUserClicksAddInLangauagesTab()
        {
            Languages.ClickAddButton();
        }

        [Then(@"a language entry '(.*)' and '(.*)' will be added")]
        public void ThenALanguageEntryAndWillBeAdded(string name, string level)
        {
            // Get actual values
            string actualName = Languages.GetName();
            string actualLevel = Languages.GetLevel();

            // Log test result
            bool passCondition = name == actualName && level == actualLevel;
            CommonMethods.LogResult(passCondition, "Add language entry Passed", "Add language entry Failed");

            // Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(name, actualName);
                Assert.AreEqual(level, actualLevel);
            });
        }
        #endregion

        #region Edit Language
        [Given(@"user clicks the write icon of a language entry")]
        public void GivenUserClicksTheWriteIconOfALanguageEntry()
        {
            Languages.ClickWriteIcon();
        }

        [Given(@"user updates the language entry with '(.*)' and '(.*)'")]
        public void GivenUserUpdatesTheLanguageEntryWithAnd(string name, string level)
        {
            Languages.UpdateName(name);
            Languages.UpdateLevel(level);
        }

        [When(@"user clicks Update of the language entry")]
        public void WhenUserClicksUpdateOfTheLanguageEntry()
        {
            Languages.ClickUpdateButton();
        }

        [Then(@"the language entry will be updated with '(.*)' and '(.*)'")]
        public void ThenTheLanguageEntryWillBeUpdatedWithAnd(string name, string level)
        {
            // Wait a bit
            Thread.Sleep(1000);

            // Get actual values
            string actualName = Languages.GetName();
            string actualLevel = Languages.GetLevel();

            // Log test result
            bool passCondition = name == actualName && level == actualLevel;
            CommonMethods.LogResult(passCondition, "Edit language entry Passed", "Edit language entry Failed");

            // Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(name, actualName);
                Assert.AreEqual(level, actualLevel);
            });
        }
        #endregion

        #region Delete Language
        [When(@"user clicks the remove icon of a language entry")]
        public void WhenUserClicksTheRemoveIconOfALanguageEntry()
        {
            // Get language name before deleting
            _entryName = Languages.GetName();

            Languages.ClickRemoveIcon();
        }

        [Then(@"the language entry will be deleted")]
        public void ThenTheLanguageEntryWillBeDeleted()
        {
            // Wait a bit
            Thread.Sleep(1000);

            // Check if entry is deleted
            bool isEntryDeleted = Languages.IsEntryDeleted();
            
            // Log test result
            CommonMethods.LogResult(isEntryDeleted,"Language entry deleted","Language entry not deleted");

            // Assert
            Assert.IsTrue(isEntryDeleted);
        }

        [Then(@"a language has been deleted message will appear")]
        public void ThenALanguageHasBeenDeletedMessageWillAppear()
        {
            // Set expected message
            string expectedMessage = $"{_entryName} has been deleted from your languages";
            
            // Get popupMessage
            string popupMessage = Profile.GetPopupMessage();

            // Log test result
            CommonMethods.LogResult(expectedMessage == popupMessage, "deletion message displayed", "deletion message not displayed");

            // Assert
            Assert.AreEqual(expectedMessage,popupMessage);
        }
        #endregion

        #region Add Skill
        [Given(@"user clicks the ""(.*)"" tab")]
        public void GivenUserClicksTheTab(string tab)
        {
            // Click the target tab
            Profile.SetActiveTab(tab);
        }

        [Given(@"user clicks the Add New entry in Skills tab")]
        public void GivenUserClicksTheAddNewEntryInSkillsTab()
        {
            Skills.ClickAddNewButton();
        }

        [Given(@"user inputs '(.*)' and '(.*)' in Skills tab")]
        public void GivenUserInputsAndInSkillsTab(string name, string level)
        {
            Skills.InputNewName(name);
            Skills.SelectNewLevel(level);
        }

        [When(@"user clicks Add in Skills tab")]
        public void WhenUserClicksAddInSkillsTab()
        {
            Skills.ClickAddButton();
        }

        [Then(@"a skill entry '(.*)' and '(.*)' will be added")]
        public void ThenASkillEntryAndWillBeAdded(string name, string level)
        {
            // Get actual values
            string actualName = Skills.GetName();
            string actualLevel = Skills.GetLevel();

            // Log test result
            bool passCondition = name == actualName && level == actualLevel;
            CommonMethods.LogResult(passCondition, "Add skill entry Passed", "Add skill entry Failed");

            // Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(name, actualName);
                Assert.AreEqual(level, actualLevel);
            });
        }
        #endregion

        #region Edit Skill
        [Given(@"user clicks the write icon of a skill entry")]
        public void GivenUserClicksTheWriteIconOfASkillEntry()
        {
            Skills.ClickWriteIcon();
        }

        [Given(@"user updates the skill entry with '(.*)' and '(.*)'")]
        public void GivenUserUpdatesTheSkillEntryWithAnd(string name, string level)
        {
            Skills.UpdateName(name);
            Skills.UpdateLevel(level);
        }

        [When(@"user clicks Update of the skill entry")]
        public void WhenUserClicksUpdateOfTheSkillEntry()
        {
            Skills.ClickUpdateButton();
        }

        [Then(@"the skill entry will be updated with '(.*)' and '(.*)'")]
        public void ThenTheSkillEntryWillBeUpdatedWithAnd(string name, string level)
        {
            // Wait a bit
            Thread.Sleep(1000);

            // Get actual values
            string actualName = Skills.GetName();
            string actualLevel = Skills.GetLevel();

            // Log test result
            bool passCondition = name == actualName && level == actualLevel;
            CommonMethods.LogResult(passCondition, "Edit skill entry Passed", "Edit skill entry Failed");

            // Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(name, actualName);
                Assert.AreEqual(level, actualLevel);
            });
        }
        #endregion

        #region Delete Skill
        [When(@"user clicks the remove icon of a skill entry")]
        public void WhenUserClicksTheRemoveIconOfASkillEntry()
        {
            // Get skill name before deleting
            _entryName = Skills.GetName();

            Skills.ClickRemoveIcon();
        }

        [Then(@"the skill entry will be deleted")]
        public void ThenTheSkillEntryWillBeDeleted()
        {
            // Wait a bit
            Thread.Sleep(1000);

            // Check if entry is deleted
            bool isEntryDeleted = Skills.IsEntryDeleted();

            // Log test result
            CommonMethods.LogResult(isEntryDeleted, "Skill entry deleted", "Skill entry not deleted");

            // Assert
            Assert.IsTrue(isEntryDeleted);
        }

        [Then(@"a skill has been deleted message will appear")]
        public void ThenASkillHasBeenDeletedMessageWillAppear()
        {
            // Set expected message
            string expectedMessage = $"{_entryName} has been deleted";

            // Get popupMessage
            string popupMessage = Profile.GetPopupMessage();

            // Log test result
            CommonMethods.LogResult(expectedMessage == popupMessage, "deletion message displayed", "deletion message not displayed");

            // Assert
            Assert.AreEqual(expectedMessage, popupMessage);
        }
        #endregion

        #region Add Education
        [Given(@"user clicks the Add New entry in Education tab")]
        public void GivenUserClicksTheAddNewEntryInEducationTab()
        {
            Education.ClickAddNewButton();    
        }

        [Given(@"user inputs '(.*)', '(.*)', '(.*)', '(.*)', and '(.*)' in Education tab")]
        public void GivenUserInputsAndInEducationTab(string university, string country, string title, string degree, string year)
        {
            Education.InputNewUniversity(university);
            Education.SelectNewCountry(country);
            Education.SelectNewTitle(title);
            Education.InputNewDegree(degree);
            Education.SelectNewYear(year);
        }

        [When(@"user clicks Add in Education tab")]
        public void WhenUserClicksAddInEducationTab()
        {
            Education.ClickAddButton();
        }

        [Then(@"an education entry '(.*)', '(.*)', '(.*)', '(.*)', '(.*)' will be added")]
        public void ThenAnEducationEntryWillBeAdded(string country, string university, string title, string degree, string year)
        {
            // Get actual values
            string actualCountry = Education.GetCountry();
            string actualUniversity = Education.GetUniversity();
            string actualTitle = Education.GetTitle();
            string actualDegree = Education.GetDegree();
            string actualYear = Education.GetYear();

            // Log test result
            bool passCondition = country == actualCountry &&
                              university == actualUniversity &&
                                   title == actualTitle &&
                                  degree == actualDegree;
            CommonMethods.LogResult(passCondition, "Add education entry Passed", "Add education entry Failed");

            // Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(country, actualCountry);
                Assert.AreEqual(university, actualUniversity);
                Assert.AreEqual(title, actualTitle);
                Assert.AreEqual(degree, actualDegree);
            });
        }
        #endregion

        #region Edit Education
        [Given(@"user clicks the write icon of an education entry")]
        public void GivenUserClicksTheWriteIconOfAnEducationEntry()
        {
            Education.ClickWriteIcon();
        }

        [Given(@"user updates the education entry with '(.*)', '(.*)', '(.*)', '(.*)', and '(.*)'")]
        public void GivenUserUpdatesTheEducationEntryWithAnd(string university, string country, string title, string degree, string year)
        {
            Education.UpdateUniversity(university);
            Education.UpdateCountry(country);
            Education.UpdateTitle(title);
            Education.UpdateDegree(degree);
            Education.UpdateYear(year);
        }

        [When(@"user clicks Update of the education entry")]
        public void WhenUserClicksUpdateOfTheEducationEntry()
        {
            Education.ClickUpdateButton();
        }

        [Then(@"the education entry will be updated with '(.*)', '(.*)', '(.*)', '(.*)', and '(.*)'")]
        public void ThenTheEducationEntryWillBeUpdatedWithAnd(string country, string university, string title, string degree, string year)
        {
            // Wait a bit
            Thread.Sleep(1000);

            // Get actual values
            string actualCountry = Education.GetCountry();
            string actualUniversity = Education.GetUniversity();
            string actualTitle = Education.GetTitle();
            string actualDegree = Education.GetDegree();
            string actualYear = Education.GetYear();

            // Log test result
            bool passCondition = country == actualCountry &&
                              university == actualUniversity &&
                                   title == actualTitle &&
                                  degree == actualDegree;
            CommonMethods.LogResult(passCondition, "Edit education entry Passed", "Edit education entry Failed");

            // Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(country, actualCountry);
                Assert.AreEqual(university, actualUniversity);
                Assert.AreEqual(title, actualTitle);
                Assert.AreEqual(degree, actualDegree);
            });
        }
        #endregion

        #region Delete Education
        [When(@"user clicks the remove icon of an education entry")]
        public void WhenUserClicksTheRemoveIconOfAnEducationEntry()
        {
            Education.ClickRemoveIcon();
        }

        [Then(@"the education entry will be deleted")]
        public void ThenTheEducationEntryWillBeDeleted()
        {
            // Wait a bit
            Thread.Sleep(500);

            // Check if entry is deleted
            bool isEntryDeleted = Education.IsEntryDeleted();

            // Log test result
            CommonMethods.LogResult(isEntryDeleted, "Education entry deleted", "Education entry not deleted");

            // Assert
            Assert.IsTrue(isEntryDeleted);
        }
        #endregion

        #region Add Certification
        [Given(@"user clicks the Add New entry in Certifications tab")]
        public void GivenUserClicksTheAddNewEntryInCertificationsTab()
        {
            Certifications.ClickAddNewButton();
        }

        [Given(@"user inputs '(.*)', '(.*)', and '(.*)' in Certifications tab")]
        public void GivenUserInputsAndInCertificationsTab(string certificate, string from, string year)
        {
            Certifications.InputNewCertificate(certificate);
            Certifications.InputNewFrom(from);
            Certifications.SelectNewYear(year);
        }

        [When(@"user clicks Add in Certifications tab")]
        public void WhenUserClicksAddInCertificationsTab()
        {
            Certifications.ClickAddButton();
        }

        [Then(@"a certification entry '(.*)', '(.*)', '(.*)' will be added")]
        public void ThenACertificationEntryWillBeAdded(string certificate, string from, string year)
        {
            // Get actual values
            string actualCertificate = Certifications.GetCertificate();
            string actualFrom = Certifications.GetFrom();
            string actualYear = Certifications.GetYear();

            // Log test result
            bool passCondition = certificate == actualCertificate &&
                                        from == actualFrom &&
                                        year == actualYear;
            CommonMethods.LogResult(passCondition, "Add certification entry Passed", "Add certification entry Failed");

            // Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(certificate, actualCertificate);
                Assert.AreEqual(from, actualFrom);
                Assert.AreEqual(year, actualYear);
            });
        }
        #endregion

        #region Edit Certification
        [Given(@"user clicks the write icon of a certification entry")]
        public void GivenUserClicksTheWriteIconOfACertificationEntry()
        {
            Certifications.ClickWriteIcon();
        }

        [Given(@"user updates the certification entry with '(.*)', '(.*)', and '(.*)'")]
        public void GivenUserUpdatesTheCertificationEntryWithAnd(string certificate, string from, string year)
        {
            Certifications.UpdateCertificate(certificate);
            Certifications.UpdateFrom(from);
            Certifications.UpdateYear(year);
        }

        [When(@"user clicks the Update of the certification entry")]
        public void WhenUserClicksTheUpdateOfTheCertificationEntry()
        {
            Certifications.ClickUpdateButton();
        }

        [Then(@"the certification entry will be updated with '(.*)', '(.*)', and '(.*)'")]
        public void ThenTheCertificationEntryWillBeUpdatedWithAnd(string certificate, string from, string year)
        {
            // Wait a bit
            Thread.Sleep(500);

            // Get actual values
            string actualCertificate = Certifications.GetCertificate();
            string actualFrom = Certifications.GetFrom();
            string actualYear = Certifications.GetYear();

            // Log test result
            bool passCondition = certificate == actualCertificate &&
                                        from == actualFrom &&
                                        year == actualYear;
            CommonMethods.LogResult(passCondition, "Edit certification entry Passed", "Edit certification entry Failed");

            // Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(certificate,actualCertificate);
                Assert.AreEqual(from, actualFrom);
                Assert.AreEqual(year, actualYear);
            });
        }
        #endregion

        #region Delete Certification
        [When(@"user clicks the remove icon of a certification entry")]
        public void WhenUserClicksTheRemoveIconOfACertificationEntry()
        {
            // Get entry name before deleting
            _entryName = Certifications.GetCertificate();

            Certifications.ClickRemoveIcon();
        }

        [Then(@"the certification entry will be deleted")]
        public void ThenTheCertificationEntryWillBeDeleted()
        {
            // Wait a bit
            Thread.Sleep(500);

            // Check if entry is deleted
            bool isEntryDeleted = Certifications.IsEntryDeleted();

            // Log test result
            CommonMethods.LogResult(isEntryDeleted, "Certification entry deleted", "Certification entry not deleted");

            // Assert
            Assert.IsTrue(isEntryDeleted);
        }

        [Then(@"a certification entry has been deleted message will appear")]
        public void ThenACertificationEntryHasBeenDeletedMessageWillAppear()
        {
            // Set expected message
            string expectedMessage = $"{_entryName} has been deleted from your certification";

            // Get popupMessage
            string popupMessage = Profile.GetPopupMessage();

            // Log test result
            CommonMethods.LogResult(expectedMessage == popupMessage, "deletion message displayed", "deletion message not displayed");

            // Assert
            Assert.AreEqual(expectedMessage, popupMessage);
        }
        #endregion

        #region Edit Description
        [Given(@"user clicks the write icon of the Description")]
        public void GivenUserClicksTheWriteIconOfTheDescription()
        {
            Description.ClickWriteIcon();
        }

        [Given(@"user edits the description with '(.*)'")]
        public void GivenUserEditsTheDescriptionWith(string description)
        {
            Description.InputDescription(description);
        }

        [When(@"user clicks Save of the Description")]
        public void WhenUserClicksSaveOfTheDescription()
        {
            Description.ClickSaveButton();
        }

        [Then(@"the description will be updated to '(.*)'")]
        public void ThenTheDescriptionWillBeUpdatedTo(string description)
        {
            // Wait a bit
            Thread.Sleep(1000);

            // Get actual value
            string actualDescription = Description.GetDescription();

            // Log test result
            CommonMethods.LogResult(description == actualDescription, "Edit Description Passed", "Edit Description Failed");

            // Assert
            Assert.AreEqual(description, actualDescription);
        }
        #endregion

        #region Change Password
        [Given(@"user navigates to Change Password")]
        public void GivenUserNavigatesToChangePassword()
        {
            ChangePassword.ClickChangePassword();
        }

        [Given(@"user inputs old password ""(.*)"" and new password ""(.*)""")]
        public void GivenUserInputsOldPasswordAndNewPassword(string oldpassword, string newpassword)
        {
            ChangePassword.InputOldAndNewPassword(oldpassword, newpassword);
        }

        [When(@"user clicks Save")]
        public void WhenUserClicksSave()
        {
            ChangePassword.ClickSaveButton();
        }
        #endregion
    }
}
