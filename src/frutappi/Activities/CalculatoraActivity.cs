
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace frutappi.Activities
{
    [Activity(Label = "CalculatoraActivity")]
    public class CalculatoraActivity : Activity
    {
        private EditText calculatorText;

        private string[] numbers = new string[2];
        private string @operator;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_calculator);
            // Create your application here
            calculatorText = FindViewById<EditText>(Resource.Id.calculatorText);
        }
        [Java.Interop.Export("whateveryoulike")]
        public void whateveryoulike(View v)
        {
            Button button = (Button)v;
            if ("0123456789.".Contains(button.Text))
            {
                AddDigitOrDecimalPoint(button.Text);
            } else if ("÷×+-".Contains(button.Text)) {
                AddOperator(button.Text);
            } else if ("=" == button.Text)
            {
                Calculate();
            } else
            {
                Erase();
            }
                
        }
        private void AddDigitOrDecimalPoint(string value)
        {
            int index = @operator == null ? 0 : 1;

            if (value == "." && numbers[index].Contains("."))
                return;

            numbers[index] += value;

            UpdateCalculatorText();
        }
        private void UpdateCalculatorText() {
            int index = @operator == null ? 0 : 1;
            calculatorText.Text = $"{numbers[index]}";
            calculatorText.SetSelection(calculatorText.Text.Length);
        }//=> calculatorText.Text = $"{numbers[0]} {@operator} {numbers[1]}";
        private void AddOperator(string value)
        {
            if (numbers[1] != null)
            {
                Calculate(value);
                return;
            }

            @operator = value;

            UpdateCalculatorText();
        }
        private void Calculate(string newOperator = null)
        {
            double? result = null;
            double? first = numbers[0] == null ? null : (double?)double.Parse(numbers[0]);
            double? second = numbers[1] == null ? null : (double?)double.Parse(numbers[1]);

            switch (@operator)
            {
                case "÷":
                    result = first / second;
                    break;
                case "×":
                    result = first * second;
                    break;
                case "+":
                    result = first + second;
                    break;
                case "-":
                    result = first - second;
                    break;
            }

            if (result != null)
            {
                numbers[0] = result.ToString();
                @operator = newOperator;
                numbers[1] = null;
                UpdateCalculatorText();
            }
        }
        private void Erase()
        {
            numbers[0] = numbers[1] = null;
            @operator = null;
            UpdateCalculatorText();
        }

      
    }
}
