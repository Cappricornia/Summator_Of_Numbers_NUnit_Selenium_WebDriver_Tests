using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SummatorOfNumbersNUNitSeleniumTests
{
    public class WebDriverTests
    {

        private WebDriver driver;
        

        [SetUp]
        public void Setup()
        {
            var opt = new ChromeOptions();
            opt.AddArgument("--headless");
            this.driver = new ChromeDriver(opt);
            driver.Manage().Window.Maximize();
            driver.Url = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com/number-calculator/";
        }

        [TearDown]  
        public void Teardown() 
        { 
            this.driver.Quit();

        }  


        [Test]
        public void Test_Add_Two_Valid_Numbers()
        {
            driver.FindElement(By.CssSelector("#number1")).SendKeys("15");
           
            var operation = driver.FindElement(By.Id("operation"));
            
            var selectElement = new SelectElement(operation);


            // TESTING DROPDOWN MENU

            //select by value 
            //selectElement.SelectByValue("+");

            // select by text
            //selectElement.SelectByText("+(sum)");
            selectElement.SelectByIndex(1);
            
            driver.FindElement(By.CssSelector("#number2")).SendKeys("7");
            driver.FindElement(By.CssSelector("#calcButton")).Click();
            var calculateText = driver.FindElement(By.CssSelector("#result")).Text;
            Assert.That(calculateText, Is.EqualTo("Result: 22"));
        }


        [Test]
        public void Test_Substract_Two_Valid_Numbers()
        {
            driver.FindElement(By.CssSelector("#number1")).SendKeys("15");
            
            var operation = driver.FindElement(By.Id("operation"));
           
            var selectElement = new SelectElement(operation);

            selectElement.SelectByIndex(2);

            driver.FindElement(By.CssSelector("#number2")).SendKeys("5");
            driver.FindElement(By.CssSelector("#calcButton")).Click();
            var calculateText = driver.FindElement(By.CssSelector("#result")).Text;
            Assert.That(calculateText, Is.EqualTo("Result: 10"));
        }

        [Test]
        public void Test_Multiply_Two_Positive_Numbers()
        {
            driver.FindElement(By.CssSelector("#number1")).SendKeys("15");

           

            var operation = driver.FindElement(By.Id("operation"));
            
            var selectElement = new SelectElement(operation);

            selectElement.SelectByIndex(3);

            driver.FindElement(By.CssSelector("#number2")).SendKeys("5");
            driver.FindElement(By.CssSelector("#calcButton")).Click();
            var calculateText = driver.FindElement(By.CssSelector("#result")).Text;
            Assert.That(calculateText, Is.EqualTo("Result: 75"));
        }

        [Test]
        public void Test_Divide_Two_Positive_Numbers()
        {
            driver.FindElement(By.CssSelector("#number1")).SendKeys("15");

            var operation = driver.FindElement(By.Id("operation"));
            
            var selectElement = new SelectElement(operation);

            selectElement.SelectByIndex(4);

            driver.FindElement(By.CssSelector("#number2")).SendKeys("5");
            driver.FindElement(By.CssSelector("#calcButton")).Click();
            var calculateText = driver.FindElement(By.CssSelector("#result")).Text;
            Assert.That(calculateText, Is.EqualTo("Result: 3"));
        }

        [Test]
        public void Test_Add_TwoInvalid_Input()
        {
            driver.FindElement(By.CssSelector("#number1")).SendKeys("hi");

            var operation = driver.FindElement(By.Id("operation"));
            
            var selectElement = new SelectElement(operation);

            selectElement.SelectByValue("+");

            driver.FindElement(By.CssSelector("#number2")).SendKeys("5");
            driver.FindElement(By.CssSelector("#calcButton")).Click();
            var calculateText = driver.FindElement(By.CssSelector("#result")).Text;
            Assert.That(calculateText, Is.EqualTo("Result: invalid input"));
        }

        [Test]
        public void Test_Reset_Button_Works_Correctly()
        {
            //	Fill the form and click [Calculate]
            driver.FindElement(By.CssSelector("#number1")).SendKeys("5");
            var operation = driver.FindElement(By.Id("operation"));
            var selectElement = new SelectElement(operation);
            selectElement.SelectByValue("+");
            driver.FindElement(By.CssSelector("#number2")).SendKeys("5");
            driver.FindElement(By.CssSelector("#calcButton")).Click();

            var number1 = driver.FindElement(By.CssSelector("#number1")).GetAttribute("value");
            Assert.IsNotEmpty(number1);
            var number2 = driver.FindElement(By.CssSelector("#number2")).GetAttribute("value");
            Assert.IsNotEmpty(number2);

            
            var calculateText = driver.FindElement(By.CssSelector("#result")).Text;
            Assert.That(calculateText, Is.EqualTo("Result: 10"));
            Assert.IsNotEmpty(calculateText);

            // Reset App and Assert that all field are empty
            driver.FindElement(By.CssSelector("#resetButton")).Click();
            number1 = driver.FindElement(By.CssSelector("#number1")).GetAttribute("value");
            Assert.IsEmpty(number1);
            number2 = driver.FindElement(By.CssSelector("#number2")).GetAttribute("value");
            Assert.IsEmpty(number2);
            calculateText = driver.FindElement(By.CssSelector("#result")).Text;
            Assert.IsEmpty(calculateText);

        }
    }
}
