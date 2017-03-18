namespace DevRocks05.App.UnitTests
{
	using Dependencies;
	using NUnit.Framework;
	using System;

	[TestFixture]
	class LogAnalyzer4TestsWithHandWrittenFakes
	{
		[Test]
		public void Analyze_LoggerThrows_CallsWebService()
		{
			// Arrange
			var stubLogger = this.FakeLogger();
			var mockWebService = this.FakeWebService();
			var analyzer = this.GetAnalyzer(stubLogger, mockWebService);
			var tooShortFileName = "abc.ext";

			// Act
			analyzer.Analyze(tooShortFileName);

			// Assert
			Assert.That(mockWebService.MessageToWebService
						, Does.Contain("fake exception"));
		}

		private FakeWebService FakeWebService()
		{
			return new FakeWebService();
		}

		private FakeLogger2 FakeLogger()
		{
			var result = new FakeLogger2();
			result.WillThrow = new Exception("fake exception");

			return result;
		}

		private LogAnalyzer4 GetAnalyzer(ILogger logger, IWebService webService)
		{
			return new LogAnalyzer4(logger, webService);
		}
	}

	public class FakeWebService : IWebService
	{
		public string MessageToWebService { get; private set; }

		public void Write(string message)
		{
			this.MessageToWebService = message;
		}

		public void Write(Exception message)
		{
			throw new NotImplementedException();
		}
	}

	public class FakeLogger2 : ILogger
	{
		public Exception WillThrow { get; set; }

		public string LoggerGotMessage { get; private set; }

		public void LogError(string message)
		{
			this.LoggerGotMessage = message;

			if (this.WillThrow != null)
			{
				throw this.WillThrow;
			}
		}
	}
}
