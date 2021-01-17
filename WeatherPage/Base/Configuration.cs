using System.IO;
using Microsoft.Extensions.Configuration;

namespace WeatherPage.Base
{
    public static class AppSettings
	{
		public static Settings Settings { get; private set; }

		static AppSettings()
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("config.default.json")
				.AddJsonFile("config.json", true);

			Settings = builder.Build().Get<Settings>();
		}
	}

	public class Settings
	{
		public WeatherPage WeatherPage { get; set; }
	}

	public class WeatherPage
	{
		public string Port { get; set; }
		public string ApiUrl { get; set; }	
	}
}