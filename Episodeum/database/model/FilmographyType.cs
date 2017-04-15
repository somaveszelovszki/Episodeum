using SQLite;

namespace Episodeum.database.model {
    [Table("Filmography_type")]
    public class FilmographyType : Model {
        [Column("name")]
        public string Name { get; set; }
    }
}
