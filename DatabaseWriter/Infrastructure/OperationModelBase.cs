using DatabaseWriter.Views;
using System;
using System.IO;
using System.Linq;
using System.Security;
using System.Windows;
using System.Windows.Controls;

namespace DatabaseWriter.Infrastructure
{
    public abstract class OperationModelBase
    {
        /* Every "operation model" class needs a reference to the InputPickerView 
        to configure it the way it needs and to map input fields */
        protected InputPickerView _inputView;

        public abstract void Execute(IProgress<int> progress);

        /* Because I reuse single InputPickerView class and 
        operations have different number of required input fields, 
        I map input fields in every "operation model" class the way it needs using the reference */
        public abstract bool MapInputData();

        protected UIElement GetGridRowChildElement(int rowIndex)
        {
            return _inputView.Grid.Children.Cast<UIElement>().First(e => Grid.GetRow(e) == rowIndex);
        }

        protected void DisplayValidationMessage(int rowIndex, string text)
        {
            ((StackPanel)GetGridRowChildElement(rowIndex))
                .Children
                .OfType<TextBlock>()
                .First()
                .Text = text;
        }

        protected void SetFilePath(ref string filePath, string value, int gridRowIndex)
        {
            var fileAccessErrorText = "You don't have the required permissions to access this file!";
            try
            {
                FileInfo fi = new FileInfo(value);
                if (fi.Exists) filePath = value;
                else DisplayValidationMessage(gridRowIndex, "The specified file doesn't exist!");
            }
            catch (ArgumentException)
            {
                DisplayValidationMessage(gridRowIndex, "The path to a file is not valid!\n" +
                    "Please, choose file or enter into the text box correct path.");
            }
            catch (PathTooLongException)
            {
                DisplayValidationMessage(gridRowIndex, "The specified path, file name, or both exceed the system-defined maximum length!");
            }
            catch (NotSupportedException)
            {
                DisplayValidationMessage(gridRowIndex, "The file path should not contain a colon in the middle of the string!");
            }
            catch (SecurityException)
            {
                DisplayValidationMessage(gridRowIndex, fileAccessErrorText);
            }
            catch (UnauthorizedAccessException)
            {
                DisplayValidationMessage(gridRowIndex, fileAccessErrorText);
            }
        }

    }
}
