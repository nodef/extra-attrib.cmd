using System;
using System.IO;
using orez.oattrib.io;
using orez.oattrib.data;

namespace orez.oattrib {
	class Program {

		// static method
		/// <summary>
		/// We don’t need our lovers to be perfect. We need them to warn
		/// us of their quirks in good time. We need them to give us an
		/// instruction manual to themselves.
		/// : The School of Life
		/// </summary>
		/// <param name="args">Input arguments.</param>
		static void Main(string[] args) {
			var p = new oParams(args);
			string cd, sp;
			SearchPattern(p.Path, out cd, out sp);
			var cdi = new DirectoryInfo(cd);
			var opt = p.Recursize ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
			var enm = p.Directories ? cdi.EnumerateFileSystemInfos(sp, opt) : cdi.EnumerateFiles(sp, opt);
			foreach(var o in enm) {
				try { SetAttribs(o, p); }
				catch (Exception) { }
				PrintAttribs(o, p);
			}
		}

		/// <summary>
		/// Get search pattern from full path.
		/// </summary>
		/// <param name="p">Full path.</param>
		/// <param name="cd">Path.</param>
		/// <param name="sp">Search pattern.</param>
		private static void SearchPattern(string p, out string cd, out string sp) {
			int wi = p.IndexOfAny(new char[] { '*', '?' });
			int si = wi < 0 ? p.Length : (wi == 0? -1 : p.LastIndexOf('\\', wi - 1, wi));
			cd = si <= 0 ? "." : p.Substring(0, si) + '\\';
			sp = si < p.Length? p.Substring(si + 1) : "*";
		}

		/// <summary>
		/// Set attributes.
		/// </summary>
		/// <param name="o">File system info.</param>
		/// <param name="p">Input parameters.</param>
		private static void SetAttribs(FileSystemInfo o, oParams p) {
			var attr = oFileSystemInfo.GetAttributes(o);
			oFileSystemInfo.SetAttributes(o, (p.AttribClear | p.AttribSet) == 0 ? 0 : (attr & ~p.AttribClear) | p.AttribSet);
			oFileSystemInfo.SetCreationTime(o, p.Create, p.Utc);
			oFileSystemInfo.SetLastAccessTime(o, p.Access, p.Utc);
			oFileSystemInfo.SetLastWriteTime(o, p.Write, p.Utc);
		}

		/// <summary>
		/// Print attributes.
		/// </summary>
		/// <param name="o">File system info.</param>
		/// <param name="p">Input parameters.</param>
		private static void PrintAttribs(FileSystemInfo o, oParams p) {
			Console.Write("{0}\t", oFileAttributes.ToString(oFileSystemInfo.GetAttributes(o), p.Verbose));
			foreach(char c in p.Get) {
				var v = DateTime.MinValue;
				if (c == 'c') v = oFileSystemInfo.GetCreationTime(o, p.Utc);
				if (c == 'g') v = oFileSystemInfo.GetLastAccessTime(o, p.Utc);
				if (c == 'w') v = oFileSystemInfo.GetLastWriteTime(o, p.Utc);
				Console.Write("{0}\t", p.Filetime ? (object)oDateTime.ToFileTime(v, p.Utc) : v);
			}
			Console.WriteLine(o.FullName);
		}
	}
}
