using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BitirmeProjesi.Infrastructure.Persistence.Models;

[PrimaryKey("StudentNo", "ExamId")]
[Table("Student_Exam")]
public partial class StudentExam
{
    [Key]
    [Column("student_no")]
    [StringLength(50)]
    [Unicode(false)]
    public string StudentNo { get; set; } = null!;

    [Key]
    [Column("exam_id")]
    public int ExamId { get; set; }

    [Column("participation_status")]
    [StringLength(3)]
    [Unicode(false)]
    public string ParticipationStatus { get; set; } = null!;

    [Column("consistency_note")]
    public int? ConsistencyNote { get; set; }

    [ForeignKey("ExamId")]
    [InverseProperty("StudentExams")]
    public virtual Exam Exam { get; set; } = null!;

    [ForeignKey("StudentNo")]
    [InverseProperty("StudentExams")]
    public virtual Student StudentNoNavigation { get; set; } = null!;
}
