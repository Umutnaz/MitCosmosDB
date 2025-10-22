namespace Model;
using Newtonsoft.Json;
using System;

public class SupportMessage
{
    [JsonProperty("id")]
    public string Id { get; set; }
    public string Navn { get; set; }
    public string Email { get; set; }
    public string Telefon { get; set; }
    public string Beskrivelse { get; set; }
    public string Kategori { get; set; }
    public DateTime DatoTidspunkt { get; set; }
}