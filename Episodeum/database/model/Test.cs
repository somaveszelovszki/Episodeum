using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Episodeum.database.model {
    [Table("test")]
    public class Test {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }
    }
}
