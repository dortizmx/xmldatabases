using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using cnxAPI.DAL.Domain;

namespace cnxAPI.DAL.BusinessLogic
{
    public class LoansBL
    {
        public LoansBL()
        {
        }

        public void Add(Loans item)
        {
            item.Id = KeyCreator.getKey();
            //_members.Add(item);
            XmlSerializer serializer = new XmlSerializer(item.GetType());
            var memoryStream = new MemoryStream();
            var strWriter = new StringWriterUtf8();
            serializer.Serialize(strWriter, item);
            var strXML = strWriter.ToString();
            strWriter.Close();
            try
            {
                MemoryStream ms = new MemoryStream(
                      System.Text.Encoding.UTF8.GetBytes(strXML));
                Session session = new Session("localhost", 1984, "admin", "admin");
                session.Execute("check biblioteca");
                session.Add("loan", ms);
                session.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Loans getLoanById(string id)
        {
            Loans retvalue = new Loans();
            try
            {
                Session session = new Session("localhost", 1984, "admin", "admin");
                session.Execute("check biblioteca");
                string _query = " //loan[id=" + id + "]";
                Query query = session.Query(_query);

                while (query.More())
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Loans));
                    var strWriter = new StringReader(query.Next());
                    object _item = serializer.Deserialize(strWriter);
                    retvalue = (Loans)_item;
                }
                session.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return retvalue;
        }
        public Loans getLoanById(int memberid, int bookid)
        {
            Loans retvalue = new Loans();
            try
            {
                Session session = new Session("localhost", 1984, "admin", "admin");
                session.Execute("check biblioteca");
                string _query = " //loan[memberid=" + memberid + ":bookid="+ bookid + "]";
                Query query = session.Query(_query);

                while (query.More())
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Loans));
                    var strWriter = new StringReader(query.Next());
                    object _item = serializer.Deserialize(strWriter);
                    retvalue = (Loans)_item;
                }
                session.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return retvalue;

        }

        public List<Loans> getLoans()
        {
            List<Loans> retvalue = new List<Loans>();
            try
            {
                Session session = new Session("localhost", 1984, "admin", "admin");
                session.Execute("check biblioteca");
                string _query = " //loan ";
                Query query = session.Query(_query);

                while (query.More())
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Loans));
                    var strWriter = new StringReader(query.Next());
                    object _item = serializer.Deserialize(strWriter);
                    retvalue.Add((Loans)_item);
                }
                session.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return retvalue;
        }
    }
}
