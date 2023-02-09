using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
namespace ThesisDbApp;

public class Program
{
    public int ID { get; set; }
    public enum Name
    {
        BachelorWirtschaftsinformatik,
        BachelorWirtschaftswissenschaften,
        MasterBusinessManagement,
        MasterInformationSystems
    }
}
