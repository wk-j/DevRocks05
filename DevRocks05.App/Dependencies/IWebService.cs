namespace DevRocks05.App.Dependencies
{
	using System;

	public interface IWebService
	{
		void Write(string message);
		void Write(Exception message);
	}
}
