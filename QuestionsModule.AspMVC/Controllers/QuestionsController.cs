using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using QuestionsModule.AspMVC.Models;

namespace QuestionsModule.AspMVC.Controllers
{
    public class QuestionsController : Controller
    {
        // GET: Questions
        public ActionResult Index()
        {

            List<Questions> questions = LoadQuestions().Result;

            return View(questions);
        }

        public ActionResult SubmitAnswers(List<SubmittedAnswer> submittedAnswers)
        {
            bool result = SubmitAns(submittedAnswers).Result;

            return new JsonResult() { Data = result };
        }

        private async Task<bool> SubmitAns(List<SubmittedAnswer> submittedAnswers)
        {
            HttpClient client = Client.Get();
            URLS urls = new URLS();

            var res = await client.PostAsJsonAsync<List<SubmittedAnswer>>(urls.SubmitURL, submittedAnswers).ConfigureAwait(false);
            bool a = JsonConvert.DeserializeObject<bool>(res.Content.ReadAsStringAsync().Result);
            return a;
        }
        #region  - Helper Methods -

        private async Task<List<Questions>> LoadQuestions()
        {
            try
            {
                HttpClient client = Client.Get();
                URLS urls = new URLS();
                var questions = await client.GetAsync(urls.QuestionsURL).ConfigureAwait(false);
                List<Questions> questionsRes = null;
                if (questions.IsSuccessStatusCode)
                {
                    questionsRes = JsonConvert.DeserializeObject<List<Questions>>(questions.Content.ReadAsStringAsync().Result);
                }

                //if (questionsRes != null)
                //{
                //    foreach (var item in questionsRes)
                //    {
                //        var options = await client.GetAsync(string.Format(urls.OptionsURL, item.Id));
                //        item.Options = new List<Options>();
                //        List<Options> optionsRes = null;
                //        if (options.IsSuccessStatusCode)
                //        {
                //            optionsRes = JsonConvert.DeserializeObject<List<Options>>(options.Content.ReadAsStringAsync().Result);
                //        }
                //    }
                //}

                return questionsRes;
            }
            catch (Exception)
            {
                return null;
            }

        }

        #endregion
    }

    public static class Client
    {
        public static HttpClient Get()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:57201/api/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            return httpClient;
        }


    }

    public class URLS
    {
        public readonly string QuestionsURL;
        public readonly string OptionsURL;
        public readonly string SubmitURL;
        public URLS()
        {
            QuestionsURL = "questions";
            OptionsURL = "questions/{0}/options";
            SubmitURL = "submit";
        }
    }
}