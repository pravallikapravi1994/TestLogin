using MarsQA_1.Helpers;
using MarsQA_1.Pages;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace MarsQA_1.Featurefiles
{
    [Binding]
    public class LoginSteps
    {

        [Given(@"User is in Login page")]
        public void GivenUserIsInLoginPage()
        {
            
        }

        [Given(@"Enters valid (.*) Username and (.*) Password")]
        public void GivenEntersValidUsernameAndPassword(string Username, string password)
        {
            SignIn.Login(Username, password);
        }


        [When(@"Clicked on Login button")]
        public void WhenClickedOnLoginButton()
        {
            SignIn.ClickOnLogin();
           
        }


        [Then(@"User '(.*)'should be logged in Successfully")]
        public void ThenUserShouldBeLoggedInSuccessfully(string Username)
        {
            Assert.That(SignIn.VerifyLogin(Username));
        }

       

        [Given(@"Enters invalid Username and  Password")]
        public void GivenEntersInvalidUsernameAndPassword()
        {
            ExcelLibHelper.PopulateInCollection(@"C:\Xtracta\example.testproject.io\LoginLogout\SpecflowTests\Data\TestData.xlsx", "Credentials");
            String Username =ExcelLibHelper.ReadData(2, "username");
            String Password =ExcelLibHelper.ReadData(2, "password");

            SignIn.Login(Username, Password);


        }


        [Then(@"Login to be failed and Error message to be displayed")]
        public void ThenLoginToBeFailedAndErrorMessageToBeDisplayed()
        {
            Assert.That(SignIn.ValidateLogin());
        }

    }




}
