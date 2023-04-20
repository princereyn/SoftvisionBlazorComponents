using CSVBlazor.Data;
using Microsoft.AspNetCore.Components;
using SoftvisionBlazorComponents.Shared;
using System.Net.Http.Json;

namespace SoftvisionBlazorComponents.Client.Pages
{
    public partial class FetchData : ComponentBase
    {
        private DataSourceResult<WeatherForecast> _dataSource;

        private async Task LoadWeathers(DataSourceParameter param)
        {
            var response = await Http.PostAsJsonAsync("WeatherForecast", param);
            _dataSource = await response.Content.ReadFromJsonAsync<DataSourceResult<WeatherForecast>>();
        }
    }
}
