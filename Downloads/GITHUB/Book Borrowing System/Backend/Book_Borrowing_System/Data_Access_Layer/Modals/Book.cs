using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data_Access_Layer.Modals
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Rating { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public bool IsBookAvailable { get; set; }
        public string Description { get; set; }

        // Nullable, as a book may not be lent or borrowed
        public string? LentByUserId { get; set; }
        public string? CurrentlyBorrowedById { get; set; }

        // Navigation properties

        [ForeignKey("LentByUserId")]
        public User LentByUser { get; set; }

        [ForeignKey("CurrentlyBorrowedById")]
        public User CurrentlyBorrowedByUser { get; set; }
    }
}
