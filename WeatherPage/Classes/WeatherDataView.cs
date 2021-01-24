using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WeatherPage.Classes
{
	public class WeatherDataView {
		[JsonPropertyName("lat")]
		public decimal Lat { get; set; }

		[JsonPropertyName("lon")]
		public decimal Lon { get; set; }

		[JsonPropertyName("timezone")]
		public string Timezone { get; set; }

		[JsonPropertyName("timezone_offset")]
		public int TimezoneOffset { get; set; }

		[JsonPropertyName("current")]
		public WeatherInfoView Current { get; set; }

		[JsonPropertyName("minutely")]
		public ICollection<MinutelyView> Minutely { get; set; }

		[JsonPropertyName("hourly")]
		public ICollection<WeatherInfoView> Hourly { get; set; }
		
		[JsonPropertyName("daily")]
		public ICollection<DailyView> Daily { get; set; }

		[JsonPropertyName("alerts")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		public ICollection<AlertView> Alerts { get; set; } 
	}

	public class AlertView
	{
		[JsonPropertyName("sender_name")]
		public string SenderName { get; set; }

		[JsonPropertyName("event")]
		public string Event { get; set; }

		[JsonPropertyName("start")]
		public DateTime Start { get; set; }

		[JsonPropertyName("end")]
		public DateTime End {get; set; }

		[JsonPropertyName("description")]
		public string Description {get; set; }
	}
 
	public class WeatherView
	{
		[JsonPropertyName("id")]
		public int Id { get; set; }

		[JsonPropertyName("main")]
		public string Main { get; set; }

		[JsonPropertyName("description")]
		public string Description { get; set; }

		[JsonPropertyName("icon")]
		public string Icon { get; set; } 
 	}

	public class WeatherInfoView {
		[JsonPropertyName("date")]
		public DateTime Date { get; set; }

		[JsonPropertyName("sunrise")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		public DateTime Sunrise { get; set; }

		[JsonPropertyName("sunset")]
		public DateTime Sunset { get; set; }

		[JsonPropertyName("temperature")]
		public decimal Temperature { get; set; }

		[JsonPropertyName("feels_like")]
		public decimal FeelsLike { get; set; }

		[JsonPropertyName("pressure")] 
		public int Pressure { get; set; }

		[JsonPropertyName("humidity")] 
		public int Humidity { get; set; }

		[JsonPropertyName("uv_index")]
		public decimal UvIndex { get; set; }

		[JsonPropertyName("clouds_percents")]
		public int CloudsPercents { get; set; }

		[JsonPropertyName("visibility_meters")]
		public int VisibilityMeters { get; set; }

		[JsonPropertyName("wind_speed_meters")]
		public decimal WindSpeedMeters { get; set; }

		[JsonPropertyName("wind_degrees")]
		public int WindDegrees { get; set; }

		public string WindDegreesView {
			get {				
				return DegreesToCompass(this.WindDegrees);
			}			
		}

		private string DegreesToCompass(double degrees)
		{
			var value = (int)((degrees/22.5) + 0.5);
			var compassElements = new string[] {
				"N","NNE","NE","ENE","E","ESE", "SE", "SSE","S","SSW","SW","WSW","W","WNW","NW","NNW"
			};
			return compassElements[(value % 16)];
		}			

		[JsonPropertyName("weather")]
		public ICollection<WeatherView> Weather { get; set; }

		[JsonPropertyName("probability_of_precipitation")]
		public decimal ProbabilityOfPrecipitation { get; set; }

		public string ProbabilityOfPrecipitationView {
			get {
				return (ProbabilityOfPrecipitation / 100) + " %";
			}
		}

		[JsonPropertyName("rain")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		public RainView Rain { get; set; }

		[JsonPropertyName("snow")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		public SnowView Snow { get; set; }
	}

	public class MinutelyView {
		[JsonPropertyName("date")]
		public DateTime Date { get; set; }

		[JsonPropertyName("precipitation_mm")]
		public decimal PrecipitationMm { get; set; } 
	}    

	public class RainView: Dictionary<string, decimal> {}

	public class SnowView: Dictionary<string, decimal> {}

	public class TemperatureView {
		[JsonPropertyName("day")]
		public decimal Day { get; set; }

		[JsonPropertyName("min")]
		public decimal Min { get; set; }

		[JsonPropertyName("max")]
		public decimal Max { get; set; }

		[JsonPropertyName("night")]
		public decimal Night { get; set; }

		[JsonPropertyName("evening")]
		public decimal Evening { get; set; }

		[JsonPropertyName("morning")] 
		public decimal Morning { get; set; } 
	}

 	public class DailyView    {
		[JsonPropertyName("date")]
		public DateTime Date { get; set; }

		public string DateView {
			get {
				return Date.ToString("dd.MM.yyyy");
			}
		}

		[JsonPropertyName("sunrise")]
		public DateTime Sunrise { get; set; }

		[JsonPropertyName("sunset")]
		public DateTime Sunset { get; set; }

		[JsonPropertyName("temperature")]
		public TemperatureView Temperature { get; set; }

		[JsonPropertyName("feels_like")]
		public TemperatureView FeelsLike { get; set; }

		[JsonPropertyName("pressure")]
		public int Pressure { get; set; }

		[JsonPropertyName("humidity")]
		public int Humidity { get; set; }

		[JsonPropertyName("dew_point")]
		public decimal DewPoint { get; set; }

		[JsonPropertyName("wind_speed_meters")]
		public decimal WindSpeedMeters { get; set; }

		[JsonPropertyName("wind_gust")]
		public decimal WindGust { get; set; }

		[JsonPropertyName("wind_degrees")]
		public int WindDegrees { get; set; }

		[JsonPropertyName("weather")]
		public ICollection<WeatherView> Weather { get; set; }

		[JsonPropertyName("clouds_percents")]
		public int CloudsPercents { get; set; } 
		
		[JsonPropertyName("probability_of_precipitation")]
		public decimal ProbabilityOfPrecipitation { get; set; }

		[JsonPropertyName("uvi")] 
		public decimal Uvi { get; set; } 
		
		[JsonPropertyName("rain_volume_mm")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		public decimal? RainVolume { get; set; }

		[JsonPropertyName("snow_volume_mm")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		public decimal? SnowVolume { get; set; }
	}
}