using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission.Entity.Entities
{
    [Table("ContactUs")] // Specify the table name
    public class ContactUs : BaseEntity // Assuming BaseEntity defines common properties
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("user_id")] // Adjust column names to lowercase
        public int UserId { get; set; }

        [Column("name")] // Adjust column names to lowercase
        public string Name { get; set; }

        [Column("email_address")] // Adjust column names to lowercase
        public string EmailAddress { get; set; }

        [Column("subject")] // Adjust column names to lowercase
        public string Subject { get; set; }

        [Column("message")] // Adjust column names to lowercase
        public string Message { get; set; }
    }
}
