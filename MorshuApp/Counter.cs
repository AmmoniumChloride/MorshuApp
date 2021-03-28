using Microsoft.Win32;
using System;
using System.Globalization;

namespace MorshuApp
{
	class Counter : ObservableObject
	{
		private double input;
		private double result;
		private double coefficient;
		private string message;

		public string Input
		{
			get => input.ToString();
			set
			{
				bool ok = double.TryParse(value.Replace(',','.'), NumberStyles.Float,CultureInfo.InvariantCulture,out double parsed);
				if (ok && input != parsed)
				{
					input = parsed;
					OnPropertyChanged(nameof(Input));
					Result = input * coefficient;
					switch (parsed)
					{
						case 69:
							Message = "Ayy lmao";
							break;
						default:
							Message = "Барыга ты ёбаная";
							break;
					}
					if (parsed < 0) Message = "А там точно минус?..";
				}
				else if (string.IsNullOrEmpty(value))
				{
					input = 0;
					OnPropertyChanged(nameof(Input));
					Result = input * coefficient;
				}
				else
				{
					switch (value.ToLower())
					{
						case "sakagami":
							Message = "pnh";
							break;
						case "ass":
							Message = "we can";
							break;
						case "sorry":
							Message = "sorry for what?";
							break;
						default:
							Message = "Ты дурак, дядь?";
							break;
					}
				}
			}
		}
		public double Coefficient
		{
			get => Convert.ToInt32((coefficient - 1) * 100);
			set
			{				
				coefficient = value/100 + 1;
				if(coefficient < 0) Message = "Скидку решили сделать?";
				OnPropertyChanged(nameof(Coefficient));
				Result = input * coefficient;
				WriteCoef();
					
			}
		}
		public double Result
		{
			get => result;
			set
			{
				if (result != value)
				{
					result = value;
					OnPropertyChanged(nameof(Result));
				}
			}
		}

		public string Message
		{
			get => message;
			set
			{
				if (message != value)
				{
					message = value;
					OnPropertyChanged(nameof(Message));
				}
			}
		}

		public Counter()
		{
			input = 0;
			var coef = GetCoefFromReg();
			coefficient = 1;
			if (coef != 0)
				coefficient = coef;
			result = 0;
		}
		private void WriteCoef()
		{
			var key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\MorshuApp");
			key.SetValue("coef", coefficient, RegistryValueKind.DWord);
		}
		private double GetCoefFromReg()
		{
			var key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\MorshuApp");
			return key == null? 0 : Convert.ToDouble(key.GetValue("coef"));
		}
	}
	
}
