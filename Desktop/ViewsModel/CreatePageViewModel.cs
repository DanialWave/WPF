using System.ComponentModel;
using System.Windows.Input;

public class CreatePageViewModel : INotifyPropertyChanged {
    private string _someData;

    public string SomeData {
        get => _someData;
        set {
            _someData = value;
            OnPropertyChanged(nameof(SomeData));
        }
    }

    public ICommand CreateCommand { get; private set; }

    public CreatePageViewModel() {
        CreateCommand = new RelayCommand(ExecuteCreate, CanExecuteCreate);
    }

    private void ExecuteCreate(object parameter) {
        // Проверка валидности данных
        if (string.IsNullOrEmpty(SomeData)) {
            MessageBox.Show("Необходимо заполнить все поля.");
            return;
        }

        try {
            var newItem = new YourItemModel {
                Data = SomeData,
            };
            AddNewItem(newItem);
            MessageBox.Show("Запись успешно создана.");
        } catch (Exception ex) {
            MessageBox.Show($"Произошла ошибка: {ex.Message}");
        }
    }


    private bool CanExecuteCreate(object parameter) {

        return !string.IsNullOrEmpty(_someData);
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName) {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}