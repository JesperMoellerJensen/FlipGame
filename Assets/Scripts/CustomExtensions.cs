using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public static class CustomExtensions
{
	public static string MillisecondsToTimer(long milliseconds)
	{
		return string.Format("{0:D2}:{1:D2}:{2:D2}", milliseconds / 60000 % 60, milliseconds / 1000 % 60, milliseconds / 10 % 100);
	}
}

