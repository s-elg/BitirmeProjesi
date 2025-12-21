using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BitirmeProjesi.Infrastructure.Persistence.Models;

[Table("Academician")]
public partial class Academician
{
    [Key]
    [Column("academician_id")]
    public int AcademicianId { get; set; }

    [Column("name_surname")]
    public string NameSurname { get; set; } = null!;

    [Column("academician_mail")]
    [Unicode(false)]
    public string AcademicianMail { get; set; } = null!;

    [Column("academician_phone")]
    [StringLength(20)]
    [Unicode(false)]
    public string AcademicianPhone { get; set; } = null!;

    [InverseProperty("Academician")]
    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}
