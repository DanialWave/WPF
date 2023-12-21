using System.ComponentModel;
using System.Windows.Input;

public class LoginPageViewModel : INotifyPropertyChanged {
    private string _email;

    public string Email
    {
        get => _email;
        set
        {
            _email = value;
            OnPropertyChanged(nameof(Email));
        }
    }

    public ICommand LoginCommand { get; }

    public LoginPageViewModel() {
        LoginCommand = new RelayCommand(ExecuteLogin, CanExecuteLogin);
    }

        private async void ExecuteLogin(object parameter) {
            if (string.IsNullOrEmpty(Email) || parameter == null)
            {
                MessageBox.Show("Пожалуйста, введите email и пароль.");
            }
        

            string password = parameter.ToString();
            
            bool isAuthenticated = await AuthenticateUser(Email, password);

            if (isAuthenticated) {
                NavigateToMainPage();
            } else {
                MessageBox.Show("Неверный email или пароль.");
            }
        }

    

    private bool CanExecuteLogin(object parameter) {
        return !string.IsNullOrEmpty(Email);
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName) {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}