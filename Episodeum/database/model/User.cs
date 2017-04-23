using SQLite;

namespace Episodeum.database.model {
    [Table("user")]
    public class User : Model {
        [Column("username"), NotNull, Unique]
        public string Username { get; set; }
    };
}
