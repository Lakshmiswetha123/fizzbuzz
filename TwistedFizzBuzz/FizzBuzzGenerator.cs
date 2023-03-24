using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TwistedFizzBuzz
{
    public class FizzBuzzToken
    {
        public int Multiple { get; set; }
        public string Word { get; set; }
    }

    public class TwistedFizzBuzz
    {
        private readonly List<FizzBuzzToken> _tokens;

        public TwistedFizzBuzz()
        {
            _tokens = new List<FizzBuzzToken> { new FizzBuzzToken { Multiple = 3, Word = "Fizz" }, new FizzBuzzToken { Multiple = 5, Word = "Buzz" } };
        }

        public TwistedFizzBuzz(List<FizzBuzzToken> tokens)
        {
            _tokens = tokens;
        }

        public string GetFizzBuzz(int num)
        {
            var result = "";
            foreach (var token in _tokens)
            {
                if (num % token.Multiple == 0)
                {
                    result += token.Word;
                }
            }
            if (result == "")
            {
                return num.ToString();
            }
            return result;
        }

        public string GetFizzBuzz(int start, int end)
        {
            var results = new List<string>();
            for (int i = start; i <= end; i++)
            {
                results.Add(GetFizzBuzz(i));
            }
            return string.Join(", ", results);
        }

        public string GetFizzBuzz(int[] nums)
        {
            var results = new List<string>();
            foreach (var num in nums)
            {
                results.Add(GetFizzBuzz(num));
            }
            return string.Join(", ", results);
        }

        public async Task<string> GetFizzBuzzFromAPI()
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    var response = await httpClient.GetAsync("https://rich-red-cocoon-veil.cyclic.app/random");
                    response.EnsureSuccessStatusCode();
                    var content = await response.Content.ReadAsStringAsync();
                    var token = JsonConvert.DeserializeObject<FizzBuzzToken>(content);
                    var tokens = new List<FizzBuzzToken> { token };
                    return GetFizzBuzz(-100, 100, tokens);
                }
                catch (HttpRequestException)
                {
                    return "";
                }
            }
        }

        public string GetFizzBuzz(int start, int end, List<FizzBuzzToken> tokens)
        {
            var twistedFizzBuzz = new TwistedFizzBuzz(tokens);
            return twistedFizzBuzz.GetFizzBuzz(start, end);
        }
    }
}
