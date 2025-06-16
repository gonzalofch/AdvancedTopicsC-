using System.ComponentModel.DataAnnotations.Schema;

namespace DemoLibrary.Model;

public class PersonModel
{
    public int Id { get; set; }

    [Column("Nombre")]
    public string FirstName { get; set; }

    [Column("Apellido")]
    public string LastName { get; set; }
}