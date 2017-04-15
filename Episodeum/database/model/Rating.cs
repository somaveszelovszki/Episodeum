using SQLite;

namespace Episodeum.database.model {
    [Table("rating")]
    public class Rating : Model {
        [Column("name")]
        public string Name { get; set; }
    }
}
