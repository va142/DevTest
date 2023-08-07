using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;





namespace Test._1
{

    [TestClass]
    public class UnitTest1
    {
       
        private IWebDriver driver;
        private string baseURL;
        private object ExpectedConditions;

        [TestInitialize]
        public void TestInitialize()
        {
            if (driver == null)
            {
                // Config WebDriver-ul pentru Chrome
                 driver = new ChromeDriver();
                //driver = new FirefoxDriver(); using OpenQA.Selenium.Firefox;
                baseURL = "http://localhost:18020"; // web
            }
        }


        [TestMethod]
        public void TestMethod1()
        {
            // Deschidem pagina de logare
            driver.Navigate().GoToUrl("http://localhost:18020/login");
            Thread.Sleep(2000);

            // Introducem utilizatorul și parola valide
            IWebElement usernameField = driver.FindElement(By.Id("Email"));
            IWebElement passwordField = driver.FindElement(By.Id("pass"));
            IWebElement loginButton = driver.FindElement(By.CssSelector(".btn.primary-bg-c.w-100.text-white.mb-2"));
            IWebElement homePageElement = null;

            // Verificăm dacă câmpurile de autentificare sunt vizibile și accesibile
            Assert.IsTrue(usernameField.Displayed);
            Assert.IsTrue(usernameField.Enabled);
            Assert.IsTrue(passwordField.Displayed);
            Assert.IsTrue(passwordField.Enabled);

           
            usernameField.SendKeys(TestDataProvider.ValidEmail);
            passwordField.SendKeys(TestDataProvider.ValidPassword);
            
            loginButton.Click();

            // Așteptăm până când se face redirecționarea către pagina principală
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            Thread.Sleep(2000);

            // Verificăm că URL-ul curent este cel așteptat (pagina principală)
            Assert.AreEqual(baseURL + "/", driver.Url);

            // Verificăm că elementul de pe pagina principală este afișat, ceea ce înseamnă că autentificarea a fost realizată cu succes
            homePageElement = driver.FindElement(By.CssSelector(".container.home-page"));
            Assert.IsTrue(homePageElement.Displayed);
            Thread.Sleep(2000);

            Logout();
        }

        [TestMethod]
        public void TestMethod2()
        {



            driver.Navigate().GoToUrl("http://localhost:18020/login");
            Thread.Sleep(2000);


            IWebElement usernameField = driver.FindElement(By.Id("Email"));
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement loginButton = driver.FindElement(By.CssSelector(".btn.primary-bg-c.w-100.text-white.mb-2"));

            Assert.IsTrue(usernameField.Displayed);
            Assert.IsTrue(usernameField.Enabled);

            usernameField.SendKeys(TestDataProvider.ValidEmail);
            loginButton.Click();

            // Verificați că a apărut mesajul de eroare
            IWebElement errorMessage = driver.FindElement(By.CssSelector("span[data-valmsg-for='Password']"));
            Assert.IsTrue(errorMessage.Displayed);
            Assert.AreEqual("Introduceti parola", errorMessage.Text);
            // pauză de 2 secunde înainte de închiderea driver-ului
            Thread.Sleep(2000);


        }

        [TestMethod]
        public void TestMethod3()
        {
            // Deschidem pagina de logare
            driver.Navigate().GoToUrl("http://localhost:18020/login");
           // Thread.Sleep(2000);

            // Utilizăm biblioteca Bogus pentru a genera o adresă de email invalidă
            //var faker = new Faker();
            //string email = faker.Internet.Email(); // Va genera o adresă de email aleatorie, inclusiv unele invalide

            // Introducem adresa de email invalidă și parola validă
            IWebElement usernameField = driver.FindElement(By.Id("Email"));
            IWebElement passwordField = driver.FindElement(By.Id("pass"));
            IWebElement loginButton = driver.FindElement(By.CssSelector(".btn.primary-bg-c.w-100.text-white.mb-2"));

            //emailField.SendKeys(email);
            usernameField.SendKeys(TestDataProvider.ValidEmail);
            passwordField.SendKeys(TestDataProvider.InvalidPassword);
            loginButton.Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement errorMessage = driver.FindElement(By.CssSelector(".text-danger.validation-summary-errors li"));

            // Verifică că mesajul de eroare este afișat și conține textul așteptat
            Assert.IsTrue(errorMessage.Displayed);
            //Thread.Sleep(2000);
            Assert.AreEqual("You have entered an invalid email or password", errorMessage.Text);

        }

        [TestMethod]
        public void TestMethod4()
        {
            // Deschidem pagina de logare
            driver.Navigate().GoToUrl("http://localhost:18020/login");
           // Thread.Sleep(2000);

            // Introducem adresa de email invalidă și parola validă
            IWebElement usernameField = driver.FindElement(By.Id("Email"));
            IWebElement passwordField = driver.FindElement(By.Id("pass"));
            IWebElement loginButton = driver.FindElement(By.CssSelector(".btn.primary-bg-c.w-100.text-white.mb-2"));

            //emailField.SendKeys(email);
            usernameField.SendKeys(TestDataProvider.InvalidEmail);
            passwordField.SendKeys(TestDataProvider.ValidPassword);
            loginButton.Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement errorMessage = driver.FindElement(By.CssSelector(".text-danger.validation-summary-errors li"));

            // Verifică că mesajul de eroare este afișat și conține textul așteptat
            Assert.IsTrue(errorMessage.Displayed);
            //Thread.Sleep(2000);
            Assert.AreEqual("You have entered an invalid email or password", errorMessage.Text);
        }

        [TestMethod]

        public void TestMethod5()
        {
            // Deschidem pagina de logare
            driver.Navigate().GoToUrl("http://localhost:18020/login");
            Thread.Sleep(2000);

            // Introducem adresa de email invalidă și parola validă
            IWebElement usernameField = driver.FindElement(By.Id("Email"));
            IWebElement passwordField = driver.FindElement(By.Id("pass"));
            IWebElement loginButton = driver.FindElement(By.CssSelector(".btn.primary-bg-c.w-100.text-white.mb-2"));

            //emailField.SendKeys(email);
            usernameField.SendKeys(TestDataProvider.InvalidEmail);
            passwordField.SendKeys(TestDataProvider.InvalidPassword);
            loginButton.Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement errorMessage = driver.FindElement(By.CssSelector(".text-danger.validation-summary-errors li"));

            // Verifică că mesajul de eroare este afișat și conține textul așteptat
            Assert.IsTrue(errorMessage.Displayed);
            Assert.AreEqual("You have entered an invalid email or password", errorMessage.Text);
           // Thread.Sleep(4000);

        }

        [TestMethod]
        public void TestMethod6()
        {
            driver.Navigate().GoToUrl("http://localhost:18020/login");

            IWebElement passwordField = driver.FindElement(By.Id("pass"));
            IWebElement loginButton = driver.FindElement(By.CssSelector(".btn.primary-bg-c.w-100.text-white.mb-2"));

            Assert.IsTrue(passwordField.Displayed);
            Assert.IsTrue(passwordField.Enabled);

            passwordField.SendKeys(TestDataProvider.ValidPassword);
            loginButton.Click();

            // Așteaptă până când elementul de eroare devine vizibil în DOM
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            Thread.Sleep(2000);
            IWebElement errorMessage = wait.Until(d => d.FindElement(By.CssSelector("span[data-valmsg-for='Email']")));
           // Assert.IsFalse(errorMessage.Displayed);
            Assert.IsTrue(errorMessage.Displayed);
            Assert.AreEqual("Introduceti adresa de email", errorMessage.Text);

        }

        [TestMethod]
        public void TestMethod7()
        {
       
            driver.Navigate().GoToUrl("http://localhost:18020/login");
            Thread.Sleep(2000);

            IWebElement usernameField = driver.FindElement(By.Id("Email"));
            IWebElement passwordField = driver.FindElement(By.Id("pass"));
            IWebElement viewPasswordButton = driver.FindElement(By.Id("eye"));


            // Verificăm dacă câmpurile de autentificare sunt vizibile și accesibile
            Assert.IsTrue(usernameField.Displayed);
            Assert.IsTrue(usernameField.Enabled);
            Assert.IsTrue(passwordField.Displayed);
            Assert.IsTrue(passwordField.Enabled);


            usernameField.SendKeys(TestDataProvider.ValidEmail);
            passwordField.SendKeys(TestDataProvider.ValidPassword);
            viewPasswordButton.Click();


            // Asigură-te că parola este vizibilă
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            Assert.AreEqual("text", passwordField.GetAttribute("type"));

            // Dă clic din nou pe butonul de vizualizare pentru a ascunde parola
            viewPasswordButton.Click();

            // Asigură-te că parola este din nou de tipul "password"
            Assert.AreEqual("password", passwordField.GetAttribute("type"));

        }



        [TestCleanup]
        public void TestCleanup()
        {

            // Închideți browser-ul după finalizarea testului
            if (driver != null)
            {
                driver.Quit();
                driver = null;
            }
        }

        private void Logout()
        {
            // Găsește elementul pentru "My Account" după id-ul "contulMeuDropDown" și dă clic pe el
            IWebElement myAccountDropdown = driver.FindElement(By.Id("contulMeuDropDown"));
            myAccountDropdown.Click();

            // Așteaptă ca meniul dropdown să fie vizibil
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement logoutLink = driver.FindElement(By.CssSelector("a.dropdown-item[href='/logout']"));

            // Găsește elementul pentru "Logout" după clasa "dropdown-item" și atributul "href"
            logoutLink.Click();
        }
    }
}
