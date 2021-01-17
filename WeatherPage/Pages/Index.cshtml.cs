using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using WeatherPage.Classes;
using WeatherPage.DataProviders;

namespace WeatherPage.Pages
{
    public class IndexModel : PageModel
    {
		public WeatherDataView Data { get; set; }

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }        

		public async Task<IActionResult> OnGetAsync() {
			var dataProvider = new ForecastProvider();
			this.Data = await dataProvider.GetWeather();			
			return Page();
		}
    }
}
