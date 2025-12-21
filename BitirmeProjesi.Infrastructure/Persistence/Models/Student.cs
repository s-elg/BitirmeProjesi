using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BitirmeProjesi.Infrastructure.Persistence.Models;

[Table("Student")]
public partial class Student
{
    [Key]
    [Column("student_no")]
    [StringLength(50)]
    [Unicode(false)]
    public string StudentNo { get; set; } = null!;

    [Column("name_surname")]
    public string NameSurname { get; set; } = null!;

    [Column("grade")]
    public int Grade { get; set; }

    [Column("gpa", TypeName = "decimal(3, 2)")]
    public decimal Gpa { get; set; }

    [Column("student_mail")]
    [Unicode(false)]
    public string StudentMail { get; set; } = null!;

    [Column("advisor_id")]
    public int AdvisorId { get; set; }

    [ForeignKey("AdvisorId")]
    [InverseProperty("Students")]
    public virtual Advisor Advisor { get; set; } = null!;

    [InverseProperty("StudentNoNavigation")]
    public virtual ICollection<Excuse> Excuses { get; set; } = new List<Excuse>();

    [InverseProperty("StudentNoNavigation")]
    public virtual ICollection<StudentExam> StudentExams { get; set; } = new List<StudentExam>();

    [ForeignKey("StudentNo")]
    [InverseProperty("StudentNos")]
    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}
