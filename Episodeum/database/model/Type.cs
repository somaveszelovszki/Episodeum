using SQLite;

namespace Episodeum.database.model {
	public class Type : Model {
		[Column("name"), NotNull, Unique]
		public string Name { get; set; }
	}
}
