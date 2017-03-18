namespace DevRocks05.App.UnitTests
{
	using NUnit.Framework;
	using System;

	[TestFixture]
	public class LogAnalyzerTests
	{
		[Test]
		public void IsValidLogFileName_BadExtension_ReturnsFalse()
		{
			// Arrange
			var analyzer = this.GetAnalyzer();

			// Act
			var actual = analyzer.IsValidLogFileName("filewithbadextension.foo");

			// Assert
			Assert.IsFalse(actual);
		}

		[Test]
		public void IsValidLogFileName_GoodExtensionLowercase_ReturnsTrue()
		{
			// Arrange
			var analyzer = this.GetAnalyzer();

			// Act
			var actul = analyzer.IsValidLogFileName("filewithgoodextension.slf");

			// Assert
			Assert.IsTrue(actul);
		}

		[Test]
		public void IsValidLogFileName_GoodExtensionUppercase_ReturnsTrue()
		{
			// Arrange
			var analyzer = this.GetAnalyzer();

			// Act
			var actual = analyzer.IsValidLogFileName("filewithgoodextension.SLF");

			// Assert
			Assert.IsTrue(actual);
		}

		[TestCase("filewithgoodextension.SLF")]
		[TestCase("filewithgoodextension.slf")]
		public void IsValidLogFileName_ValidExtensions_ReturnsTrue(string file)
		{
			// Arrange
			var analyzer = this.GetAnalyzer();

			// Act
			var result = analyzer.IsValidLogFileName(file);

			// Assert
			Assert.True(result);
		}

		[TestCase("filewithgoodextension.SLF", true)]
		[TestCase("filewithgoodextension.slf", true)]
		[TestCase("filewithbadextension.foo", false)]
		public void IsValidLogFileName_VariousExtensions_ChecksThem(string file, bool expected)
		{
			// Arrange
			var analyzer = this.GetAnalyzer();

			// Act
			bool result = analyzer.IsValidLogFileName(file);

			// Assert
			Assert.AreEqual(expected, result);
		}

		//[Test]
		//[ExpectedException(typeof(ArgumentException), ExpectedMessage = "filename has to be provided")]
		//public void IsValidLogFileName_EmptyFileName_ThrowsException()
		//{
		//	// Arrange
		//	var analyzer = this.MakeAnalyzer();

		//	// Act && Assert
		//	analyzer.IsValidLogFileName(string.Empty);
		//}

		[Test]
		public void IsValidLogFileName_EmptyFileName_Throws()
		{
			// Arrange
			var analyzer = this.GetAnalyzer();

			// Act
			var actual = Assert.Throws<ArgumentException>(() => analyzer.IsValidLogFileName(""));
			
			// Assert
			StringAssert.Contains("filename has to be provided", actual.Message);
		}

		private LogAnalyzer GetAnalyzer()
		{
			return new LogAnalyzer();
		}
	}
}
