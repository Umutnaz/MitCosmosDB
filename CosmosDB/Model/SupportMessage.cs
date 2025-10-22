
using System;
using Newtonsoft.Json; 

namespace Model
{
    public class SupportMessage
    {
        [JsonProperty("id")] public string Id { get; set; }
        [JsonProperty("navn")] public string Navn { get; set; }
        [JsonProperty("email")] public string Email { get; set; }
        [JsonProperty("telefon")] public string Telefon { get; set; }
        [JsonProperty("beskrivelse")] public string Beskrivelse { get; set; }

        // VIGTIGT: Containerens PK er /category
        [JsonProperty("category")] public string Kategori { get; set; }

        [JsonProperty("dato_tidspunkt")] public DateTime DatoTidspunkt { get; set; }
    }
}