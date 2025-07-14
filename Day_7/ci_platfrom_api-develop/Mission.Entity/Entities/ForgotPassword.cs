using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission.Entity.Entities
{
    [Table("ForgotPassword")] // Specify the table name
    public class ForgotPassword
    {
        [Key]
        [Column("temp_id")]
        public int TempId { get; set; }

        [Column("id")]
        public string Id { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        [Column("request_date_time")]
        public DateTime RequestDateTime { get; set; }
    }
}
