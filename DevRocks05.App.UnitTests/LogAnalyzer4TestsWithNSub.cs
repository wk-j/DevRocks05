namespace DevRocks05.App.UnitTests
{
	using Dependencies;
	using NSubstitute;
	using NUnit.Framework;
	using System;

	[TestFixture]
	public class LogAnalyzer4TestsWithNSub
	{
		[Test]
		public void Analyze_LoggerThrows_CallsWebServiceWithNSub()
		{
			// Arrange
			var stubLogger = this.FakeLogger();
			var mockWebService = this.FakeWebService();
			var analyzer = new LogAnalyzer4(stubLogger, mockWebService);

			analyzer.Analyze("Short.txt");

			// Assert
			mockWebService.Received().Write(Arg.Is<string>(s => s.Contains("fake exception")));
		}

		private ILogger FakeLogger()
		{
			var result = Substitute.For<ILogger>();
			result
				.When(logger => logger.LogError(Arg.Any<string>()))
				.Do(info =>
				{
					throw new Exception("fake exception");
				});

			return result;
		}

		private IWebService FakeWebService()
		{
			return Substitute.For<IWebService>();
		}
	}
}
