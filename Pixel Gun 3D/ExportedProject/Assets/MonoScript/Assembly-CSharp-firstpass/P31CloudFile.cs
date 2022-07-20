using System.IO;
using UnityEngine;

public class P31CloudFile
{
	internal class LocalFileManager
	{
		protected string basePath;

		public LocalFileManager(string basePath)
		{
			this.basePath = basePath;
		}

		public bool exists(string file)
		{
			return File.Exists(Path.Combine(basePath, file));
		}

		public bool delete(string file)
		{
			File.Delete(Path.Combine(basePath, file));
			return true;
		}

		public virtual bool writeAllBytes(string file, byte[] bytes)
		{
			File.WriteAllBytes(Path.Combine(basePath, file), bytes);
			return true;
		}

		public virtual bool writeAllText(string file, string text)
		{
			File.WriteAllText(Path.Combine(basePath, file), text);
			return true;
		}

		public byte[] readAllBytes(string file)
		{
			string path = Path.Combine(basePath, file);
			if (File.Exists(path))
			{
				return File.ReadAllBytes(path);
			}
			return null;
		}

		public string[] readAllLines(string file)
		{
			string path = Path.Combine(basePath, file);
			if (File.Exists(path))
			{
				return File.ReadAllLines(path);
			}
			return null;
		}

		public string[] listAllFiles()
		{
			return Directory.GetFiles(basePath);
		}
	}

	internal class CloudFileManager : LocalFileManager
	{
		public CloudFileManager(string basePath)
			: base(basePath)
		{
		}

		public override bool writeAllBytes(string file, byte[] bytes)
		{
			if (!exists(file))
			{
				File.WriteAllBytes(Path.Combine(Application.persistentDataPath, file), bytes);
				return iCloudBinding.addFile(file);
			}
			return base.writeAllBytes(file, bytes);
		}

		public override bool writeAllText(string file, string text)
		{
			if (!exists(file))
			{
				File.WriteAllText(Path.Combine(Application.persistentDataPath, file), text);
				return iCloudBinding.addFile(file);
			}
			return base.writeAllText(file, text);
		}
	}

	private static LocalFileManager _file;

	static P31CloudFile()
	{
		if (P31Prefs.iCloudDocumentStoreAvailable)
		{
			_file = new CloudFileManager(iCloudBinding.documentsDirectory());
		}
		else
		{
			_file = new LocalFileManager(Application.persistentDataPath);
		}
	}

	public static bool exists(string file)
	{
		return _file.exists(file);
	}

	public static bool delete(string file)
	{
		return _file.delete(file);
	}

	public static bool writeAllBytes(string file, byte[] bytes)
	{
		return _file.writeAllBytes(file, bytes);
	}

	public static bool writeAllText(string file, string text)
	{
		return _file.writeAllText(file, text);
	}

	public static string[] readAllLines(string file)
	{
		return _file.readAllLines(file);
	}

	public static byte[] readAllBytes(string file)
	{
		return _file.readAllBytes(file);
	}

	public static string[] listAllFiles()
	{
		return _file.listAllFiles();
	}
}
