using Newtonsoft.Json;

namespace FrontendUsers.Models
{
    public class User
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("login")]
        public string Login { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("cpf")]
        public string Cpf { get; set; }

        [JsonProperty("dateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        [JsonProperty("motherName")]
        public string MotherName { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("inclusionDate")]
        public DateTime InclusionDate { get; set; }

        [JsonProperty("changeDate")]
        public DateTime ChangeDate { get; set; }
    }
}
