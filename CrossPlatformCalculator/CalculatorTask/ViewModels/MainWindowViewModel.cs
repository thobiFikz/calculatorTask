namespace CalculatorTask.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    // ICommand properties for binding
    public System.Windows.Input.ICommand DigitCommand { get; }
    public System.Windows.Input.ICommand OperationCommand { get; }
    public System.Windows.Input.ICommand EqualsCommand { get; }
    public System.Windows.Input.ICommand ClearCommand { get; }

    private readonly System.Collections.Generic.Dictionary<string, Models.Operation> _operations;

    private string _display = "0";
    public string Display
    {
        get => _display;
        set => SetProperty(ref _display, value);
    }

    private double _firstOperand;
    private double _secondOperand;
    private bool _isNewEntry = true;
    private Models.Operation _currentOperation;

    public MainWindowViewModel()
    {
        // Initialize operation dictionary
        _operations = new System.Collections.Generic.Dictionary<string, Models.Operation>
        {
            {"Add", new Models.Addition()},
            {"Subtract", new Models.Subtraction()},
            {"Multiply", new Models.Multiplication()},
            {"Divide", new Models.Division()}
        };

        DigitCommand = new CommunityToolkit.Mvvm.Input.RelayCommand<string>(DigitInput);
        OperationCommand = new CommunityToolkit.Mvvm.Input.RelayCommand<string>(OperationInputByName);
        EqualsCommand = new CommunityToolkit.Mvvm.Input.RelayCommand(EqualsInput);
        ClearCommand = new CommunityToolkit.Mvvm.Input.RelayCommand(ClearInput);
    }

    private void OperationInputByName(string opName)
    {
        if (_operations.TryGetValue(opName, out var op))
        {
            OperationInput(op);
        }
    }

    public void DigitInput(string digit)
    {
        if (_isNewEntry || Display == "0")
        {
            Display = digit;
            _isNewEntry = false;
        }
        else
        {
            Display += digit;
        }
    }

    public void OperationInput(Models.Operation operation)
    {
        _firstOperand = double.Parse(Display);
        _currentOperation = operation;
        _isNewEntry = true;
    }

    public void EqualsInput()
    {
        if (_currentOperation != null)
        {
            _secondOperand = double.Parse(Display);
            try
            {
                var result = _currentOperation.Execute(_firstOperand, _secondOperand);
                Display = result.ToString();
            }
            catch (System.Exception ex)
            {
                Display = ex.Message;
            }
            _currentOperation = null;
            _isNewEntry = true;
        }
    }

    public void ClearInput()
    {
        Display = "0";
        _firstOperand = 0;
        _secondOperand = 0;
        _currentOperation = null;
        _isNewEntry = true;
    }
}
