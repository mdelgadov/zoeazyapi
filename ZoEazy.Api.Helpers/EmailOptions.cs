namespace ZoEazy.Api.Helpers
{
    public class EmailOptions : IEmailOptions 
    {
        public string email { get; set; }
        public string apiKey { get; set; }
        public string name { get; set; }

        public EmailOptions(string apiKey, string email, string name) {
            this.email = email;
            this.apiKey = apiKey;
            this.name = name;
        }
   }
}