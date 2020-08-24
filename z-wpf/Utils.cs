﻿using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;

namespace z_wpf
{
	public class Utils
	{

		static string dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "T\\");

		static string mtg = Path.Combine(dir, "mtgs.json");


		public static void newFile(string path)
		{
			File.Create(path).Dispose();
		}

		public static ObservableCollection<Meeting> readMtgs()
		{
			if (!Directory.Exists(dir)) return new ObservableCollection<Meeting>();
			String json = "";
			if (File.Exists(mtg))
			{
				json = File.ReadAllText(mtg);
			}
			if (!String.IsNullOrEmpty(json))
			{
				var ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
				var ser = new DataContractJsonSerializer(typeof(Meeting[]));
				ms.Position = 0;
				try
				{
					var r = ser.ReadObject(ms) as Meeting[];
					ms.Close();
					var oc = new ObservableCollection<Meeting>();
					foreach (Meeting m in r)
					{
						oc.Add(m);
					}
					return oc;
				}
				catch
				{
				}
				newFile(mtg);
				return new ObservableCollection<Meeting>();
			}
			newFile(mtg);
			return new ObservableCollection<Meeting>();
		}

		public static void writeMtgs(ObservableCollection<Meeting> ls)
		{
			Directory.CreateDirectory(dir);
			Meeting[] ma = ls.ToArray<Meeting>();
			Type t = typeof(Meeting[]);
			DataContractJsonSerializer j = new DataContractJsonSerializer(t);
			var stream = new MemoryStream();
			stream.Position = 0;
			j.WriteObject(stream, ma);
			byte[] json_ba = stream.ToArray();
			stream.Close();
			File.WriteAllText(mtg, Encoding.UTF8.GetString(json_ba, 0, json_ba.Length));
		}

		public static async void OpenBrowser(string url)
		{
			// Launch the URI
			var success = await Windows.System.Launcher.LaunchUriAsync(new Uri(url));

		}
	}
}