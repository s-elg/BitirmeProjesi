using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BitirmeProjesi.Infrastructure.Persistence.Models;

[Table("Advisor")]
public partial class Advisor
{
    [Key]
    [Column("advisor_id")]
    public int AdvisorId { get; set; }

    [Column("name_surname")]
    public string NameSurname { get; set; } = null!;

    [Column("advisor_mail")]
    [Unicode(false)]
    public string AdvisorMail { get; set; } = null!;

    [InverseProperty("Advisor")]
    public virtual ICollection<Excuse> Excuses { get; set; } = new List<Excuse>();

    [InverseProperty("Advisor")]
    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
