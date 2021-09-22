using MarsQA_1.Helpers;
using MarsQA_1.SpecflowPages.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace MarsQA_1.SpecflowTests.BindSteps
{
    [Binding]
    public class DashboardSteps
    {
        private int _initialNotificationCount;
        private string _notificationDateBefore;

        #region Show Less
        [Given(@"user clicks Dashboard")]
        public void GivenUserClicksDashboard()
        {
            // Go to Dashboard page
            Profile.ClickDashboard();

            // Wait for notifications to become visible
            CommonMethods.WaitForElementToBeVisible("//div[@class='item link'][1]", 5);
        }

        [Given(@"user clicks Load More\.\.\. button")]
        public void GivenUserClicksLoadMore_Button()
        {
            Dashboard.ClickLoadMoreButton();

            // Wait for more notifications to become visible
            CommonMethods.WaitForElementToBeVisible("//div[@class='item link'][6]", 5);
        }

        [When(@"user clicks \.\.\.Show Less button")]
        public void WhenUserClicks_ShowLessButton()
        {
            // Count the no. of notifications before clicking '...Show Less' button
            _initialNotificationCount = Dashboard.GetNotificationsCount();

            Dashboard.ClickShowLessButton();

            // Wait for notifications to show less
            CommonMethods.WaitForElementToBeNotVisible("//div[@class='item link'][6]", 5);
        }

        [Then(@"less notifications will be displayed")]
        public void ThenLessNotificationsWillBeDisplayed()
        {
            // Log test result
            CommonMethods.LogResult(Dashboard.GetNotificationsCount() < _initialNotificationCount, "Notification Show Less Passed", "Notification Show Less Failed");

            //assert that less notifications are displayed
            Assert.That(Dashboard.GetNotificationsCount() < _initialNotificationCount);

        }
        #endregion

        #region Load More
        [When(@"user clicks Load More\.\.\. button")]
        public void WhenUserClicksLoadMore_Button()
        {
            // Count the no. of notifications before clicking 'Load More...' button
            _initialNotificationCount = Dashboard.GetNotificationsCount();
            
            Dashboard.ClickLoadMoreButton();

            // Wait for more notifications to become visible
            CommonMethods.WaitForElementToBeVisible("//div[@class='item link'][6]", 5);
        }
        
        [Then(@"more notifications will be displayed")]
        public void ThenNotificationsWillBeDisplayed()
        {
            // Log test result
            CommonMethods.LogResult(Dashboard.GetNotificationsCount() > _initialNotificationCount, "Notification Load More Passed", "Notification Load More Failed");
            
            // Assert that more notifications are displayed
            Assert.That(Dashboard.GetNotificationsCount() > _initialNotificationCount);
        }
        #endregion

        #region Delete
        [Given(@"user clicks a checkbox")]
        public void GivenUserClicksACheckbox()
        {
            // Get notification date
            _notificationDateBefore = Dashboard.GetNotificationDate1();

            Dashboard.ClickCheckbox1();
        }

        [When(@"user clicks Delete selection")]
        public void WhenUserClicksDeleteSelection()
        {
            Dashboard.ClickDeleteSelection();
        }

        [Then(@"the notification will be deleted")]
        public void ThenTheNotificationWillBeDeleted()
        {
            // Get notification date
            string notificationDateAfter = Dashboard.GetNotificationDate1();

            // Log test result
            CommonMethods.LogResult(_notificationDateBefore != notificationDateAfter, "Delete selection Passed", "Delete selection Failed");

            // Assert
            Assert.AreNotEqual(_notificationDateBefore, notificationDateAfter);

        }
        #endregion

        #region Mark selection as read
        [When(@"user clicks Mark selection as read")]
        public void WhenUserClicksMarkSelectionAsRead()
        {
            Dashboard.ClickMarkSelectionAsRead();
        }
        #endregion


        #region Select All
        [When(@"user clicks Select All")]
        public void WhenUserClicksSelectAll()
        {
            Dashboard.ClickSelectAll();
        }

        [Then(@"notification items will be selected")]
        public void ThenNotificationItemsWillBeSelected()
        {
            // Log the test result
            bool passCondition = Dashboard.IsCheckboxSelected(1) &&
                                 Dashboard.IsCheckboxSelected(2) &&
                                 Dashboard.IsCheckboxSelected(3) &&
                                 Dashboard.IsCheckboxSelected(4) &&
                                 Dashboard.IsCheckboxSelected(5);
            CommonMethods.LogResult(passCondition, "Select All Passed", "Select All Failed");

            // Assert
            Assert.Multiple(() =>
            {
                Assert.True(Dashboard.IsCheckboxSelected(1));
                Assert.True(Dashboard.IsCheckboxSelected(2));
                Assert.True(Dashboard.IsCheckboxSelected(3));
                Assert.True(Dashboard.IsCheckboxSelected(4));
                Assert.True(Dashboard.IsCheckboxSelected(5));
            });
        }
        #endregion

        #region Unselect All
        [Given(@"user clicks Select All")]
        public void GivenUserClicksSelectAll()
        {
            Dashboard.ClickSelectAll();
        }

        [When(@"user clicks Unselect All")]
        public void WhenUserClicksUnselectAll()
        {
            Dashboard.ClickUnselectAll();
        }

        [Then(@"notification items will be unselected")]
        public void ThenNotificationItemsWillBeUnselected()
        {
            // Log the test result
            bool passCondition = Dashboard.IsCheckboxSelected(1) == false &&
                                 Dashboard.IsCheckboxSelected(2) == false &&
                                 Dashboard.IsCheckboxSelected(3) == false &&
                                 Dashboard.IsCheckboxSelected(4) == false &&
                                 Dashboard.IsCheckboxSelected(5) == false;
            CommonMethods.LogResult(passCondition, "Unselect All Passed", "Unselect All Failed");

            // Assert
            Assert.Multiple(() =>
            {
                Assert.False(Dashboard.IsCheckboxSelected(1));
                Assert.False(Dashboard.IsCheckboxSelected(2));
                Assert.False(Dashboard.IsCheckboxSelected(3));
                Assert.False(Dashboard.IsCheckboxSelected(4));
                Assert.False(Dashboard.IsCheckboxSelected(5));
            });
        }
        #endregion
    }
}