using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Episodeum.Properties;

namespace Episodeum.util {
	public class Preference<T> {
		public string Key { get; }
		public string Name { get; }
		public T Value {
			get {
				return (T) Settings.Default[Key];
			}
			set {
				Settings.Default[Key] = value;
			}
		}

		public Preference(string key, string name) {
			Key = key;
			Name = name;
		}

		public override string ToString() {
			return Name;
		}
	}
}
