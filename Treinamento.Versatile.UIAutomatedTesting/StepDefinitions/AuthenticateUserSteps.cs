using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Treinamento.Versatile.UIAutomatedTesting.Configurations.Helpers;
using Treinamento.Versatile.UIAutomatedTesting.Pages;

namespace Treinamento.Versatile.UIAutomatedTesting.StepDefinitions
{
    [Binding]
    public class AuthenticateUserSteps
    {
        private readonly LoginPage Login;
        private readonly User user;

        public AuthenticateUserSteps(IWebDriver driver)
        {
            Login = new LoginPage(driver);
            user = new User();
        }

        [Given(@"that the user wants to authenticate")]
        public void GivenThatTheUserWantsToAuthenticate()
            => Login.AccessPageLogin(Environments.UrlTst);

        [Given(@"that the user enter the necessary data for authentication ""(.*)"" ""(.*)""")]
        public void GivenThatTheUserEnterTheNecessaryDataForAuthentication(string email, string password)
            => Login.LogIn(email, password);

        [Given(@"that the user inform the necessary data for authentication")]
        public void GivenThatTheUserInformTheNecessaryDataForAuthentication(Table table)
            => Login.LogIn(table.Rows[0]["email"].ToString(), table.Rows[0]["password"].ToString());

        [Given(@"that the user inform the necessary data for authentication")]
        public void GivenThatTheUserInformTheNecessaryDataForAuthentication()
            => Login.LogIn(user.Email, user.Password);

        [Then(@"the user is informed that mandatory fields have not been filled out ""(.*)"" ""(.*)""")]
        public void ThenTheUserIsInformedThatMandatoryFieldsHaveNotBeenFilledOut(string email, string password)
            => Login.ValidateMandatoryFields(email, password);

        [Then(@"the user is informed that authentication has not been carried out")]
        public void ThenTheUserIsInformedThatAuthenticationHasNotBeenCarriedOut()
            => Login.ValidateInvalidLogin();

        [Then(@"the user is informed that the authentication was successful")]
        public void ThenTheUserIsInformedThatTheAuthenticationWasSuccessful()
            => Login.VerifyAuthenticatedUserWithSuccess();
    }
}
