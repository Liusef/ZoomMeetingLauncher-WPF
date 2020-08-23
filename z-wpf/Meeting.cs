using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace z_wpf
{
	[DataContract]
	public class Meeting
	{
		[DataMember]
		public string name { get; set; }
		[DataMember]
		public string desc { get; set; }
		[DataMember]
		public string code { get; set; }
		[DataMember]
		public string pwd { get; set; }
		[DataMember]
		public string url { get; set; }
		//[DataMember]
		//public List<dateTime> DT;

		public Meeting(string className, string description, string roomCode, string roomPwd/*, List<dateTime> al = null*/)
		{
			name = className;
			desc = description;
			code = roomCode.Replace(" ", "");
			pwd = roomPwd.Replace(" ", "");
			url = "zoommtg://zoom.us/join?confno=" + roomCode;
			if (!String.IsNullOrEmpty(roomPwd))
			{
				url += "&pwd=" + roomPwd;
			}
			/*DT = new List<dateTime>();
			if (al != null)
			{
				DT.AddRange(al);
			}*/
		}

		public override bool Equals(object obj)
		{
			try
			{
				obj = (Meeting)obj;
			}
			catch
			{
				return false;
			}
			return (name.Equals(((Meeting)obj).name)) && (desc.Equals(((Meeting)obj).desc)) && (code.Equals(((Meeting)obj).code)) && (pwd.Equals(((Meeting)obj).pwd));
		}
	}
}
