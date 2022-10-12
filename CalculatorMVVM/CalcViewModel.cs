using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CalculatorMVVM.Models;

namespace CalculatorMVVM.ViewModels
{
	internal class CalcViewModel : INotifyPropertyChanged
	{
		private CalcModel _calculator = new CalcModel();

		public CalcModel Calculator
		{
			get { return _calculator; }
			set
			{
				_calculator = value;
				OnPropertyChanged(nameof(Calculator));
			}
		}

		private char _operator = '+';

		public char Operator
		{
			get { return _operator; }
			set
			{
				_operator = value;
				OnPropertyChanged(nameof(Operator));
			}
		}

		private ICommand _addCommand;
		private ICommand _subCommand;
		private ICommand _mulCommand;
		private ICommand _divCommand;
		private ICommand _equCommand;

		public ICommand AddCommand
		{
			get
			{
				return _addCommand ??
				  (_addCommand = new RelayCommand(obj =>
				  {
					  Calculator.Result = Calculator.FirstNumber + Calculator.SecondNumber;
					  Operator = '+';
					  Calculator.IsFirstNumberDone = true;
				  }));
			}
		}
		public ICommand SubCommand
		{
			get
			{
				return _subCommand ??
				  (_subCommand = new RelayCommand(obj =>
				  {
					  Calculator.Result = Calculator.FirstNumber + Calculator.SecondNumber;
					  Operator = '-';
					  Calculator.IsFirstNumberDone = true;
				  }));
			}
		}
		public ICommand MulCommand
		{
			get
			{
				return _mulCommand ??
				  (_mulCommand = new RelayCommand(obj =>
				  {
					  Calculator.Result = Calculator.FirstNumber + Calculator.SecondNumber;
					  Operator = '*';
					  Calculator.IsFirstNumberDone = true;
				  }));
			}
		}
		public ICommand DivCommand
		{
			get
			{
				return _divCommand ??
				  (_divCommand = new RelayCommand(obj =>
				  {
					  Calculator.Result = Calculator.FirstNumber + Calculator.SecondNumber;
					  Operator = '/';
					  Calculator.IsFirstNumberDone = true;
				  }));
			}
		}
		public ICommand EquCommand
		{
			get
			{
				return _equCommand ??
				  (_equCommand = new RelayCommand(obj =>
				  {
					  Calculator.Calculate(Operator); ;
					  Calculator.IsFirstNumberDone = false;
					  Calculator.IsResultReady = true;
				  }));
			}
		}

		private ICommand _commaCommand;

		public ICommand CommaCommand
		{
			get
			{
				return _commaCommand ??
				  (_commaCommand = new RelayCommand(obj =>
				  {
					  if (!Calculator.IsFirstNumberDone)
					  {
						  if (!Calculator.FirstNumber.ToString().Contains(','))
							  Calculator.FirstNumber = double.Parse(Calculator.FirstNumber.ToString() + ",1");
					  }
					  else
					  {
						  if (!Calculator.SecondNumber.ToString().Contains(','))
							  Calculator.SecondNumber = double.Parse(Calculator.SecondNumber.ToString() + ",1");
					  }
				  }));
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName] string prop = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
		}

		private RelayCommand _changeNumbersCommand;
		public RelayCommand ChangeNumbersCommand
		{
			get
			{
				return _changeNumbersCommand ??
					(_changeNumbersCommand = new RelayCommand(obj =>
					{
						if (Calculator.IsResultReady)
							Calculator.ClearAll();

						if (!Calculator.IsFirstNumberDone)
						{
							if (Calculator.FirstNumber.ToString().EndsWith(",1"))
								Calculator.FirstNumber = double.Parse(Calculator.FirstNumber.ToString().Remove(Calculator.FirstNumber.ToString().Length - 1, 1) + obj as string);
							else
							Calculator.FirstNumber = double.Parse(Calculator.FirstNumber.ToString() + obj as string);
						}
						else
						{
							if (Calculator.SecondNumber.ToString().EndsWith(",1"))
								Calculator.SecondNumber = double.Parse(Calculator.SecondNumber.ToString().Remove(Calculator.SecondNumber.ToString().Length - 1, 1) + obj as string);
							else
								Calculator.SecondNumber = double.Parse(Calculator.SecondNumber.ToString() + obj as string);
						}
					}));
			}
		}
	}
}
