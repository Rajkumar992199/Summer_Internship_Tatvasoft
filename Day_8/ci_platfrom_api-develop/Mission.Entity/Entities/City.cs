using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission.Entity.Entities
{
    [Table("City")] // Explicitly specify the table name
    public class City
    {
        [Key]
        [Column("id")] // Define the column name and make it lowercase
        public int Id { get; set; }

        [Column("country_id")] // Define the column name and make it lowercase
        public int CountryId { get; set; }

        [Column("city_name")] // Define the column name and make it lowercase
        public string CityName { get; set; }

        public virtual ICollection<Missions> Missions { get; set; } = [];
    }
}
