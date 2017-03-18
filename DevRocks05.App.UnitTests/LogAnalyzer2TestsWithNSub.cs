namespace DevRocks05.App.UnitTests
{
	using NSubstitute;
	using NUnit.Framework;

	[TestFixture]
	class LogAnalyzer2TestsWithNSub
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

		private IExtensionManager FakeExtensionManager()
		{
			var result = Substitute.For<IExtensionManager>();
			result.IsValid(Arg.Any<string>())
				.Returns(true);

			return result;
		}
	}
}
