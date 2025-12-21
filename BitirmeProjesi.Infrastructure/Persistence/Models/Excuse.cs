using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BitirmeProjesi.Infrastructure.Persistence.Models;

[Table("Excuse")]
public partial class Excuse
{
    [Key]
    [Column("excuse_id")]
    public int ExcuseId { get; set; }

    [Column("student_no")]
    [StringLength(50)]
    [Unicode(false)]
    public string StudentNo { get; set; } = null!;

    [Column("advisor_id")]
    public int AdvisorId { get; set; }

    [Column("exam_id")]
    public int ExamId { get; set; }

    [Column("excuse_description")]
    public string ExcuseDescription { get; set; } = null!;

    [Column("request_date", TypeName = "datetime")]
    public DateTime RequestDate { get; set; }

    [Column("response_date", TypeName = "datetime")]
    public DateTime ResponseDate { get; set; }

    [Column("document_path")]
    public string DocumentPath { get; set; } = null!;

    [ForeignKey("AdvisorId")]
    [InverseProperty("Excuses")]
    public virtual Advisor Advisor { get; set; } = null!;

    [ForeignKey("ExamId")]
    [InverseProperty("Excuses")]
    public virtual Exam Exam { get; set; } = null!;

    [ForeignKey("StudentNo")]
    [InverseProperty("Excuses")]
    public virtual Student StudentNoNavigation { get; set; } = null!;
}
