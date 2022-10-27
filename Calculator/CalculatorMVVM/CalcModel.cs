using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorMVVM.Models
{
	internal class CalcModel : INotifyPropertyChanged
	{
		private double _firstNumber;
		private double _secondNumber;
		private double _result;


		public bool IsFirstNumberDone { get; set; }
		public bool IsResultReady{ get; set; }
		public bool IsLastComma { get; set; }

		public double FirstNumber
		{
			get { return _firstNumber; }
			set
			{
				_firstNumber = value;
				OnPropertyChanged(nameof(FirstNumber));
			}
		}

		public double SecondNumber
		{
			get { return _secondNumber; }
			set
			{
				_secondNumber = value;
				OnPropertyChanged(nameof(SecondNumber));
			}
		}

		public double Result
		{
			get { return _result; }
			set
			{
				_result = value;
				OnPropertyChanged(nameof(Result));
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName] string prop = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
		}

		public void ClearAll()
		{
			FirstNumber = 0;
			SecondNumber = 0;
			Result = 0;
			IsResultReady = false;
			IsFirstNumberDone = false;
		}

		public void Calculate(char operation)
		{
			switch (operation)
			{
				case '+':
					Result = FirstNumber + SecondNumber;
					break;

				case '-':
					Result = FirstNumber - SecondNumber;
					break;

				case '*':
					Result = FirstNumber * SecondNumber;
					break;

				case '/':
					Result = FirstNumber / SecondNumber;
					break;
			}
		}
	}
}
