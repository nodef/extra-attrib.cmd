using System;
using System.IO;

namespace orez.oattrib.io {
	class oFileSystemInfo {

		// static method
		/// <summary>
		/// Get attributes.
		/// </summary>
		/// <param name="o">File system info.</param>
		/// <returns>Attributes.</returns>
		public static FileAttributes GetAttributes(FileSystemInfo o) {
			return o.Attributes;
		}

		/// <summary>
		/// Set attributes (if non-zero).
		/// </summary>
		/// <param name="o">File system info.</param>
		/// <param name="v">Attributes.</param>
		public static void SetAttributes(FileSystemInfo o, FileAttributes v) {
			if (v != 0) o.Attributes = v;
		}

		/// <summary>
		/// Get creation time.
		/// </summary>
		/// <param name="o">File system info.</param>
		/// <param name="utc">UTC time?</param>
		/// <returns>Creation time.</returns>
		public static DateTime GetCreationTime(FileSystemInfo o, bool utc = false) {
			return utc ? o.CreationTimeUtc : o.CreationTime;
		}

		/// <summary>
		/// Set creation time (if non-min).
		/// </summary>
		/// <param name="o">File system info.</param>
		/// <param name="v">Creation time.</param>
		/// <param name="utc">UTC time?</param>
		public static void SetCreationTime(FileSystemInfo o, DateTime v, bool utc = false) {
			if (v == DateTime.MinValue) return;
			if (!utc) o.CreationTime = v;
			else o.CreationTimeUtc = v;
		}

		/// <summary>
		/// Get last access time.
		/// </summary>
		/// <param name="o">File system info.</param>
		/// <param name="utc">UTC time?</param>
		/// <returns>Last access time.</returns>
		public static DateTime GetLastAccessTime(FileSystemInfo o, bool utc = false) {
			return utc ? o.LastAccessTimeUtc : o.LastAccessTime;
		}

		/// <summary>
		/// Set last access time (if non-min).
		/// </summary>
		/// <param name="o">File system info.</param>
		/// <param name="v">Last access time.</param>
		/// <param name="utc">UTC time?</param>
		public static void SetLastAccessTime(FileSystemInfo o, DateTime v, bool utc = false) {
			if (v == DateTime.MinValue) return;
			if (!utc) o.LastAccessTime = v;
			else o.LastAccessTimeUtc = v;
		}

		/// <summary>
		/// Get last write time.
		/// </summary>
		/// <param name="o">File system info.</param>
		/// <param name="utc">UTC time?</param>
		/// <returns>Last write time.</returns>
		public static DateTime GetLastWriteTime(FileSystemInfo o, bool utc = false) {
			return utc ? o.LastWriteTimeUtc : o.LastWriteTime;
		}

		/// <summary>
		/// Set last write time (if non-min).
		/// </summary>
		/// <param name="o">File system info.</param>
		/// <param name="v">Last write time.</param>
		/// <param name="utc">UTC time?</param>
		public static void SetLastWriteTime(FileSystemInfo o, DateTime v, bool utc = false) {
			if (v == DateTime.MinValue) return;
			if (!utc) o.LastWriteTime = v;
			else o.LastWriteTimeUtc = v;
		}
	}
}
