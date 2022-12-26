using Framework.Models;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System.Collections.ObjectModel;

namespace Framework.Pages
{
    public class GoogleCloudPricingCalculatorPage : AbstractPage
    {
        private readonly By FirstIFrameLocator = By.XPath("//devsite-iframe/child::iframe");

        private readonly By SecondIFrameLocator = By.Id("myFrame");

        private readonly By InstanceFieldLocator = By.XPath("//*[contains(@ng-model, 'computeServer.quantity')]");

        private readonly By OperatingSystemOrSoftwareSelectIconLocator = By.XPath("//*[contains(@aria-label, 'Operating System')]/descendant::span[@class='md-select-icon']");

        private readonly By OperatingSystemOrSoftwareSelectOptionsLocator = By.XPath("//md-option[@value='free'] | //md-option[@value='free']/following-sibling::md-option");

        private readonly By ProvisionModelSelectIconLocator = By.XPath("//*[contains(@aria-label, 'VM Class')]/descendant::span[@class='md-select-icon']");

        private readonly By ProvisionModelSelectOptionsLocator = By.XPath("//md-option[@value='regular'] | //md-option[@value='regular']/following-sibling::md-option");

        private readonly By MachineTypeSelectIconLocator = By.XPath("//*[contains(@aria-label, 'Instance type')]/descendant::span[@class='md-select-icon']");

        private readonly By MachineTypeSelectOptionsLocator = By.XPath("//md-option[@ng-repeat='instance in typeInfo'] ");

        private readonly By AddGpusCheckboxLocator = By.XPath("//*[@aria-label='Add GPUs' and @aria-disabled='false']");

        private readonly By GpuTypeSelectIconLocator = By.XPath("//*[@aria-label='GPU type']");

        private readonly By GpuTypeSelectOptionsLocator = By.XPath("//md-option[contains(@value, 'NVIDIA')] ");

        private readonly By NumberOfGpusSelectIconLocator = By.XPath("//*[@placeholder='Number of GPUs']/descendant::span[@class='md-select-icon']");

        private readonly By NumberOfSelectOptionsLocator = By.XPath("//md-option[contains(@ng-repeat, 'supportedGpuNumbers')]");

        private readonly By LocalSddSelectIconLocator = By.XPath("//*[contains(@aria-label, 'Local SSD')]/descendant::span[@class='md-select-icon']");

        private readonly By LocalSddSelectOptionsLocator = By.XPath("//*[contains(@ng-repeat, 'supportedGpuNumbers')]/parent::md-content/following::md-option");

        private readonly By DataCenterLocationSelectIconLocator = By.XPath("//*[contains(@ng-model, 'soleTenant.location')]/descendant::span[@class='md-select-icon']");

        private readonly By DataCenterLocationSelectOptionsLocator = By.XPath("//*[contains(@ng-repeat, 'inputRegionText.soleTenant')]");

        private readonly By CommittedUsageSelectIconLocator = By.XPath("//*[contains(@aria-label, 'Committed') and contains(@ng-change, 'soleTenant')]/descendant::span[@class='md-select-icon']");

        private readonly By CommittedUsageSelectOptionsLocator = By.XPath("//md-option[contains(@ng-disabled, 'soleTenant.nodeType')] | //md-option[contains(@ng-disabled, 'soleTenant.nodeType')]/following-sibling::md-option");

        private readonly By AddToEstimateButtonLocator = By.XPath("//*[@aria-label='Add to Estimate' and not(contains(@disabled, 'disabled'))]");

        private readonly By EmailEstimateButtonLocator = By.Id("Email Estimate");

        private readonly By EmailTextFieldLocator = By.CssSelector("[type=email]");

        private readonly By SendEmailButtonLocator = By.XPath("//*[@aria-label='Send Email']");

        private readonly By TotalEstimatedCostLocator = By.XPath("//b[contains(text(), 'Total Estimated Cost:')]");

        public IWebElement FirstIFrame => base.WaitAndFindElement(FirstIFrameLocator);

        public IWebElement SecondIFrame => base.WaitAndFindElement(SecondIFrameLocator);

        public IWebElement InstanceField => base.WaitAndFindElement(InstanceFieldLocator);

        public IWebElement OperatingSystemOrSoftwareSelectIcon => base.WaitAndFindElement(OperatingSystemOrSoftwareSelectIconLocator);

        public ReadOnlyCollection<IWebElement> OperatingSystemOrSoftwareOptions
        {
            get
            {
                base.WaitAndFindElement(OperatingSystemOrSoftwareSelectOptionsLocator);
                return base.Driver.FindElements(OperatingSystemOrSoftwareSelectOptionsLocator);
            }
        }

        public IWebElement ProvisionModelSelectIcon => base.WaitAndFindElement(ProvisionModelSelectIconLocator);

        public ReadOnlyCollection<IWebElement> ProvisionModelOptions
        {
            get
            {
                base.Wait.Until(ExpectedConditions.ElementExists(ProvisionModelSelectOptionsLocator));
                return base.Driver.FindElements(ProvisionModelSelectOptionsLocator);
            }
        }

        public IWebElement MachineTypeSelectIcon => base.WaitAndFindElement(MachineTypeSelectIconLocator);

        public ReadOnlyCollection<IWebElement> MachineTypeOptions
        {
            get
            {
                base.Wait.Until(ExpectedConditions.ElementExists(MachineTypeSelectOptionsLocator));
                return base.Driver.FindElements(MachineTypeSelectOptionsLocator);
            }
        }

        public IWebElement AddGpusCheckBox => base.WaitAndFindElement(AddGpusCheckboxLocator);
        
        public IWebElement GpuTypeSelectIcon => base.WaitAndFindElement(GpuTypeSelectIconLocator);

        public ReadOnlyCollection<IWebElement> GpuTypesSelectOptions
        {
            get
            {
                base.Wait.Until(ExpectedConditions.ElementExists(GpuTypeSelectOptionsLocator));
                return base.Driver.FindElements(GpuTypeSelectOptionsLocator);
            }
        }

        public IWebElement NumberOfGpusSelectIcon => base.WaitAndFindElement(NumberOfGpusSelectIconLocator);

        public ReadOnlyCollection<IWebElement> NumberOfGpusOptions
        {
            get
            {
                base.Wait.Until(ExpectedConditions.ElementExists(NumberOfSelectOptionsLocator));
                return base.Driver.FindElements(NumberOfSelectOptionsLocator);
            }
        }

        public IWebElement LocalSddSelectIcon => base.WaitAndFindElement(LocalSddSelectIconLocator);

        public ReadOnlyCollection<IWebElement> LocalSddOptions
        {
            get
            {
                base.Wait.Until(ExpectedConditions.ElementExists(LocalSddSelectOptionsLocator));
                return base.Driver.FindElements(LocalSddSelectOptionsLocator);
            }
        }

        public IWebElement DataCenterLocationSelectIcon => base.WaitAndFindElement(DataCenterLocationSelectIconLocator);

        public ReadOnlyCollection<IWebElement> DataCenterLocationOptions
        {
            get
            {
                base.Wait.Until(ExpectedConditions.ElementExists(DataCenterLocationSelectOptionsLocator));
                return base.Driver.FindElements(DataCenterLocationSelectOptionsLocator);
            }
        }

        public IWebElement CommittedUsageSelectIcon => base.WaitAndFindElement(CommittedUsageSelectIconLocator);

        public ReadOnlyCollection<IWebElement> CommittedUsageOptions
        {
            get
            {
                base.Wait.Until(ExpectedConditions.ElementExists(CommittedUsageSelectOptionsLocator));
                return base.Driver.FindElements(CommittedUsageSelectOptionsLocator);
            }
        }

        public IWebElement AddToEstimateButton => base.WaitAndFindElement(AddToEstimateButtonLocator);

        public IWebElement EmailEstimateButton => base.WaitAndFindElement(EmailEstimateButtonLocator);

        public IWebElement EmailTextField => base.WaitAndFindElement(EmailTextFieldLocator);

        public IWebElement SendEmailButton => base.WaitAndFindElement(SendEmailButtonLocator);

        public IWebElement TotalEstimatedCost => base.WaitAndFindElement(TotalEstimatedCostLocator);

        public GoogleCloudPricingCalculatorPage(IWebDriver driver) : base(driver) { }

        public void EnterValuesOfComputeEngine(ComputeEngine computeEngine)
        {
            Driver.SwitchTo().Frame(FirstIFrame);
            Driver.SwitchTo().Frame(SecondIFrame);

            InstanceField.Click();
            InstanceField.SendKeys(computeEngine.NumberOfInstances);

            OperatingSystemOrSoftwareSelectIcon.Click();
            ChooseOption(OperatingSystemOrSoftwareOptions, computeEngine.OperatingSystemOrSoftwareText);

            ProvisionModelSelectIcon.Click();
            ChooseOption(ProvisionModelOptions, computeEngine.ProvisionModelText);

            MachineTypeSelectIcon.Click();
            ChooseOption(MachineTypeOptions, computeEngine.MachineTypeText);

            AddGpusCheckBox.Click();
            GpuTypeSelectIcon.Click();
            ChooseOption(GpuTypesSelectOptions, computeEngine.GpuTypeText);

            NumberOfGpusSelectIcon.Click();
            ChooseOption(NumberOfGpusOptions, computeEngine.NumberOfGpus);

            LocalSddSelectIcon.Click();
            ChooseOption(LocalSddOptions, computeEngine.LocalSddText);

            DataCenterLocationSelectIcon.Click();
            ChooseOption(DataCenterLocationOptions, computeEngine.DataCenterLocationText);

            CommittedUsageSelectIcon.Click();
            ChooseOption(CommittedUsageOptions, computeEngine.CommittedUsageText);
        }

        private void ChooseOption(ReadOnlyCollection<IWebElement> options, string text)
        {
            foreach (IWebElement option in options)
            {
                if (option.GetAttribute("value") == text)
                {
                    option.Click();
                    break;
                }
            }
        }
    }
}
