using System;

namespace orez.oattrib.data {
	class oDateTime {

		// static method
		/// <summary>
		/// Get date-time from file-time.
		/// </summary>
		/// <param name="v">File-time.</param>
		/// <param name="utc">UTC file-time?</param>
		/// <returns>Date-time.</returns>
		public static DateTime FromFileTime(long v, bool utc = false) {
			return utc ? DateTime.FromFileTimeUtc(v) : DateTime.FromFileTime(v);
		}

		/// <summary>
		/// Get file-time from date-time.
		/// </summary>
		/// <param name="v">Date-time.</param>
		/// <param name="utc">UTC file-time?</param>
		/// <returns>File-time.</returns>
		public static long ToFileTime(DateTime v, bool utc = false) {
			return utc ? v.ToFileTimeUtc() : v.ToFileTime();
		}

		/// <summary>
		/// Get local/UTC time from date-time.
		/// </summary>
		/// <param name="v">Date-time.</param>
		/// <param name="utc">To UTC time?</param>
		/// <returns>Local/UTC time.</returns>
		public static DateTime ToTime(DateTime v, bool utc = false) {
			return utc ? v.ToUniversalTime() : v.ToLocalTime();
		}
	}
}
