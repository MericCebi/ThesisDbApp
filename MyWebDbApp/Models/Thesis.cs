using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace ThesisDbApp.Models;

public class Thesis
{
    [Display(Name = "Lehrstuhl-ID")]
    public int ChairId { get; set; }
    [Display(Name = "Lehrstuhl")]
    public string? ChairName { get; set; }
    [Display(Name = "ID")]
    public int id { get; set; }
    [Required]
    [Display(Name = "Titel")]
    public string? Title { get; set; }
    [Required]
    [Display(Name = "Beschreibung")]
    public string? Description { get; set; }
    [Display(Name = "Bachelor")]
    public bool Bachelor { get; set; }
    [Display(Name = "Master")]
    public bool Master { get; set; }
    public enum Status
    {
        Available,
        Allocated,
        Filed,
        Submitted,
        Graded
    }
    [Required]
    [Display(Name = "Name des Studenten")]
    public string? StudentName { get; set; }
    [Required]
    [EmailAddress]
    [Display(Name = "E-mail Adresse des Studenten")]
    public string? StudentEmail { get; set; }
    [Required]
    [Display(Name = "Matrikelnummer")]
    public string? StudentID { get; set; }
    [DataType(DataType.Date)]
    [Display(Name = "Anmeldetag")]
    public DateTime Registration { get; set; }
    [DataType(DataType.Date)]
    [Display(Name = "Abgabetag")]
    public DateTime Filing { get; set; }
    [Display(Name = "Zusammenfassung")]
    public string? Summary { get; set; }
    [Display(Name = "Stärken")]
    public string? Strengths { get; set; }
    [Display(Name = "Schwächen")]
    public string? Weakness { get; set; }
    [Display(Name = "Auswertung")]
    public string? Evaluation { get; set; }
    [Display(Name = "Inhaltsbewertung")]
    [Range(1, 5)]
    public int ContentVal { get; set; }
    [Display(Name = "Layoutbewertung")]
    [Range(1, 5)]
    public int LayoutVal { get; set; }
    [Display(Name = "Strukturbewertung")]
    [Range(1, 5)]
    public int StructureVal { get; set; }
    [Display(Name = "Stilbewertung")]
    [Range(1, 5)]
    public int StyleVal { get; set; }
    [Display(Name = "Literaturbewertung")]
    [Range(1, 5)]
    public int LiteratureVal { get; set; }
    [Display(Name = "Schwierigkeitsbewertung")]
    [Range(1, 5)]
    public int DifficultyVal { get; set; }
    [Display(Name = "Neuheitsbewertng")]
    [Range(1, 5)]
    public int NoveltyVal { get; set; }
    [Display(Name = "Reichhaltigkeitsbewertung")]
    [Range(1, 5)]
    public int RichnessVal { get; set; }
    [Display(Name = "Inhaltsgewichtung")]
    [Range(0, 100)]
    [DefaultValue(30)]
    public int ContentWt { get; set; }
    [Display(Name = "Layoutsgewichtung")]
    [Range(0, 100)]
    [DefaultValue(15)]

    public int LayoutWt { get; set; }
    [Display(Name = "Strukturgewichtung")]
    [Range(0, 100)]
    [DefaultValue(10)]
    public int StructureWt { get; set; }
    [Display(Name = "Stilgewichtung")]
    [Range(0, 100)]
    [DefaultValue(10)]
    public int StyleWt { get; set; }
    [Display(Name = "Literaturgewichtung")]
    [Range(0, 100)]
    [DefaultValue(10)]
    public int LiteratureWt { get; set; }
    [Display(Name = "Schwierigkeitsgewichtung")]
    [Range(0, 100)]
    [DefaultValue(5)]
    public int DifficultyWt { get; set; }
    [Display(Name = "Neuheitsgewichtung")]
    [Range(0, 100)]
    [DefaultValue(10)]
    public int NoveltyWt { get; set; }
    [Display(Name = "Reichhaltigkeitsgewichtung")]
    [Range(0, 100)]
    [DefaultValue(10)]
    public int RichnessWt { get; set; }
    [Display(Name = "Note")]
    [Range(1.0, 5.0)]
    public double? Grade { get; set; }
    [Required]
    [DataType(DataType.Date)]
    [Display(Name = "Zuletzt geändert")]
    public DateTime LastModified { get; set; }
    public IEnumerable<ValidationResult> WeightValidate(ValidationContext validationContext)
    {
        var results = new List<ValidationResult>();

        if (ContentWt + RichnessWt + NoveltyWt + DifficultyWt + LiteratureWt + StyleWt + StructureWt + LayoutWt != 100)
            results.Add(new ValidationResult("Die Summe der Gewichte muss 100% ergeben!"));

        return results;
    }
    public IEnumerable<ValidationResult> BachelorValidate(ValidationContext validationContext)
    {
        var results = new List<ValidationResult>();

        if (Bachelor == false && Master == false)
            results.Add(new ValidationResult("Wählen Sie bitte Bachelor/Master aus!"));

        return results;
    }
    public IEnumerable<ValidationResult> GradedValidate(ValidationContext validationContext)
    {
        var results = new List<ValidationResult>();

        if (Grade == null)
            results.Add(new ValidationResult("Wählen Sie bitte Bachelor/Master aus!"));

        return results;
    }
}
