using System.ComponentModel.DataAnnotations;

namespace UtkiPhoto.Models;

public class Article
{
    public int Id { get; set; }
    public string? Title { get; set; }
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }
}