using System;
using System.Text;

namespace cnxAPI.DAL
{
    public static class KeyCreator
    {
        public static string getKey()
        {
            Random _random = new Random();
            StringBuilder retvalue = new StringBuilder();
            retvalue.Append(DateTime.Now.Year.ToString());
            retvalue.Append(DateTime.Now.Month.ToString());
            retvalue.Append(DateTime.Now.Day.ToString());
            retvalue.Append(DateTime.Now.Hour.ToString());
            retvalue.Append(DateTime.Now.Minute.ToString());
            retvalue.Append(DateTime.Now.Second.ToString());
            retvalue.Append(DateTime.Now.Millisecond.ToString());
            retvalue.Append(_random.Next(0, 250000).ToString());
            return retvalue.ToString();
        }
    }
}
