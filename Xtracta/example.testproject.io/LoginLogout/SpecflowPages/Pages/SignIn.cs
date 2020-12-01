using MarsQA_1.Helpers;
using OpenQA.Selenium;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Net;
using System.Threading;
namespace MarsQA_1.Pages
{
    public static class SignIn
    {


        /// <summary>
        /// WebElements for SignIn
        /// </summary>

        private static IWebElement Txt_Name =>  Driver.driver.FindElement(By.Id("name"));

        private static IWebElement Txt_Password => Driver.driver.FindElement(By.Id("password"));
        private static IWebElement Btn_Login => Driver.driver.FindElement(By.Id("login"));

        private static IWebElement WelcomeText => Driver.driver.FindElement(By.XPath("//p[@id='greetings']/b"));

        private static IWebElement InvalidErrormessage => Driver.driver.FindElement(By.XPath("//*[@id='passwordHelp']/../div[@class='invalid-feedback']"));




        public static void Login(string Username, string Password)
        {
            

            //Enter Username
            Driver.NavigateUrl();
            Txt_Name.SendKeys(Username);
            //Enter Password
            Driver.TurnOnWait();
            Txt_Password.SendKeys(Password);

          

        }

        public static void ClickOnLogin()
        {
    //Click on SignInbutton
            Driver.TurnOnWait();
            Btn_Login.Click();
            Driver.TurnOnWait();
        }

        public static bool VerifyLogin(String Username)
        {
            Driver.TurnOnWait();
            var ExpectedUsername = Username;
            try
            {
                Driver.driver.FindElement(By.XPath("//p[@id='greetings']/b"));
                var ActualUsername = WelcomeText.Text;

               if(ActualUsername==ExpectedUsername)
                {
                    Console.WriteLine("Login Successfull");
                    return true;
                }
                return false;
                

                
            }

            catch(Exception NoSuchElementException)
            {
                Console.WriteLine("Login failed");
                return false;
            }

            

        }


        public static bool ValidateLogin()
        {

            try
            {
                Driver.driver.FindElement(By.XPath("//*[@id='passwordHelp']/../div[@class='invalid-feedback']"));
 
                 var ErrorMessage = InvalidErrormessage.Text;

                    Console.WriteLine(ErrorMessage);
                    return true;
                }
                


            catch (Exception NoSuchElementException)
            {
                Console.WriteLine("Login validation Failed");
                return false;
            }

        }






        }
}