using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RacerConfigurator.VisitorPassGenerator.Models;

public class VisitorData
{
    [JsonPropertyName("name")]
    [Required(ErrorMessage = "Name is required")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("email")]
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address")]
    public string Email { get; set; } = string.Empty;
}
