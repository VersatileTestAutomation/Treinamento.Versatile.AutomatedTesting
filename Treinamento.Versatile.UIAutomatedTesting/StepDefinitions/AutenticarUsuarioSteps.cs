using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Treinamento.Versatile.UIAutomatedTesting.Configurations.Helpers;
using Treinamento.Versatile.UIAutomatedTesting.Pages;

namespace Treinamento.Versatile.UIAutomatedTesting.StepDefinitions
{
    [Binding]
    public class AutenticarUsuarioSteps
    {
        private readonly AutenticarPage Login;
        private readonly User user;

        public AutenticarUsuarioSteps(IWebDriver driver)
        {
            Login = new AutenticarPage(driver);
            user = new User();
        }

        [Given(@"Dado que o usuario queira realizar autenticacao")]
        public void DadoDadoQueOUsuarioQueiraRealizarAutenticacao() 
            => Login.AccessPageLogin(Environments.UrlTst);

        [Given(@"E que o usuario informe os dados necessarios para autenticacao ""(.*)"" ""(.*)""")]
        public void DadoEQueOUsuarioInformeOsDadosNecessariosParaAutenticacao(string email, string password) 
            => Login.LogIn(email, password);

        [Given(@"E que o usuario informe os dados necessarios para autenticacao")]
        public void DadoEQueOUsuarioInformeOsDadosNecessariosParaAutenticacao(Table table) 
            => Login.LogIn(table.Rows[0]["email"].ToString(), table.Rows[0]["senha"].ToString());

        [Given(@"E que o usuario informe os dados necessarios para autenticacao")]
        public void DadoEQueOUsuarioInformeOsDadosNecessariosParaAutenticacao()
            => Login.LogIn(user.Email, user.Password);

        [Then(@"Entao o usuario e informado que campos obrigatorios nao foram preenchidos ""(.*)"" ""(.*)""")]
        public void EntaoEntaoOUsuarioEInformadoQueCamposObrigatoriosNaoForamPreenchidos(string email, string password) 
            => Login.ValidateMandatoryFields(email, password);

        [Then(@"Entao o usuario e informado que nao foi realizada autenticacao")]
        public void EntaoEntaoOUsuarioEInformadoQueNaoFoiRealizadaAutenticacao() 
            => Login.ValidateInvalidLogin();

        [Then(@"Entao o usuario e informado que foi realizada a autenticacao com sucesso")]
        public void EntaoEntaoOUsuarioEInformadoQueFoiRealizadaAAutenticacaoComSucesso() 
            => Login.VerifyAuthenticatedUserWithSuccess();
    }
}
