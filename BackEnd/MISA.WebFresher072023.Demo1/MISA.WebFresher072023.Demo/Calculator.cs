namespace MISA.WebFresher072023.Demo
{
	public class Calculator
	{
		/// <summary>
		/// Tính tông hai số
		/// </summary>
		/// <param name="x">Toán hạng 1</param>
		/// <param name="y">Toán hạng 2</param>
		/// <returns>Tổng 2 số</returns>
		/// Created by npBac - 13/09/2023
		public int Add(int x, int y)
		{
			return x + y;
		}


		/// <summary>
		/// Tính tổng dãy số
		/// </summary>
		/// <param name="arr">Chuỗi các số cách nhau bởi dấu ','</param>
		/// <returns>Tổng dãy số</returns>
		/// <exception cref="Exception">Không chấp nhận toán hạng âm</exception>
		/// <exception cref="Exception">Chuỗi đầu vào không hợp lệ</exception>
		/// Created by NpBac - 13/09/2023
		public long Add(string arr)
		{
			if (string.IsNullOrEmpty(arr))
			{
				return 0;
			}

			var list = arr.Split(",");
			var negativeNumber = new List<int>();
			long sum = 0;
			foreach (var item in list)
			{
				long number = 0;
				try
				{
					number = int.Parse(item.Trim());
				}
				catch
				{
					throw new Exception("Chuỗi đầu vào không hợp lệ");
				}

				sum += number;
			}

			if (negativeNumber.Count > 0)
			{
				throw new Exception($"Không chấp nhận toán hạng âm: {string.Join(", ", negativeNumber)}");
			}

			return sum;

		}

	}
}
