using SQLite;

namespace Episodeum.database.model {
    [Table("user")]
    public class User : Model {
        [Column("username")]
        public string Username { get; set; }
    };
}
