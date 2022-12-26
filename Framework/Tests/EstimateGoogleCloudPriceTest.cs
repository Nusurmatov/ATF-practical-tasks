using Framework.Models;
using Framework.Utils;
using NUnit.Framework;
using System;

namespace Framework.Tests
{
    [TestFixture]
    public class EstimateGoogleCloudPriceTest : BaseTest
    {
        [Test]
        [Category("Integration")]
        [Category("Regression")]
        public void EstimatePriceTest()
        {
            GoogleCloudMainPage.GoTo();
            GoogleCloudMainPage.GoToPricingCalculatorPage();
            Console.WriteLine(Driver.Title);

            Assert.IsTrue(Driver.Title.Contains("Google Cloud Pricing Calculator"));

            string randomEmail = YopMailPage.GenerateRandomEmail(Driver);
            ComputeEngine computeEngine = new ComputeEngine()
            {
                NumberOfInstances = "4",
                OperatingSystemOrSoftwareText = "free",
                ProvisionModelText = "regular",
                MachineTypeText = "CP-COMPUTEENGINE-VMIMAGE-E2-STANDARD-8",
                GpuTypeText = "NVIDIA_TESLA_V100",
                NumberOfGpus = "8",
                LocalSddText = "24",
                DataCenterLocationText = "europe-west3",
                CommittedUsageText = "1",
                EmailTextField = randomEmail
            };

            PricingCalculatorPage.EnterValuesOfComputeEngine(computeEngine);
            JavaScriptExecutorUtil.ClickElement(Driver, PricingCalculatorPage.AddToEstimateButton);

            PricingCalculatorPage.EmailEstimateButton.Click();
            PricingCalculatorPage.EmailTextField.Click();
            PricingCalculatorPage.EmailTextField.SendKeys(computeEngine.EmailTextField);
            PricingCalculatorPage.SendEmailButton.Click();

            string expectedResult = PricingCalculatorPage.TotalEstimatedCost.Text;
            string actualResult = YopMailPage.GetMessageFromInbox(computeEngine.EmailTextField);
            Console.WriteLine(expectedResult);
            Console.WriteLine(actualResult);

            Assert.AreEqual(StringUtil.ExtractNumberFromString(expectedResult), StringUtil.ExtractNumberFromString(actualResult));
        }
    }
}
