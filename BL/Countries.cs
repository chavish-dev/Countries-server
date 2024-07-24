using BL.DTOs;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Countries : ICountries
    {
        public async Task<List<CountryDTO>> getAsiaCountries()
        {
            var client = new HttpClient();
            var url = "https://restcountries.com/v2/all";
            var asianCountries = new List<CountryDTO>();

            try
            {
                var response = await client.GetStringAsync(url);
                var countries = JArray.Parse(response);

                foreach (var country in countries)
                {
                    if (country["region"]?.ToString() == "Asia")
                    {
                        var asianCountry = new CountryDTO
                        {
                            Name = country["name"]?.ToString(),
                            Flag = country["flags"]?["svg"]?.ToString(),
                            Capital = country["capital"]?.ToString(),
                            Region = country["region"]?.ToString(),
                            Currencies = ParseCurrencies(country["currencies"])


                        };
                        asianCountries.Add(asianCountry);

                    }
                }
               
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
            return asianCountries;
        }

        private List<CurrencyDTO> ParseCurrencies(JToken currenciesToken)
        {
            var currencies = new List<CurrencyDTO>();

            if (currenciesToken != null && currenciesToken.Type == JTokenType.Array)
            {
                foreach (var currency in currenciesToken)
                {
                    var currencyDTO = new CurrencyDTO
                    {
                        Code = currency["code"]?.ToString(),
                        Name = currency["name"]?.ToString(),
                        Symbol = currency["symbol"]?.ToString()
                    };
                    currencies.Add(currencyDTO);
                }
            }

            return currencies;
        }
    }
}
