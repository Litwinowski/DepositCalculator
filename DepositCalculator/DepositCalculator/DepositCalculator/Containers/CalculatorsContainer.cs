using DepositCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace DepositCalculator.Containers
{
    public class CalculatorsContainer
    {
        public async Task<List<Calculator>> GetAllCalculators(string url = null)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string targetUrl = (url == null) ? "http://localhost:58630/api/Calculators" : url;

                HttpResponseMessage response = client.GetAsync(targetUrl).Result;
                if (response.IsSuccessStatusCode)
                {
                    List<Calculator> calculators = await response.Content.ReadAsAsync<List<Calculator>>();
                    return calculators;
                }
                return null;
            }
        }

        public HttpResponseMessage CreateNewCalculator(Calculator calculator)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                return client.PostAsJsonAsync("http://localhost:58630/api/Calculators", calculator).Result;
            }
        }

        public async Task<Calculator> GetSingleCalculator(int calculatorId)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("http://localhost:58630/api/Calculators/" + calculatorId).Result;
                if (response.IsSuccessStatusCode)
                {
                    Calculator calculator = await response.Content.ReadAsAsync<Calculator>();
                    return calculator;
                }
                return null;
            }
        }

        public HttpResponseMessage UpdateCalculator(Calculator calculator)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                return client.PutAsJsonAsync("http://localhost:58630/api/Calculators/" + calculator.ID, calculator).Result;
            }
        }

        public HttpResponseMessage DeleteCalculator(Calculator calculator)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                return client.DeleteAsync("http://localhost:58630/api/Calculators/" + calculator.ID).Result;
            }
        }

        public bool UpdateCalculatorsDatabase()
        {
            List<Calculator> localCalculators = GetAllCalculators().Result;
            List<Calculator> targetCalculators = GetAllCalculators("target-url").Result;

            if (targetCalculators == null)
            {
                return false;
            }

            foreach (Calculator calculator in localCalculators)
            {
                DeleteCalculator(calculator);
            }

            foreach (Calculator calculator in targetCalculators)
            {
                CreateNewCalculator(calculator);
            }

            return true;
        }
    }
}