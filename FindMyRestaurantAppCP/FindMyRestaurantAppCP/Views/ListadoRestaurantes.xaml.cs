using FindMyRestaurantAppCP.Models;
using FindMyRestaurantAppCP.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FindMyRestaurantAppCP.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListadoRestaurantes : ContentPage
	{
        private List<string> _list;
		public ListadoRestaurantes ()
		{
			InitializeComponent ();

            var list = new List<string>();
            getRestaurantes();

            listaRestaurantes.ItemsSource = _list;
		}

        public async void getRestaurantes()
        {
            try
            {
                var response = await new HttpClient().GetAsync(UrlConstants.Url + "/api/restaurante");

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    var posts = JsonConvert.DeserializeObject<IEnumerable<string[]>>(result);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var list = new List<string>();
                        foreach (var rest in posts)
                        {
                            list.Add(rest.First());
                        }

                        _list = list;
                    }
                }

                _list = new List<string>();
            }
            catch (Exception e)
            {
                _list = new List<string>()
                {
                    "Adrian Tropical",
                    "Fridays",
                    "McDonalds"
                };
            }
        }
	}
}