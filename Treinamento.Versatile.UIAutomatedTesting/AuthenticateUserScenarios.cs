using NUnit.Framework;
using OpenQA.Selenium;
using Treinamento.Versatile.UIAutomatedTesting.Configurations.Factories;
using Treinamento.Versatile.UIAutomatedTesting.Configurations.Helpers;

namespace Treinamento.Versatile.UIAutomatedTesting
{
    public class AuthenticateUserScenarios
    {
        public ActionFactory Actions;
        public User _User;
        public By InputEmail = By.Id("email");
        public By InputSenha = By.Id("senha");
        public By BtnEntrar = By.XPath("//button[contains(text(), 'Entrar')]");
        public By MsgEmailObg = By.XPath("//div[contains(text(), 'Email é um campo obrigatório')]");
        public By MsgSenhaObg = By.XPath("//div[contains(text(), 'Senha é um campo obrigatório')]");
        public By MsgLoginInv = By.XPath("//div[contains(text(), 'Problemas com o login do usuário')]");

        [SetUp]
        public void Init()
        {
            Actions = new ActionFactory();
            Actions._driver = Actions.CreateDriver(Browsers.EDGE);
            Actions.Maximize();
            Actions.Navigate("https://seubarriga.wcaquino.me/login");
            _User = new User();
        }

        [TearDown]
        public void ClearUp() => Actions.Quit();

        [Test]
        public void TC01_ValidarCamposObrigatorios()
        {
            Actions.Click(BtnEntrar);
            Actions.ExistsElement(MsgEmailObg, "No mandatory email message was displayed");
            Actions.ExistsElement(MsgSenhaObg, "No mandatory password message was displayed");
        }

        [Test]
        public void TC02_ValidarLoginInvalido()
        {
            Actions.SendKeys(InputEmail, _User.InvalidEmail);
            Actions.SendKeys(InputSenha, _User.Password);
            Actions.Click(BtnEntrar);
            Actions.ExistsElement(MsgLoginInv, "Invalid login message was not displayed");
        }

        [Test]
        public void TC03_RealizarLogIn()
        {
            Actions.SendKeys(InputEmail, _User.Email);
            Actions.SendKeys(InputSenha, _User.Password);
            Actions.Click(BtnEntrar);
            Actions.ExistsElement(
                By.XPath($"//div[contains(text(),'Bem vindo, {_User.Name}')]"),
                "An error occurred while logging in to the system"
            );            
        }            

    }
}