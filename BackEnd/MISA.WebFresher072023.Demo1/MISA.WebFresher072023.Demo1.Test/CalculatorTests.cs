using MISA.WebFresher072023.Demo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher072023.Demo1.UnitTest
{
	[TestFixture]
	public class CalculatorTests
	{
		/// <summary>
		/// Hàm Unit tính tổng
		/// </summary>
		[Test]
		[TestCase(1, 2, 3)]
		[TestCase(2, 3, 5)]
		[TestCase(1, int.MaxValue, int.MaxValue + (long)1)]
		public void Add_ValidInput_Sum2Digit(int x, int y, long expectedResult)
		{
			// Arrange

			var calculator = new Calculator();

			// Act
			var actualResult = calculator.Add(x, y);

			// Assert
			Assert.That(actualResult, Is.EqualTo(expectedResult));
		}

		/// <summary>
		/// Hàm unit test tổng dãy số 
		/// </summary>
		/// <param name="arr">Chuỗi gồm các số cách nhau bởi dấu ','</param>
		/// <param name="expectedResult">Kết quả mong muốn</param>
		/// Created by NpBac - 13/09/2023
		[TestCase("1,2,3", 6)]
		[TestCase("1, 2, 3", 6)]
		[TestCase("", 0)]
		public void Add_ValidInput_SumNumberArray(string arr, int expectedResult)
		{
			// Arrange 
			var calculator = new Calculator();

			// Act 
			var actualResult = calculator.Add(arr);

			// Assert
			Assert.That(actualResult, Is.EqualTo(expectedResult));
		}


		/// <summary>
		/// Hàm unit test xử lý exception khi add
		/// </summary>
		/// <param name="arr">Chuỗi gồm các số cách nhau bởi dấu ','</param>
		/// <param name="expectedResult">Thông tin exception</param>
		/// Created by NpBac - 13/09/2023
		/// 
		[TestCase("1, -2, -3", "Không chấp nhận toán hạng âm: -2, -3")]
		[TestCase("1, -2, a, b", "Chuỗi đầu vào không hợp lệ")]
		public void Add_ValidInput_ThrowException(string arr, string expectedResult)
		{
			// Arrange 
			var calculator = new Calculator();

			// Act & Assert
			try
			{
				var actualResult = calculator.Add(arr);
			}
			catch (Exception ex)
			{
				Assert.That(ex.Message, Is.EqualTo(expectedResult));
			}

		}





	}
}
