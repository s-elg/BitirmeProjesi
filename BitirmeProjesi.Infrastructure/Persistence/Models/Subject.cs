using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BitirmeProjesi.Infrastructure.Persistence.Models;

[Table("Subject")]
public partial class Subject
{
    [Key]
    [Column("subject_id")]
    [StringLength(10)]
    [Unicode(false)]
    public string SubjectId { get; set; } = null!;

    [Column("subject_name")]
    [StringLength(50)]
    public string SubjectName { get; set; } = null!;

    [Column("academician_id")]
    public int AcademicianId { get; set; }

    [ForeignKey("AcademicianId")]
    [InverseProperty("Subjects")]
    public virtual Academician Academician { get; set; } = null!;

    [InverseProperty("Subject")]
    public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();

    [ForeignKey("SubjectId")]
    [InverseProperty("Subjects")]
    public virtual ICollection<Student> StudentNos { get; set; } = new List<Student>();
}
