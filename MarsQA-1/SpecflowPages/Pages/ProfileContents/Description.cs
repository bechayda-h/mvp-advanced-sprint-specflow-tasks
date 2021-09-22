using MarsQA_1.Helpers;
using OpenQA.Selenium;
using System.Threading;

namespace MarsQA_1.SpecflowPages.Pages.ProfileContents
{
    class Description
    {
        private static IWebElement WriteIcon => Driver.driver.FindElement(By.XPath("//h3[text()='Description']/span/i"));
        private static IWebElement DescriptionText => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/div/span"));
        private static IWebElement InputField => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/form/div/div/div[2]/div[1]/textarea"));
        private static IWebElement SaveButton => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/form/div/div/div[2]/button"));

        public static void ClickWriteIcon()
        {
            WriteIcon.Click();
        }

        public static void InputDescription(string description)
        {
            // Click to highlight text field
            InputField.Click();
            
            // Wait a bit
            Thread.Sleep(100);
            
            // Clear the text field contents
            InputField.Clear();
            
            // Wait a bit
            Thread.Sleep(100);
            
            // Input the new content
            InputField.SendKeys(description);
        }

        public static void ClickSaveButton()
        {
            SaveButton.Click();
        }

        public static string GetDescription()
        {
            return DescriptionText.Text;
        }
    }
}
