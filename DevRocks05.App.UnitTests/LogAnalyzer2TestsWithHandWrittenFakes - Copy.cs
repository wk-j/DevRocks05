namespace DevRocks05.App.UnitTests
{
	using NUnit.Framework;

	[TestFixture]
	class LogAnalyzer2TestsWithHandWrittenFakes
	{
		[Test]
		public void Analyze_TooShortFileName_ReturnsFalse()
		{
			// Arrange
			var extensionManager = this.FakeExtensionManager();
			var analyzer = this.GetAnalyzer(extensionManager);

			// Act
			var actual = analyzer.IsValidLogFileName("a.txt");

			// Assert
			Assert.IsFalse(actual);
		}

		private LogAnalyzer2 GetAnalyzer(IExtensionManager extensionManager)
		{
			return new LogAnalyzer2(extensionManager);
		}

		private FileExtensionManager FakeExtensionManager()
		{
			return new FileExtensionManager();
		}
	}

	public class FileExtensionManager : IExtensionManager
	{
		public bool IsValid(string fileName)
		{
			return true;
		}
	}
}
