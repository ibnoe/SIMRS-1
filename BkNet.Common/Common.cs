using System;

namespace BkNet.Common
{
	/// <summary>
	/// Summary description for Common.
	/// </summary>
	public class Common
	{
		public Common()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public bool IsDate(Object obj)
		{
			string strDate = obj.ToString();
			try 
			{
				DateTime dt = DateTime.Parse(strDate);
				if(dt != DateTime.MinValue  && dt != DateTime.MaxValue)
					return true;
				return false;
			}
			catch
			{
				return false;
			}
		}

	}
}
