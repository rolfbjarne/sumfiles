using System;
using System.IO;

namespace sumfiles
{
	class MainClass
	{
		public static int Main (string [] args)
		{
			if (args.Length == 0) {
				Console.WriteLine ("No directories specified.");
				return 1;
			}

			var rv = true;
			foreach (var arg in args)
				rv &= Sum (arg);
			
			return rv ? 0 : 1;
		}

		public static bool Sum (string directory)
		{
			long total = 0;
			long count = 0;

			if (!Directory.Exists (directory)) {
				Console.WriteLine ($"{directory}: does not exist");
				return false;
			}

			foreach (var file in Directory.EnumerateFiles (directory, "*.*", SearchOption.AllDirectories)) {
				total += new FileInfo (file).Length;
				count++;
			}

			Console.WriteLine (string.Format (System.Globalization.CultureInfo.GetCultureInfo ("es-ES"), "{0}: {1} files, total {2:N0} bytes ({3:N3} KB, {4:N3} MB, {5:N3} GB)", directory, count, total, total / 1024.0, total / 1024.0 / 1024.0, total / 1024.0 / 1024.0 / 1024.0));
			return true;
		}
	}
}
