# conversion-starter
A WPF starter for making text converters and putting them into one gui.

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
4. Repeat for each `IConverter` implementation you need.
5. Construct a `MainWindow` using the `MainWindowViewModel` and show. 
