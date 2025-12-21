using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BitirmeProjesi.Infrastructure.Persistence.Models;

[Table("Exam")]
public partial class Exam
{
    [Key]
    [Column("exam_id")]
    public int ExamId { get; set; }

    [Column("subject_id")]
    [StringLength(10)]
    [Unicode(false)]
    public string SubjectId { get; set; } = null!;

    [Column("exam_type")]
    [StringLength(6)]
    [Unicode(false)]
    public string ExamType { get; set; } = null!;

    [Column("exam_date", TypeName = "datetime")]
    public DateTime ExamDate { get; set; }

    [Column("exam_description")]
    public string ExamDescription { get; set; } = null!;

    [InverseProperty("Exam")]
    public virtual ICollection<Excuse> Excuses { get; set; } = new List<Excuse>();

    [InverseProperty("Exam")]
    public virtual ICollection<StudentExam> StudentExams { get; set; } = new List<StudentExam>();

    [ForeignKey("SubjectId")]
    [InverseProperty("Exams")]
    public virtual Subject Subject { get; set; } = null!;
}
