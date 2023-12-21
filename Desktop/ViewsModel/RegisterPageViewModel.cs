using System.ComponentModel;
using System.Windows.Input;

public class RegisterPageViewModel : INotifyPropertyChanged {
    private string _email;
    private string _password;
    private string _name;
    private string _token;

    public string Email {
        get => _email;
        set {
            _email = value;
            OnPropertyChanged(nameof(Email));
        }
    }

    public string Password
    {
        get => _password;
        set
        {
            _password = value;
            OnPropertyChanged(nameof(Password));
        }
    }
    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            OnPropertyChanged(nameof(Name));
        }
    }
    public ICommand RegisterCommand { get; private set; }

    public RegisterPageViewModel() {
        RegisterCommand = new RelayCommand(ExecuteRegisterCommand, CanExecuteRegisterCommand);
    }

    private async void ExecuteRegisterCommand(object parameter) {
        string password = parameter as string;

        if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(password)) {
            MessageBox.Show("Email и пароль не могут быть пустыми.");
            return;
        }
        var result = await RegisterUser(Email, password);

        if (result.IsSuccess) {
            MessageBox.Show("Регистрация прошла успешно.");
        } else {
            MessageBox.Show(result.ErrorMessage);
        }
    }

    private async Task<(bool IsSuccess, string ErrorMessage)> RegisterUser(string email, string password) {
        try {
            return (true, string.Empty);
        } catch (Exception ex) {
            return (false, ex.Message);
        }
    }


    private bool CanExecuteRegisterCommand(object parameter) {
        return !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password);
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName) {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}