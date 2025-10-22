// Models/SupportMessage.cs
using System;
using System.Text.Json.Serialization;

namespace Model
{
    public class SupportMessage
    {
        [JsonPropertyName("id")] public string Id { get; set; }
        [JsonPropertyName("navn")] public string Navn { get; set; }
        [JsonPropertyName("email")] public string Email { get; set; }
        [JsonPropertyName("telefon")] public string Telefon { get; set; }
        [JsonPropertyName("beskrivelse")] public string Beskrivelse { get; set; }
        [JsonPropertyName("kategori")] public string Kategori { get; set; }
        [JsonPropertyName("dato_tidspunkt")] public DateTime DatoTidspunkt { get; set; }
    }
}