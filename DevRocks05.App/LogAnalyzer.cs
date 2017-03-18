namespace DevRocks05.App
{
	using System;

	public class LogAnalyzer
	{
		public bool IsValidLogFileName(string fileName)
		{
			if (string.IsNullOrWhiteSpace(fileName))
			{
				throw new ArgumentException("filename has to be provided");
			}

			return (fileName.EndsWith(".SLF", StringComparison.OrdinalIgnoreCase));
		}
	}
}
