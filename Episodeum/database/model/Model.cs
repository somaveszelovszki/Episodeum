﻿using System;
using SQLite;

namespace Episodeum.database.model {
    public abstract class Model {

        [Column("_id"), PrimaryKey, AutoIncrement]
		public int? Id { get; set; }

		public virtual void PrintValues() {
			Console.WriteLine("Id:\t\t" + Id);
		}

		public int getId() {
			return Id != null ? (int) Id : 0;
		}
	}
}