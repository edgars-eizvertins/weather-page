using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WeatherPage.Base;
using WeatherPage.Classes;

namespace WeatherPage.DataProviders
{
    public class ForecastProvider
    {      
		public async Task<WeatherDataView> GetWeather()
		{
			var httpClient = new HttpClient();
			httpClient.BaseAddress = new Uri(AppSettings.Settings.WeatherPage.ApiUrl);
			var data = await httpClient.GetFromJsonAsync<WeatherDataView>(String.Empty);
			return data;
		}
    }
}