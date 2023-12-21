namespace Unit_Tests;

public class LoginPageViewModelTests
{
    [Test]
    public void LoginCommand_CannotExecute_WhenEmailIsEmpty()
    {
        var viewModel = new LoginPageViewModel
        {
            Email = "",
            Password = "validPassword"
        };

        Assert.IsFalse(viewModel.LoginCommand.CanExecute(null));
    }

    [Test]
    public void LoginCommand_CanExecute_WhenEmailAndPasswordAreValid()
    {
        var viewModel = new LoginPageViewModel
        {
            Email = "user@example.com",
            Password = "validPassword"
        };
        Assert.IsTrue(viewModel.LoginCommand.CanExecute(null));
    }

    [TestFixture]
    public class RegisterPageViewModelTests
    {
        [Test]
        public void RegisterCommand_CannotExecute_WhenEmailIsInvalid()
        {
            var viewModel = new RegisterPageViewModel
            {
                Email = "invalidEmail",
                Password = "validPassword"
            };
            Assert.IsFalse(viewModel.RegisterCommand.CanExecute(null));
        }

    }

    [TestFixture]
    public class CreatePageViewModelTests
    {
        [Test]
        public void CreateCommand_CanExecute_WhenRequiredDataIsProvided()
        {
            var viewModel = new CreatePageViewModel
            {
                SomeData = "New Data"
            };

            Assert.IsTrue(viewModel.CreateCommand.CanExecute(null));
        }
    }
}