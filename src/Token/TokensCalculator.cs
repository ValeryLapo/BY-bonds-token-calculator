using System.Globalization;

namespace Token;

internal static class TokensCalculator
{
	internal static void CalculateInitial()
	{
		var tokenData = ReadInputData();

		var periodCalculator = new PeriodCalculator();
		var paymentCalculator = new PaymentsCalculator();
		var periods = periodCalculator.GetPeriods(tokenData);
		var payments = paymentCalculator.CalculatePayments(tokenData, periods);

		var totalPayments = 0d;
		foreach (var payment in payments)
		{
			totalPayments += payment.Value;
			Console.WriteLine($"{payment.Period.Start:dd.MM.yyyy} - {payment.Period.End:dd.MM.yyyy}. Будет выплачено {payment.Value:F2} {payment.Date:dd.MM.yyyy}");
		}

		var totalDays = (payments.Last().Period.End - payments.First().Period.Start).Days;
		var yearProfit = Math.Pow((totalPayments + tokenData.Price) / tokenData.Price, 365d / totalDays) - 1;
		Console.WriteLine($"Годовой доход: {yearProfit:p}");
		BondData ReadInputData()
		{
			BondData data = new BondData();
			Console.Write("Введите номинал: ");
			var inputBondPrice = Console.ReadLine();
			data.Price = Convert.ToInt32(inputBondPrice);

			Console.Write("Введите день месяца выплаты дохода: ");
			var inputDay = Console.ReadLine();
			data.PaymentDay = Convert.ToInt32(inputDay);

			Console.Write("Введите период выплаты дохода (1-месяц, 3- квартал): ");
			var inputPeriod = Console.ReadLine();
			data.Period = inputPeriod switch
			{
				"1" => Period.Month,
				"3" => Period.Quarter,
				_ => throw new Exception("Invalid period")
			};


			Console.Write("Дата покупки токена: ");
			var inputBuyDate = Console.ReadLine();
			data.BuyDate = DateTime.ParseExact(inputBuyDate!, "dd.MM.yyyy", CultureInfo.InvariantCulture);

			Console.Write("Дата погашения: ");
			var inputYieldDate = Console.ReadLine();
			data.YieldDate = DateTime.ParseExact(inputYieldDate!, "dd.MM.yyyy", CultureInfo.InvariantCulture);

			Console.Write("Процентная ставка: ");
			var inputInterestRate = Console.ReadLine();
			data.InterestRate = Convert.ToDouble(inputInterestRate);
			return data;
		}
	}

	internal static void CalculateSecond()
	{
		var tokenData = ReadInputData();

		var periodCalculator = new PeriodCalculator();
		var paymentCalculator = new PaymentsCalculator();
		var periods = periodCalculator.GetPeriods(tokenData);
		var payments = paymentCalculator.CalculatePayments(tokenData, periods);

		var totalPayments = 0d;
		foreach (var payment in payments)
		{
			totalPayments += payment.Value;
			Console.WriteLine($"{payment.Period.Start:dd.MM.yyyy} - {payment.Period.End:dd.MM.yyyy}. Будет выплачено {payment.Value:F2} {payment.Date:dd.MM.yyyy}");
		}

		var totalDays = (payments.Last().Period.End - payments.First().Period.Start).Days;

		var yearProfit = Math.Pow((tokenData.Price + totalPayments) / (tokenData.BuyPrice + tokenData.Commission), 365d / totalDays) - 1;
		Console.WriteLine($"Годовой доход: {yearProfit:p}");
		SecondaryBondData ReadInputData()
		{
			SecondaryBondData data = new SecondaryBondData();
			Console.Write("Введите цену: ");
			var inputBuyBondPrice = Console.ReadLine();
			var buyBondPrice = Convert.ToDouble(inputBuyBondPrice.Replace(".",","));

			Console.Write("Введите количество: ");
			var inputBondNumber = Console.ReadLine();
			var bondNumber = Convert.ToInt32(inputBondNumber);

			data.BuyPrice = buyBondPrice * bondNumber;

			Console.Write("Введите номинал: ");
			var inputBondPrice = Console.ReadLine();
			var bondPrice = Convert.ToInt32(inputBondPrice);
			data.Price = Convert.ToInt32(bondPrice * bondNumber);

			Console.Write("Введите день месяца выплаты дохода: ");
			var inputDay = Console.ReadLine();
			data.PaymentDay = Convert.ToInt32(inputDay);

			Console.Write("Введите период выплаты дохода (1-месяц, 3- квартал): ");
			var inputPeriod = Console.ReadLine();
			data.Period = inputPeriod switch
			{
				"1" => Period.Month,
				"3" => Period.Quarter,
				_ => throw new Exception("Invalid period")
			};


			Console.Write("Дата покупки токена: ");
			var inputBuyDate = Console.ReadLine();
			data.BuyDate = DateTime.ParseExact(inputBuyDate!, "dd.MM.yyyy", CultureInfo.InvariantCulture);

			Console.Write("Дата погашения: ");
			var inputYieldDate = Console.ReadLine();
			data.YieldDate = DateTime.ParseExact(inputYieldDate!, "dd.MM.yyyy", CultureInfo.InvariantCulture);

			Console.Write("Процентная ставка: ");
			var inputInterestRate = Console.ReadLine();
			data.InterestRate = Convert.ToDouble(inputInterestRate);
			return data;
		}
	}

}