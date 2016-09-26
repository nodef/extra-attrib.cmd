using System.IO;
using System.Text;
using System.Collections.Generic;

namespace orez.oattrib.io {
	class oFileAttributes {

		// static data
		/// <summary>
		/// Maps string to attribute value.
		/// </summary>
		public static Dictionary<string, FileAttributes> StrValMap = new Dictionary<string, FileAttributes>() {
			["archive"] = FileAttributes.Archive, ["compressed"] = FileAttributes.Compressed, ["device"] = FileAttributes.Device,
			["directory"] = FileAttributes.Directory, ["encrypted"] = FileAttributes.Encrypted, ["hidden"] = FileAttributes.Hidden,
			["integrity-stream"] = FileAttributes.IntegrityStream, ["normal"] = FileAttributes.Normal,
			["no-scrub-data"] = FileAttributes.NoScrubData, ["not-content-indexed"] = FileAttributes.NotContentIndexed,
			["offline"] = FileAttributes.Offline, ["read-only"] = FileAttributes.ReadOnly, ["reparse-point"] = FileAttributes.ReparsePoint,
			["sparse-file"] = FileAttributes.SparseFile, ["system"] = FileAttributes.System, ["temporary"] = FileAttributes.Temporary
		};
		/// <summary>
		/// Maps character to attribute value.
		/// </summary>
		public static Dictionary<char, FileAttributes> CharValMap = new Dictionary<char, FileAttributes>() {
			['a'] = FileAttributes.Archive, ['z'] = FileAttributes.Compressed, ['m'] = FileAttributes.Device,
			['d'] = FileAttributes.Directory, ['e'] = FileAttributes.Encrypted, ['h'] = FileAttributes.Hidden,
			['v'] = FileAttributes.IntegrityStream, ['n'] = FileAttributes.Normal,
			['x'] = FileAttributes.NoScrubData, ['i'] = FileAttributes.NotContentIndexed,
			['o'] = FileAttributes.Offline, ['r'] = FileAttributes.ReadOnly, ['p'] = FileAttributes.ReparsePoint,
			['b'] = FileAttributes.SparseFile, ['s'] = FileAttributes.System, ['t'] = FileAttributes.Temporary
		};
		/// <summary>
		/// Maps attribute value to string.
		/// </summary>
		public static Dictionary<FileAttributes, string> ValStrMap = new Dictionary<FileAttributes, string>() {
			[FileAttributes.Archive] = "archive", [FileAttributes.Compressed] = "compressed", [FileAttributes.Device] = "device",
			[FileAttributes.Directory] = "directory", [FileAttributes.Encrypted] = "encrypted", [FileAttributes.Hidden] = "hidden",
			[FileAttributes.IntegrityStream] = "integrity-stream", [FileAttributes.Normal] = "normal",
			[FileAttributes.NoScrubData] = "no-scrub-data", [FileAttributes.NotContentIndexed] = "not-content-indexed",
			[FileAttributes.Offline] = "offline", [FileAttributes.ReadOnly] = "read-only", [FileAttributes.ReparsePoint] = "reparse-point",
			[FileAttributes.SparseFile] = "sparse-file", [FileAttributes.System] = "system", [FileAttributes.Temporary] = "temporary"
		};
		/// <summary>
		/// Maps attribute value to character.
		/// </summary>
		public static Dictionary<FileAttributes, char> ValCharMap = new Dictionary<FileAttributes, char>() {
			[FileAttributes.Archive] = 'a', [FileAttributes.Compressed] = 'z', [FileAttributes.Device] = 'm',
			[FileAttributes.Directory] = 'd', [FileAttributes.Encrypted] = 'e', [FileAttributes.Hidden] = 'h',
			[FileAttributes.IntegrityStream] = 'v', [FileAttributes.Normal] = 'n',
			[FileAttributes.NoScrubData] = 'x', [FileAttributes.NotContentIndexed] = 'i',
			[FileAttributes.Offline] = 'o', [FileAttributes.ReadOnly] = 'r', [FileAttributes.ReparsePoint] = 'p',
			[FileAttributes.SparseFile] = 'b', [FileAttributes.System] = 's', [FileAttributes.Temporary] = 't'
		};


		// static method
		/// <summary>
		/// Convert attributes to string.
		/// </summary>
		/// <param name="o">Attributes.</param>
		/// <param name="v">Verbose full string?</param>
		/// <returns>String representation.</returns>
		public static string ToString(FileAttributes o, bool v = false) {
			var s = new StringBuilder();
			foreach(var k in ValCharMap.Keys) {
				if ((o & k) == 0) continue;
				if (!v) s.Append(ValCharMap[k]);
				else s.Append(ValStrMap[k]).Append(',');
			}
			if (v && s.Length > 0) s.Remove(s.Length - 1, 1);
			return s.ToString();
		}
	}
}
