using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HospitalMVC.Models;

public partial class Doctor
{
    [Key]
    public int DoctorId { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    [Required]
    public string Specialization { get; set; } = null!;

    [InverseProperty("Doctor")]
    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
