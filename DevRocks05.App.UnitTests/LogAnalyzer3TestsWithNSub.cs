namespace DevRocks05.App.UnitTests
{
	using Dependencies;
	using NSubstitute;
	using NUnit.Framework;

	[TestFixture]
	class LogAnalyzer3TestsWithNSub
	{
		[Test]
		public void Analyze_TooShortFileName_CallLogger()
		{
			// Arrange
			var mockLogger = this.FakeLogger();
			var analyzer = this.GetAnalyzer(mockLogger);

			// Act
			analyzer.Analyze("a.txt");

			// Assert
			mockLogger.Received().LogError("Filename too short: a.txt");
		}

		private LogAnalyzer3 GetAnalyzer(ILogger logger)
		{
			return new LogAnalyzer3(logger);
		}

		private ILogger FakeLogger()
		{
			var result = Substitute.For<ILogger>();

			return result;
		}
	}
}
