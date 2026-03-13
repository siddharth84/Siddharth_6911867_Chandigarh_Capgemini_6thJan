using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryMVC.Models;

public partial class Book
{
    [Key]
    public int BookId { get; set; }

    [StringLength(200)]
    public string? Title { get; set; }

    [Column("ISBN")]
    [StringLength(50)]
    public string? Isbn { get; set; }

    public int? AuthorId { get; set; }

    [ForeignKey("AuthorId")]
    public virtual Author? Author { get; set; }

    public virtual ICollection<Borrower> Borrowers { get; set; } = new List<Borrower>();
}