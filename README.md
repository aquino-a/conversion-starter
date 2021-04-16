# conversion-starter
A WPF class library with a simple GUI for interfacing with custom text converters.

## When to use

If you have a one off project that requires specific data to be changed into different formats,
use this library to easily interface with the converters and copy the output.
Any time you have data in csv or text format that you need to transform,
you can interface it with this library. 

Some examples:
- SQL statements.
- WPF control tags
- HTML or React tags
- Text configurations


## How to use

1. Implement `IConverter` directly or with an adapter.
2. Give the implementation to a `ConversionViewModel`.
3. Add the `ConversionViewModel` to a `MainWindowViewModel` in the form of a `TabItem`
4. Set `ConversionViewModel.ShowArguments` to true for the arguments textbox to be passed to the converter.
5. Repeat for each `IConverter` implementation you need.
6. Construct a `MainWindow` using the `MainWindowViewModel` and show. 

## Example


`IConverter` implementation
```C#
public class YourConverter : IConverter
{
    private readonly CsvParser<YourObject> _parser;
    
    public YourConverter(CsvParser<YourObject> parser)
    {
        _parser = parser;
    }

    public List<string> Convert(string filePath)
    {
        return _parser.ReadFromFile(filePath, Encoding.UTF8)
                       .Where(r => r.IsValid)
                       .Select(r => r.Result.ToString())
                       .ToList();
    }

    public List<string> Convert(string filePath, string arguments)
    {
        return this.Convert(filePath);
    }
}
```

Using the `IConverter`
```C#
var mwvm = new MainWindowViewModel();
mwvm.Tabs.Add
    (
        new Conversion.Model.TabItem()
        {
            Header = "Read block conversion",
            Content = new ConversionViewModel(Converter)
            {
                ShowArguments = true
            }
        }
    );
var mw = new MainWindow(mwvm);
mw.Show();
```
