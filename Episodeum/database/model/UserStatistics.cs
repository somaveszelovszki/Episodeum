using System;
using Episodeum.util;
using SQLite;

namespace Episodeum.database.model {
    [Table("user_statistics")]
    public class UserStatistics : Model, IGraphable {

        [Column("user_id"), NotNull]
        public int UserId { get; set; }

		[Column("date"), NotNull]
		public string Date { get; set; }

		[Column("time_watching"), NotNull]
		public int TimeWatching { get; set; }

		public void SetDate(DateTime? date) {
			Date = date != null ? ((DateTime) date).ToShortDateString() : null;
		}

		public DateTime? GetDate() {
			return Date != null ? (DateTime?) DateTime.Parse(Date) : null;
		}
		public string GetDateAsShortString() {
			return Date != null ? SystemUtils.DateToShortString(DateTime.Parse(Date)) : null;
		}

		public override void PrintValues() {
			base.PrintValues();
			Console.WriteLine("UserId:\t\t" + UserId);
			Console.WriteLine("Date:\t" + Date);
		}

		public double GetValue() {
			return TimeWatching / 60;		// in minutes
		}

		public object GetKey() {
			return GetDateAsShortString();
		}

		[Ignore]
		public User User {
			get {
				return App.Instance.DbManager.Connection.Get<User>(UserId);
			}
			set {
				UserId = value.GetId();
			}
		}
	}
}