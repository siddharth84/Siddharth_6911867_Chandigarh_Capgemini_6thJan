using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HospitalMVC.Models;

public partial class Patient
{
    [Key]
    public int PatientId { get; set; }

    [Required]
    [StringLength(100)]
    public string FullName { get; set; } = null!;

    public DateOnly? DateOfBirth { get; set; }

    [StringLength(20)]
    public string? ContactNumber { get; set; }

    [InverseProperty("Patient")]
    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
