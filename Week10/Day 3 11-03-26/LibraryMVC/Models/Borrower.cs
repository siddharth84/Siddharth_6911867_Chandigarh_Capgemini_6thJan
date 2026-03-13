using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LibraryMVC.Models;

public partial class Borrower
{
    [Key]
    public int BorrowerId { get; set; }

    [StringLength(100)]
    public string? FullName { get; set; }

    [StringLength(100)]
    public string? Email { get; set; }

    [ForeignKey("BorrowerId")]
    [InverseProperty("Borrowers")]
    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
