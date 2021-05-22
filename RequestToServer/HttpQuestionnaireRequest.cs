using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using Сonstruction_сompany.View;

namespace Сonstruction_сompany.RequestToServer
{
    class HttpQuestionnaireRequest
    {
        #region GET
        public static List<Questionnaire> GetQuestionnaireByUserID(int ID)
        {
            try
            {
                var webRequest = (HttpWebRequest)WebRequest.Create("https://localhost:44394/Questionnaire/" + ID);
                var webResponse = (HttpWebResponse)webRequest.GetResponse();
                var reader = new StreamReader(webResponse.GetResponseStream());
                string temp = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<List<Questionnaire>>(temp);
            }
            catch
            {
                return null;
            }
        }
        #endregion
        #region PUT
        public static async System.Threading.Tasks.Task CreateQuestionnaire(Questionnaire questionnaire)
        {
            try
            {
                using (var client = new HttpClient())
                using (var request = new HttpRequestMessage(HttpMethod.Put, String.Format("https://localhost:44394/Questionnaire/{0}", questionnaire.user.id)))
                {
                    var json = JsonConvert.SerializeObject(questionnaire);
                    using (var stringContent = new StringContent(json, Encoding.UTF8, "application/json"))
                    {
                        request.Content = stringContent;

                        using (var response = await client
                            .SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
                            .ConfigureAwait(false))
                        {
                            response.EnsureSuccessStatusCode();
                        }
                    }
                }
            }
            catch
            {
                //!!!!!!
            }
        }
        #endregion
    }
}
