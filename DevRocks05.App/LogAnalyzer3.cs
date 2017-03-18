namespace DevRocks05.App
{
	using Dependencies;

	public class LogAnalyzer3
	{
		private ILogger logger;

		public int MinNameLength { get; } = 6;

		public LogAnalyzer3(ILogger logger)
		{
			this.logger = logger;
		}

		public void Analyze(string filename)
		{
			if (filename.Length < MinNameLength)
			{
				this.logger.LogError($"Filename too short: {filename}");
			}
		}
	}
}
