using System;
using System.Text;

namespace cnxAPI.DAL
{
    public class DBConnections
    {
        private Session _session;
        public DBConnections()
        {
            _session = new Session("localhost", 1984, "admin", "admin");
        }

        public string getAll()
        {
            var retvalue = _session.Execute("xquery /");
            _session.Close();
            return retvalue;
        }

        public string getByQuery(string strquery)
        {
            var retvalue = new StringBuilder();
            var _query = _session.Query(strquery);
            //Query query = session.Query();
            while (_query.More())
            {
                retvalue.Append(_query.Next());
            }
            _session.Close();
            return retvalue.ToString();
        }
    }
}
