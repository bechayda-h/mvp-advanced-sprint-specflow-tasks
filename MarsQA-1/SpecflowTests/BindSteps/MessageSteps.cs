using MarsQA_1.Helpers;
using MarsQA_1.SpecflowPages.Pages;
using NUnit.Framework;
using System.Threading;
using TechTalk.SpecFlow;

namespace MarsQA_1.SpecflowTests.BindSteps
{
    [Binding]
    public class MessageSteps
    {
        private string _MessageContent;

        #region Chat
        [Given(@"user clicks Chat")]
        public void GivenUserClicksChat()
        {
            Profile.ClickChat();
        }

        [Given(@"user enters a message '(.*)'")]
        public void GivenUserEntersAMessage(string message)
        {
            // Wait a bit
            Thread.Sleep(500);

            Message.InputChat(message);
        }

        [When(@"user clicks Send in the Message page")]
        public void WhenUserClicksSendInTheMessagePage()
        {
            // Wait a bit
            Thread.Sleep(500);

            Message.ClickSendButton();
        }

        [Then(@"the message '(.*)' will be added in the chat content")]
        public void ThenTheMessageWillBeAddedInTheChatContent(string message)
        {
            // Wait a bit
            Thread.Sleep(500);

            // Get the latest message
            string latestMessage = Message.GetLatestMessage();

            // Log test result
            CommonMethods.LogResult(message == latestMessage, "Chat Passed,", "Chat Failed");

            // Assert
            Assert.AreEqual(message, latestMessage);
        }
        #endregion

        #region Chat History
        [When(@"user clicks the second chatroom from the top")]
        public void WhenUserClicksTheSecondChatroomFromTheTop()
        {
            // Get current first message and time before clicking another chatroom
            _MessageContent = Message.GetFirstMessageAndTime();
            
            Message.ClickChatList2();
        }

        [Then(@"the chat content of that chat room will be displayed")]
        public void ThenTheChatContentOfThatChatRoomWillBeDisplayed()
        {
            // Log test result
            CommonMethods.LogResult(_MessageContent != Message.GetFirstMessageAndTime(), 
                                    "Chat content updated", 
                                    "Chat Content not updated");
            
            // Assert that the chat content is different
            StringAssert.DoesNotMatch(_MessageContent, Message.GetFirstMessageAndTime());
        }
        #endregion
    }
}
