using System;
using System.Collections.Generic;
using BitirmeProjesi.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace BitirmeProjesi.Infrastructure.Persistence.DbContext;

public partial class BitirmeProjesiDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public BitirmeProjesiDbContext()
    {
    }

    public BitirmeProjesiDbContext(DbContextOptions<BitirmeProjesiDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Academician> Academicians { get; set; }

    public virtual DbSet<Advisor> Advisors { get; set; }

    public virtual DbSet<Exam> Exams { get; set; }

    public virtual DbSet<Excuse> Excuses { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentExam> StudentExams { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=SUMEYYE\\SQLEXPRESS;Database=BitirmeProjesi;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Academician>(entity =>
        {
            entity.Property(e => e.AcademicianId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Advisor>(entity =>
        {
            entity.Property(e => e.AdvisorId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Exam>(entity =>
        {
            entity.Property(e => e.ExamId).ValueGeneratedNever();

            entity.HasOne(d => d.Subject).WithMany(p => p.Exams)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Exam_Subject");
        });

        modelBuilder.Entity<Excuse>(entity =>
        {
            entity.HasKey(e => e.ExcuseId).HasName("PK_Excuse_1");

            entity.Property(e => e.ExcuseId).ValueGeneratedNever();

            entity.HasOne(d => d.Advisor).WithMany(p => p.Excuses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Excuse_Advisor1");

            entity.HasOne(d => d.Exam).WithMany(p => p.Excuses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Excuse_Exam");

            entity.HasOne(d => d.StudentNoNavigation).WithMany(p => p.Excuses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Excuse_Student1");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasOne(d => d.Advisor).WithMany(p => p.Students)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Student_Advisor");
        });

        modelBuilder.Entity<StudentExam>(entity =>
        {
            entity.Property(e => e.ParticipationStatus).IsFixedLength();

            entity.HasOne(d => d.Exam).WithMany(p => p.StudentExams)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Student_Exam_Exam");

            entity.HasOne(d => d.StudentNoNavigation).WithMany(p => p.StudentExams)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Student_Exam_Student");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasOne(d => d.Academician).WithMany(p => p.Subjects)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Subject_Academician");

            entity.HasMany(d => d.StudentNos).WithMany(p => p.Subjects)
                .UsingEntity<Dictionary<string, object>>(
                    "StudentSubject",
                    r => r.HasOne<Student>().WithMany()
                        .HasForeignKey("StudentNo")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Student_Subject_Student"),
                    l => l.HasOne<Subject>().WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Student_Subject_Subject"),
                    j =>
                    {
                        j.HasKey("SubjectId", "StudentNo");
                        j.ToTable("Student_Subject");
                        j.IndexerProperty<string>("SubjectId")
                            .HasMaxLength(10)
                            .IsUnicode(false)
                            .HasColumnName("subject_id");
                        j.IndexerProperty<string>("StudentNo")
                            .HasMaxLength(50)
                            .IsUnicode(false)
                            .HasColumnName("student_no");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
