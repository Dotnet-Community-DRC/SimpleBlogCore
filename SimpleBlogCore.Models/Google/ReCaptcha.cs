using System;
using Newtonsoft.Json;

namespace SimpleBlogCore.Service.Google
{
    public class ReCaptcha
    {
        public string Success { get; set; }
        public string Score { get; set; }
        public string ChallengeTs { get; set; } //challenge_ts
        public string HostName { get; set; }

        public bool Validate(string gResponse, string privateKey)
        {
            //var gResponse = Request.Form["g-recaptcha-response"];
            using (var client = new System.Net.WebClient())
            {
                try
                {
                    var gReply = client.DownloadString(
                        $"https://www.google.com/recaptcha/api/siteverify?secret={privateKey}&response={gResponse}");

                    var jsonReturned = JsonConvert.DeserializeObject<ReCaptcha>(gReply);
                    return (jsonReturned.Success.ToLower() == "true");
                }
                catch (Exception exc)
                {
                    throw new Exception(exc.Message);
                }
            }
        }
    }
}