namespace DevRocks05.App
{
	using Dependencies;
	using System;

	public class LogAnalyzer4
	{
		private ILogger logger;
		private IWebService webService;

		public LogAnalyzer4(ILogger logger,IWebService webService)
		{
			this.logger = logger;
			this.webService = webService;
		}

		public int MinNameLength { get; } = 10;

		public void Analyze(string filename)
		{
			if (filename.Length < MinNameLength)
			{
				try
				{
					this.logger.LogError(string.Format("Filename too short: {0}",filename));
				}
				catch (Exception ex)
				{
					this.webService.Write($"Error From Logger: {ex}");
				}
			}
		}
	}
}
