using Microsoft.AspNetCore.Mvc;
using OpenAI_API.Completions;
using OpenAI_API;

namespace BlazorAppWithChatGptIntegration.Services
{
    public class ReadChatGptApi
    {
        public string GetResult(string prompt)
        {
            //your OpenAI API key
            string apiKey = "";
            string answer = string.Empty;
            var openai = new OpenAIAPI(apiKey);
            CompletionRequest completion = new CompletionRequest();
            completion.Prompt = prompt;
            completion.Model = OpenAI_API.Models.Model.DavinciText;
            // OpenAI_API.Msodel.DavinciText
            completion.MaxTokens = 4000;
            var result = openai.Completions.CreateCompletionAsync(completion);
            try
            {
                if (result != null)
                {
                    foreach (var item in result.Result.Completions)
                    {
                        answer = item.Text;
                    }
                    return answer;
                }
                else
                {
                    return "sorry, try with more info";
                }
            }
            catch (Exception xe)
            {

                throw;
            }
           
        }
    }
}
