namespace DevRocks05.App
{
	using System;

	public class LogAnalyzer2
	{
		private readonly IExtensionManager extensionManager;

		public LogAnalyzer2(IExtensionManager extensionManager)
		{
			this.extensionManager = extensionManager;
		}

		public bool IsValidLogFileName(string fileName)
		{
			if (string.IsNullOrWhiteSpace(fileName))
			{
				throw new ArgumentException("filename has to be provided");
			}

			var isValidFileExtension = this.extensionManager.IsValid(fileName);

			var isValidLogFileName = fileName.StartsWith("log_", StringComparison.OrdinalIgnoreCase);

			return (isValidFileExtension && isValidLogFileName);
		}
	}

	public class FileExtensionManager : IExtensionManager
	{
		public bool IsValid(string fileName)
		{
			return (fileName.EndsWith(".SLF", StringComparison.OrdinalIgnoreCase));
		}
	}

	public interface IExtensionManager
	{
		bool IsValid(string fileName);
	}
}
