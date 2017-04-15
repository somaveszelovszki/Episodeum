using SQLite;

namespace Episodeum.database.model {
    [Table("series_status")]
    public class SeriesStatus : Model {
        [Column("name")]
        public string Name { get; set; }
    }
}
