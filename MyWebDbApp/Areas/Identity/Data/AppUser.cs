using Microsoft.AspNetCore.Identity;
namespace ThesisDbApp.Areas.Identity.Data;
public class AppUser : IdentityUser
{
    public int ChairId { get; set; }
    public string? Chair { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public bool Active { get; set; }
}