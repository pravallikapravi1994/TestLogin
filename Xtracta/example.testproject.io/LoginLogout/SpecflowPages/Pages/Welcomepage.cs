using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsQA_1.Helpers;
using MarsQA_1.Utils;
using NUnit.Framework.Internal;
using OpenQA.Selenium;

namespace MarsQA_1.SpecflowPages.Pages
{
    public static class Welcomepage
    {
        private static IWebElement Btn_Logout=> Driver.driver.FindElement(By.Id("logout"));




        public static void Logout()
        {


            Driver.TurnOnWait();
            Btn_Logout.Click();
            Driver.TurnOnWait();

        }


        public static bool VerifyLogout()
        {
            try
            {
                Driver.driver.FindElement(By.Id("login"));
                Console.WriteLine("LoggedOut Successfully");
                return true;
            }
            catch(Exception NoSuchElementException)
            {
                Console.WriteLine("LoggedOut Failed");
                return false;

            }
        }



        




    }
}
