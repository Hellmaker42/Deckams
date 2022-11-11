namespace Deckams_Api.Models.Misc
{
  public class ContactInfo
  {
    public int Id { get; set; }
    public string? CompanyName { get; set; }
    public string? Street { get; set; }
    public string? ZipCode { get; set; }
    public string? City { get; set; }
    public string? PhoneNr { get; set; }
    public string? Email { get; set; }
    public string? OrgNr { get; set; }
  }
}