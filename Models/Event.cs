namespace EventEase.Models;

using System.ComponentModel.DataAnnotations;

public class Event
{
    public Guid Id { get; set; }
    
    [Required(ErrorMessage = "The name field is required")]
    [StringLength(50, ErrorMessage = "The name field must be between {2} and {1} characters", MinimumLength = 3)]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "The description field is required")]
    public string Description { get; set; }
    
    [Required(ErrorMessage = "The date field is required")]
    public DateTime Date { get; set; }
    
    [Required(ErrorMessage = "The location field is required")]
    public string Location { get; set; }
}