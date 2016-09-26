using System;
using System.Collections.Generic;

namespace orez.oattrib.data {
	class oVal {

		// static method
		/// <summary>
		/// Get long from string list.
		/// </summary>
		/// <param name="a">String list.</param>
		/// <param name="i">Index.</param>
		/// <returns></returns>
		public static long Long(IList<string> a, int i) {
			long v = 0;
			if (i < a.Count) long.TryParse(a[i], out v);
			return v;
		}
		
		/// <summary>
		/// Get date-time from string list.
		/// </summary>
		/// <param name="a">String list.</param>
		/// <param name="i">Index.</param>
		/// <returns>Datetime value.</returns>
		public static DateTime Datetime(IList<string> a, int i) {
			var v = DateTime.MinValue;
			if (i < a.Count) DateTime.TryParse(a[i], out v);
			return v;
		}
	}
}
