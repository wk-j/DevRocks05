namespace DevRocks05.App.UnitTests
{
	using Dependencies;
	using NUnit.Framework;

	[TestFixture]
	class LogAnalyzer3TestsWithHandWrittenFakes
	{
		[Test]
		public void Analyze_TooShortFileName_CallsLogger()
		{
			// Arrange
			var logger = new FakeLogger();
			var analyzer = this.GetAnalyzer(logger);

			// Act
			analyzer.Analyze("a.txt");

			// Assert
			StringAssert.Contains("too short", logger.LastError);
		}

		private LogAnalyzer3 GetAnalyzer(ILogger logger)
		{
			return new LogAnalyzer3(logger);
		}

		private FakeLogger FakeLogger()
		{
			return new FakeLogger();
		}
	}

	public class FakeLogger : ILogger
	{
		public string LastError { get; private set; }

		public void LogError(string message)
		{
			this.LastError = message;
		}
	}
}
