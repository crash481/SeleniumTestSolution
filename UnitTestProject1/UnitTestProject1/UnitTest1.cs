using System;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;


namespace UnitTestProject1
{
    [TestFixture]
    public class UnitTest1
    {
         static IWebDriver driver = new ChromeDriver(@"C:/seleniumDrivers");
         WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(6));
         Random random = new Random();

         [SetUp]
         public void SetupTest()
         {
             driver.Navigate().GoToUrl("http://appulatebeta.com/signup-old/companyinfo.aspx");
         }

        [Test]
        public void test1()
         {
        IWebElement FirmEdit = driver.FindElement(By.Id("contentPlaceHolder_txtCompanyName"));
            FirmEdit.Click();
            FirmEdit.Clear();
            FirmEdit.SendKeys(getRandomString(10, 55));

            /* IWebElement WebSiteEdit = driver.FindElement(By.Id("contentPlaceHolder_txtWebSite"));
                    WebSiteEdit.Click();
                    WebSiteEdit.Clear(); 
                    WebSiteEdit.SendKeys(getRandomString(10,55)); */

            /*   IWebElement NameEdit = driver.FindElement(By.Id("contentPlaceHolder_locations_Location0_txtName"));
                 NameEdit.Click();
                 NameEdit.Clear();  
                 NameEdit.SendKeys(getRandomString(10,55)); */

            IWebElement Street1Edit = driver.FindElement(By.Id("contentPlaceHolder_locations_Location0_txtStreetAddress"));
            Street1Edit.Click();
            Street1Edit.Clear();
            Street1Edit.SendKeys(getRandomString(10, 55));

            /*   IWebElement Street2Edit = driver.FindElement(By.Id("contentPlaceHolder_locations_Location0_txtStreetAddress2"));
                    FirmEdit.Click();
                    FirmEdit.Clear();
                    FirmEdit.SendKeys(getRandomString(10,55));*/

            IWebElement CityEdit = driver.FindElement(By.Id("contentPlaceHolder_locations_Location0_txtCity"));
            CityEdit.Click();
            CityEdit.Clear();
            CityEdit.SendKeys(getRandomString(10,55));

        IWebElement StateEdit = driver.FindElement(By.Id("contentPlaceHolder_locations_Location0_lstState"));
            SelectElement selectList = new SelectElement(StateEdit);
            selectList.SelectByIndex(random.Next(1, 55));
      
        IWebElement ZipEdit = driver.FindElement(By.Id("contentPlaceHolder_locations_Location0_txtZip"));
            ZipEdit.Click();
            ZipEdit.Clear();
            ZipEdit.SendKeys(getRandomString(10, 55));

        IWebElement PhoneEdit = driver.FindElement(By.Id("contentPlaceHolder_locations_Location0_txtPhone"));
            PhoneEdit.Click();
            PhoneEdit.Clear();
            PhoneEdit.SendKeys(getRandomString(10, 55));

            /*    IWebElement FaxEdit = driver.FindElement(By.Id("contentPlaceHolder_locations_Location0_txtFax"));
                      FaxEdit.Click();
                      FaxEdit.Clear();
                      FaxEdit.SendKeys(getRandomString(10, 55)); */

            IWebElement NextButton = driver.FindElement(By.Id("contentPlaceHolder_btnNext"));
            NextButton.Click();


                // Вторая страница 


        try
        {
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("ctl00_contentPlaceHolder_newUserInfoEditor_txtFirstName")));
        }
        catch (WebDriverTimeoutException e)
        {
            Assert.Fail("Second page was not loaded");
        }

        String firstName = "";
            firstName = getRandomString(5, 16);

        IWebElement FirstNameEdit = driver.FindElement(By.Id("ctl00_contentPlaceHolder_newUserInfoEditor_txtFirstName"));
            FirstNameEdit.Click();
            FirstNameEdit.Clear();
            FirstNameEdit.SendKeys(firstName);

            String lastName = "";
                lastName = getRandomString(5, 16);

        IWebElement LastNameEdit = driver.FindElement(By.Id("ctl00_contentPlaceHolder_newUserInfoEditor_txtLastName"));
            LastNameEdit.Click();
            LastNameEdit.Clear();
            LastNameEdit.SendKeys(lastName);

        IWebElement Phone2Edit = driver.FindElement(By.Id("ctl00_contentPlaceHolder_newUserInfoEditor_txtPhone"));
            Phone2Edit.Click();
            Phone2Edit.Clear();  
            Phone2Edit.SendKeys(getRandomString(10, 55));

        String emailToSend = "";
            emailToSend += getRandomString(5, 25);
            emailToSend += "@";
            emailToSend += getRandomString(3, 10);
            emailToSend += ".";
            emailToSend += getRandomString(3, 10);

        IWebElement EmailEdit = driver.FindElement(By.Id("ctl00_contentPlaceHolder_newUserInfoEditor_txtEmail"));
            EmailEdit.Click();
            EmailEdit.Clear();
            EmailEdit.SendKeys(emailToSend);

        IWebElement SecondEmailEdit = driver.FindElement(By.Id("ctl00_contentPlaceHolder_newUserInfoEditor_txtSecondEmail"));
            SecondEmailEdit.Click();
            SecondEmailEdit.Clear();
            SecondEmailEdit.SendKeys(emailToSend);

            String password = "";
            do
            {
                password = getRandomString(10, 55);
            }
            while (password.Contains(firstName) || password.Contains(lastName) || password.Contains(emailToSend));

        IWebElement PasswordEdit = driver.FindElement(By.Id("ctl00_contentPlaceHolder_passwordControl_txtPassword"));
                PasswordEdit.Click();
                PasswordEdit.Clear();
                PasswordEdit.SendKeys(password);

        IWebElement PasswordConfirmEdit = driver.FindElement(By.Id("ctl00_contentPlaceHolder_passwordControl_txtPasswordConfirm"));
                PasswordConfirmEdit.Click();
                PasswordConfirmEdit.Clear();
                PasswordConfirmEdit.SendKeys(password);

        IWebElement NextButton2 = driver.FindElement(By.Id("ctl00_contentPlaceHolder_btnNext"));
                NextButton2.Click();
            
        try {
               wait.Until(ExpectedConditions.AlertIsPresent());
               Assert.Fail("alert appears with error message");
             } catch (WebDriverTimeoutException e) {
                 // все хорошо, всплывающего окна об ошибке нету
             }

          
               
                

        }


         [Test]
        public void test2()
        {
            for (int i = 0; i < 2; i++)
            {
                IWebElement addLocationButton = driver.FindElement(By.Id("contentPlaceHolder_locations_btnAddNewLocation"));
                addLocationButton.Click();

                wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("contentPlaceHolder_locations_btnAddNewLocation")));
            }
            
            IWebElement deleteLocation1Button = driver.FindElement(By.Id("contentPlaceHolder_locations_Location1_btnDeleteLocation"));
            for (int i = 0; i < 1; i++)
            {
                deleteLocation1Button.Click();
                wait.Until(ExpectedConditions.AlertIsPresent());
                driver.SwitchTo().Alert().Accept();
            }
           
        }

         [Test]
         public void test3()
         {
             IWebElement FirmEdit = driver.FindElement(By.Id("contentPlaceHolder_txtCompanyName"));
             FirmEdit.Click();
             FirmEdit.Clear();
             FirmEdit.SendKeys(getRandomString(10, 55));

             IWebElement Street1Edit = driver.FindElement(By.Id("contentPlaceHolder_locations_Location0_txtStreetAddress"));
             Street1Edit.Click();
             Street1Edit.Clear();
             Street1Edit.SendKeys(getRandomString(10, 55));

             IWebElement CityEdit = driver.FindElement(By.Id("contentPlaceHolder_locations_Location0_txtCity"));
             CityEdit.Click();
             CityEdit.Clear();
             CityEdit.SendKeys(getRandomString(10, 55));

             IWebElement StateEdit = driver.FindElement(By.Id("contentPlaceHolder_locations_Location0_lstState"));
             SelectElement selectList = new SelectElement(StateEdit);
             selectList.SelectByIndex(random.Next(1, 55));

             
             IWebElement ZipEdit = driver.FindElement(By.Id("contentPlaceHolder_locations_Location0_txtZip"));
             ZipEdit.Click();
             ZipEdit.Clear();
             ZipEdit.SendKeys(getRandomString(10, 55));

             String phoneToSend = getRandomString(10, 55);
             IWebElement PhoneEdit = driver.FindElement(By.Id("contentPlaceHolder_locations_Location0_txtPhone"));
             PhoneEdit.Click();
             PhoneEdit.Clear();
             PhoneEdit.SendKeys(phoneToSend);

             IWebElement NextButton = driver.FindElement(By.Id("contentPlaceHolder_btnNext"));
             NextButton.Click();

             // Вторая страница 

             try
             {
                 wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("ctl00_contentPlaceHolder_newUserInfoEditor_txtPhone")));
             }
             catch (WebDriverTimeoutException e)
             {
                 Assert.Fail("Second page was not loaded");
             }

             IWebElement Phone2Edit = driver.FindElement(By.Id("ctl00_contentPlaceHolder_newUserInfoEditor_txtPhone"));
             Assert.AreEqual(phoneToSend, Phone2Edit.GetAttribute("value"), "Phones are different");

         }

         [Test]
         public void test4()
         {
             IWebElement FirmEdit = driver.FindElement(By.Id("contentPlaceHolder_txtCompanyName"));
             FirmEdit.Click();
             FirmEdit.Clear();
             FirmEdit.SendKeys(getRandomString(10, 55));

             IWebElement Street1Edit = driver.FindElement(By.Id("contentPlaceHolder_locations_Location0_txtStreetAddress"));
             Street1Edit.Click();
             Street1Edit.Clear();
             Street1Edit.SendKeys(getRandomString(10, 55));

             IWebElement CityEdit = driver.FindElement(By.Id("contentPlaceHolder_locations_Location0_txtCity"));
             CityEdit.Click();
             CityEdit.Clear();
             CityEdit.SendKeys(getRandomString(10, 55));

             IWebElement StateEdit = driver.FindElement(By.Id("contentPlaceHolder_locations_Location0_lstState"));
             SelectElement selectList = new SelectElement(StateEdit);
             selectList.SelectByIndex(random.Next(1, 55));


             IWebElement ZipEdit = driver.FindElement(By.Id("contentPlaceHolder_locations_Location0_txtZip"));
             ZipEdit.Click();
             ZipEdit.Clear();
             ZipEdit.SendKeys(getRandomString(10, 55));

             String phoneToSend = getRandomString(10, 55);
             IWebElement PhoneEdit = driver.FindElement(By.Id("contentPlaceHolder_locations_Location0_txtPhone"));
             PhoneEdit.Click();
             PhoneEdit.Clear();
             PhoneEdit.SendKeys("");  // предполагаем, что пользователь забыл ввести одно из полей, так как на
                                       // на всех полях данной формы причина ошибки и сама ошибка идентичные

             IWebElement NextButton = driver.FindElement(By.Id("contentPlaceHolder_btnNext"));
             NextButton.Click();
             try
             {
                 bool isErrorDisplayed = driver.FindElement(By.Id("contentPlaceHolder_valSummary")).Displayed;
             }
             catch(StaleElementReferenceException)
             {
                 Assert.Fail("Error was not displayed");
             }

             PhoneEdit.Click();
             PhoneEdit.SendKeys(phoneToSend);
             NextButton.Click();

             

             // Вторая страница 



             try
             {
                 wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("ctl00_contentPlaceHolder_btnNext")));
             }
             catch (WebDriverTimeoutException e)
             {
                 Assert.Fail("Second page was not loaded");
             }


             // Очищаем все поля на проверку полей на ошибку отстутсвия содержания в них
             IWebElement FirstNameEdit = driver.FindElement(By.Id("ctl00_contentPlaceHolder_newUserInfoEditor_txtFirstName"));
             FirstNameEdit.Clear();

             IWebElement LastNameEdit = driver.FindElement(By.Id("ctl00_contentPlaceHolder_newUserInfoEditor_txtLastName"));
             LastNameEdit.Clear();

             IWebElement Phone2Edit = driver.FindElement(By.Id("ctl00_contentPlaceHolder_newUserInfoEditor_txtPhone"));
             Phone2Edit.Clear();

             IWebElement EmailEdit = driver.FindElement(By.Id("ctl00_contentPlaceHolder_newUserInfoEditor_txtEmail"));
             EmailEdit.Clear();

             IWebElement SecondEmailEdit = driver.FindElement(By.Id("ctl00_contentPlaceHolder_newUserInfoEditor_txtSecondEmail"));
             SecondEmailEdit.Clear();
             
             IWebElement PasswordEdit = driver.FindElement(By.Id("ctl00_contentPlaceHolder_passwordControl_txtPassword"));
             PasswordEdit.Clear();
     

             IWebElement PasswordConfirmEdit = driver.FindElement(By.Id("ctl00_contentPlaceHolder_passwordControl_txtPasswordConfirm"));
             PasswordConfirmEdit.Clear();


             // Нажимаем на submit, ожидаем всплывающее окно с ошибкой и парсим ее, проверяя на валидность
             IWebElement NextButton2 = driver.FindElement(By.Id("ctl00_contentPlaceHolder_btnNext"));
             NextButton2.Click();

             wait.Until(ExpectedConditions.AlertIsPresent());
             IAlert errorWindow = driver.SwitchTo().Alert();

             String errorWindowText = errorWindow.Text;

            bool emptyFirstNameError = errorWindowText.Contains("- Enter first name");
            bool emptyLastNameError = errorWindowText.Contains("- Enter last name");
            bool emptyPhoneError = errorWindowText.Contains("- Enter phone");
            bool emptyEmailError = errorWindowText.Contains("- Enter email");
            bool emptyConfirmEmailError = errorWindowText.Contains("- Confirm email");
            bool emptyPasswordError = errorWindowText.Contains("- Enter password");
            bool emptyConfirmPasswordError = errorWindowText.Contains("- Confirm password");

            bool allEmptyFieldsError = emptyFirstNameError && emptyLastNameError && emptyPhoneError &&
                emptyEmailError && emptyConfirmEmailError && emptyPasswordError && emptyConfirmPasswordError;
            Assert.IsTrue(allEmptyFieldsError, "Error of empty fields fails");
            errorWindow.Accept();

             // Можно разделить на несколько отдельных тестов, но я решил соблюсти пункты ТЗ и сделать
             // конкретно 4 теста, поэтому проверка на разные типы валидности ошибок в одном тесте


             // вводим все поля и Email не соответствующий регулярному выражению судя из данных по валидности
             // и проверяем на валидный вывод ошибки

            String firstName = "";
            firstName = getRandomString(5, 16);
            FirstNameEdit.Click();
            FirstNameEdit.Clear();
            FirstNameEdit.SendKeys(firstName);

            String lastName = "";
            lastName = getRandomString(5, 16);
            LastNameEdit.Click();
            LastNameEdit.Clear();
            LastNameEdit.SendKeys(lastName);

            Phone2Edit.Click();
             Phone2Edit.Clear();
             Phone2Edit.SendKeys(getRandomString(10, 55));

        String emailToSend = "";
            emailToSend += getRandomString(5, 25);
          //  emailToSend += "@";
            emailToSend += getRandomString(3, 10);
         //   emailToSend += ".";
            emailToSend += getRandomString(3, 10);

            EmailEdit.Click();
            EmailEdit.Clear();
            EmailEdit.SendKeys(emailToSend);

            SecondEmailEdit.Click();
             SecondEmailEdit.Clear();
             SecondEmailEdit.SendKeys(emailToSend);

             String password = "";
             do
             {
                 password = getRandomString(10, 55);
             }
             while (password.Contains(firstName) || password.Contains(lastName) || password.Contains(emailToSend));

             PasswordEdit.Click();
             PasswordEdit.Clear();
             PasswordEdit.SendKeys(password);

             PasswordConfirmEdit.Click();
             PasswordConfirmEdit.Clear();
             PasswordConfirmEdit.SendKeys(password);

             NextButton2.Click();

             wait.Until(ExpectedConditions.AlertIsPresent());
             IAlert errorWindow2 = driver.SwitchTo().Alert();

             String errorWindow2Text = errorWindow2.Text;

             bool InvalidEmailError = errorWindow2Text.Contains("- Invalid email");
             bool InvalidConfirmEmailError = errorWindow2Text.Contains("- Invalid email confirmation");

             bool IvalidEmailFieldsError = InvalidEmailError && InvalidConfirmEmailError;
             Assert.IsTrue(IvalidEmailFieldsError, "Error of empty fields fails");
             errorWindow.Accept();

             // Email Confirmation test, проверяем ошибку связанную с неверным подтревждением email

             emailToSend = "";
             emailToSend += getRandomString(5, 25);
             emailToSend += "@";
             emailToSend += getRandomString(3, 10);
             emailToSend += ".";
             emailToSend += getRandomString(3, 10);

             EmailEdit.Click();
             EmailEdit.Clear();
             EmailEdit.SendKeys(emailToSend);

             SecondEmailEdit.Click();
             SecondEmailEdit.Clear();
             SecondEmailEdit.SendKeys(emailToSend+"mistake");

             NextButton2.Click();

             wait.Until(ExpectedConditions.AlertIsPresent());
             IAlert errorWindow3 = driver.SwitchTo().Alert();

             String errorWindow3Text = errorWindow3.Text;

             
             bool differentEmailsError = errorWindow3Text.Contains("- Emails are different");

             Assert.IsTrue(differentEmailsError, "Error of different email confirmation fails");
             errorWindow.Accept();

             SecondEmailEdit.Click();
             SecondEmailEdit.Clear();
             SecondEmailEdit.SendKeys(emailToSend);
             // Проверка на валидность ошибки при вводе пароля меньше 5 символов

             String password2 = "";
             do
             {
                 password2 = getRandomString(1, 4);
             }
             while (password2.Contains(firstName) || password2.Contains(lastName) || password2.Contains(emailToSend));

             PasswordEdit.Click();
             PasswordEdit.Clear();
             PasswordEdit.SendKeys(password2);

             PasswordConfirmEdit.Click();
             PasswordConfirmEdit.Clear();
             PasswordConfirmEdit.SendKeys(password2);

             NextButton2.Click();

             wait.Until(ExpectedConditions.AlertIsPresent());
             IAlert errorWindow4 = driver.SwitchTo().Alert();

             String errorWindow4Text = errorWindow4.Text;


             bool shortPasswordError = errorWindow4Text.Contains("- Enter password which is of at least "
             + "5 characters length and doesn't contain your email or full name");

             Assert.IsTrue(shortPasswordError, "Error of short password fails");
             errorWindow.Accept();

             // Проверка валидности ошибки на содержание текста поля First Name в пароле

             String password3 = "";
             do
             {
                 password3 += getRandomString(1, 4);
                 password3 += firstName;
                 password3 += getRandomString(1, 4);
             }
             while (password3.Contains(lastName) || password3.Contains(emailToSend));

             PasswordEdit.Click();
             PasswordEdit.Clear();
             PasswordEdit.SendKeys(password3);

             PasswordConfirmEdit.Click();
             PasswordConfirmEdit.Clear();
             PasswordConfirmEdit.SendKeys(password3);

             NextButton2.Click();

             try
             {
                 wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("ctl00_contentPlaceHolder_btnNext")));
             }
             catch (WebDriverTimeoutException e)
             {
                 Assert.Fail("Page was not loaded");
             }


        IWebElement passwordError = driver.FindElement(By.Id("ctl00_contentPlaceHolder_lblPasswordError"));
        String errorText = passwordError.Text;
        if (!errorText.Equals("Select another password that meets all of the following criteria: is at least "+
            "5 characters; does not contain your email or full name. Type a password which meets these "
            + "requirements in both text boxes."))
        {
            Assert.Fail("Error was not displayed when the password contains First name");
        }


        // Проверка валидности ошибки на содержание текста поля Last Name в пароле

        String password4 = "";
        do
        {
            password4 += getRandomString(1, 4);
            password4 += lastName;
            password4 += getRandomString(1, 4);
        }
        while (password4.Contains(firstName) || password4.Contains(emailToSend));

        IWebElement PasswordEdit2 = driver.FindElement(By.Id("ctl00_contentPlaceHolder_passwordControl_txtPassword"));
        PasswordEdit2.Click();
        PasswordEdit2.Clear();
        PasswordEdit2.SendKeys(password4);


        IWebElement PasswordConfirmEdit2 = driver.FindElement(By.Id("ctl00_contentPlaceHolder_passwordControl_txtPasswordConfirm"));
        PasswordConfirmEdit2.Click();
        PasswordConfirmEdit2.Clear();
        PasswordConfirmEdit2.SendKeys(password4);

        IWebElement NextButton3 = driver.FindElement(By.Id("ctl00_contentPlaceHolder_btnNext"));
        NextButton3.Click();

        try
        {
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("ctl00_contentPlaceHolder_btnNext")));
        }
        catch (WebDriverTimeoutException e)
        {
            Assert.Fail("Page was not loaded");
        }


        IWebElement passwordError2 = driver.FindElement(By.Id("ctl00_contentPlaceHolder_lblPasswordError"));
        String errorText2 = passwordError2.Text;
        if (!errorText.Equals("Select another password that meets all of the following criteria: is at least " +
            "5 characters; does not contain your email or full name. Type a password which meets these "
            + "requirements in both text boxes."))
        {
            Assert.Fail("Error was not displayed when the password contains Last name");
        }


        // Проверка валидности ошибки на содержание текста поля Email в пароле

        String password5 = "";
        do
        {
            password5 += getRandomString(1, 4);
            password5 += emailToSend;
            password5 += getRandomString(1, 4);
        }
        while (password5.Contains(firstName) || password5.Contains(lastName));

        IWebElement PasswordEdit3 = driver.FindElement(By.Id("ctl00_contentPlaceHolder_passwordControl_txtPassword"));
        PasswordEdit3.Click();
        PasswordEdit3.Clear();
        PasswordEdit3.SendKeys(password5);


        IWebElement PasswordConfirmEdit3 = driver.FindElement(By.Id("ctl00_contentPlaceHolder_passwordControl_txtPasswordConfirm"));
        PasswordConfirmEdit3.Click();
        PasswordConfirmEdit3.Clear();
        PasswordConfirmEdit3.SendKeys(password5);

        IWebElement NextButton4 = driver.FindElement(By.Id("ctl00_contentPlaceHolder_btnNext"));
        NextButton4.Click();

        try
        {
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("ctl00_contentPlaceHolder_btnNext")));
        }
        catch (WebDriverTimeoutException e)
        {
            Assert.Fail("Page was not loaded");
        }


        IWebElement passwordError3 = driver.FindElement(By.Id("ctl00_contentPlaceHolder_lblPasswordError"));
        String errorText3 = passwordError3.Text;
        if (!errorText.Equals("Select another password that meets all of the following criteria: is at least " +
            "5 characters; does not contain your email or full name. Type a password which meets these "
            + "requirements in both text boxes."))
        {
            Assert.Fail("Error was not displayed when the password contains Email");
        }  
             

         }

        private String getRandomString(int minLength, int maxLength)
        {
            Random random = new Random();
            Char[] randomChars = new Char[36] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            String rndString = "";
            for (int i = 0; i < random.Next(minLength, maxLength); i++)
                rndString += randomChars[random.Next(0, 35)].ToString();
            return rndString;
        }

    }

}
