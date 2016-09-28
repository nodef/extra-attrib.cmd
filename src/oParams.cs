using System;
using System.IO;
using orez.oattrib.io;
using orez.oattrib.data;

namespace orez.oattrib {
	class oParams {

		// data
		/// <summary>
		/// Indicates that time is in filetime (long).
		/// </summary>
		public bool Filetime;
		/// <summary>
		/// Indicates that time is in UTC.
		/// </summary>
		public bool Utc;
		/// <summary>
		/// Include directories too.
		/// </summary>
		public bool Directories;
		/// <summary>
		/// Recurses through subdirectories.
		/// </summary>
		public bool Recursize;
		/// <summary>
		/// Apply to symlink instead of target.
		/// </summary>
		public bool Link;
		/// <summary>
		/// Verbose attributes in detail.
		/// </summary>
		public bool Verbose;
		/// <summary>
		/// Attributes to clear.
		/// </summary>
		public FileAttributes AttribClear = 0;
		/// <summary>
		/// Attributes to set.
		/// </summary>
		public FileAttributes AttribSet = 0;
		/// <summary>
		/// File creation time.
		/// </summary>
		public DateTime Create = DateTime.MinValue;
		/// <summary>
		/// File access time.
		/// </summary>
		public DateTime Access = DateTime.MinValue;
		/// <summary>
		/// File write time.
		/// </summary>
		public DateTime Write = DateTime.MinValue;
		/// <summary>
		/// Attributes get order.
		/// </summary>
		public string Get = "";
		/// <summary>
		/// Path of which attributes to get.
		/// </summary>
		public string Path = "*";


		// constructor
		/// <summary>
		/// Get parameters from input arguments.
		/// </summary>
		/// <param name="args">Input arguments.</param>
		public oParams(string[] args) {
			for (int i = 0; i < args.Length; i++) {
				string a = args[i];
				string b = a.ToLower();
				if (a.StartsWith("++")) SetStringAttrib(b.Substring(2), true);
				else if (a.StartsWith("--")) SetLongParam(args, ref i);
				else if (a.StartsWith("+") || a.StartsWith("-")) SetShortParam(args, ref i);
				else Path = a;
			}
		}

		/// <summary>
		/// Set short parameters from input arguments.
		/// </summary>
		/// <param name="a">Input arguments.</param>
		/// <param name="i">Index.</param>
		private void SetShortParam(string[] a, ref int i) {
			bool on = false;
			foreach(char b in a[i]) {
				char c = char.ToLower(b);
				if (c == '-') on = false;
				else if (c == '+') on = true;
				else if (c == 'f') Filetime = true;
				else if (c == 'u') Utc = true;
				else if (c == 'j') Directories = true;
				else if (c == 'k') Recursize = true;
				else if (c == 'l') Link = true;
				else if (c == 'y') Verbose = true;
				else if (b == 'c') Get += 'c';
				else if (b == 'g') Get += 'g';
				else if (b == 'w') Get += 'w';
				else if (b == 'C') Create = Datetime(a, ++i, Filetime, Utc);
				else if (b == 'G') Access = Datetime(a, ++i, Filetime, Utc);
				else if (b == 'w') Write = Datetime(a, ++i, Filetime, Utc);
				else SetCharAttrib(c, on);
			}
		}

		/// <summary>
		/// Set long parameter from input arguments.
		/// </summary>
		/// <param name="a">Input arguments.</param>
		/// <param name="i">Index.</param>
		private void SetLongParam(string[] a, ref int i) {
			string b = a[i].Substring(2);
			string c = b.ToLower();
			if (c == "filetime") Filetime = true;
			else if (c == "utc") Utc = true;
			else if (c == "directories") Directories = true;
			else if (c == "recursive") Recursize = true;
			else if (c == "link") Link = true;
			else if (c == "verbose") Verbose = true;
			else if (b == "create") Get += 'c';
			else if (b == "access") Get += 'g';
			else if (b == "write") Get += 'w';
			else if (b == "Create") Create = Datetime(a, ++i, Filetime, Utc);
			else if (b == "Access") Access = Datetime(a, ++i, Filetime, Utc);
			else if (b == "Write") Write = Datetime(a, ++i, Filetime, Utc);
			else SetStringAttrib(c, false);
		}

		/// <summary>
		/// Set attribute from string.
		/// </summary>
		/// <param name="a">Attribute.</param>
		/// <param name="on">Whether to enable.</param>
		private void SetStringAttrib(string a, bool on) {
			var m = oFileAttributes.StrValMap;
			FileAttributes v = m.ContainsKey(a) ? m[a] : 0;
			if (on) AttribSet |= v;
			else AttribClear |= v;
		}

		/// <summary>
		/// Set attribute from character.
		/// </summary>
		/// <param name="a">Attribute.</param>
		/// <param name="on">Whether to enable.</param>
		private void SetCharAttrib(char a, bool on) {
			var m = oFileAttributes.CharValMap;
			FileAttributes v = m.ContainsKey(a) ? m[a] : 0;
			if (on) AttribSet |= v;
			else AttribClear |= v;
		}


		// static method
		/// <summary>
		/// Get date-time from string list.
		/// </summary>
		/// <param name="a">String list.</param>
		/// <param name="i">Index.</param>
		/// <param name="file">Filetime?</param>
		/// <param name="utc">UTC?</param>
		/// <returns>DateTime value.</returns>
		private static DateTime Datetime(string[] a, int i, bool file, bool utc) {
			var v = file ? oDateTime.FromFileTime(oVal.Long(a, i), utc) : oVal.Datetime(a, i);
			return oDateTime.ToTime(v, utc);
		}
	}
}
