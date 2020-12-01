using MarsQA_1.Helpers;
using MarsQA_1.Pages;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using MarsQA_1.SpecflowPages.Pages;

namespace MarsQA_1.FeaturefileSteps
{
    [Binding]
    public class LogoutSteps
    {
        [Given(@"User is SignedIn")]
        public void GivenUserIsSignedIn()
        {
            SignIn.Login("TestUser", "12345");
            SignIn.ClickOnLogin();
        }
        
        [When(@"Clicked on Logout button")]
        public void WhenClickedOnLogoutButton()
        {
            Welcomepage.Logout();
        }
        
        [Then(@"Logout should be successfull")]
        public void ThenLogoutShouldBeSuccessfull()
        {
            Welcomepage.VerifyLogout();
        }
    }
}
