using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using cnxAPI.DAL.Domain;

namespace cnxAPI.DAL.BusinessLogic
{
    public class LibrosBL
    {
        private List<Books> _libros;
        //private XmlSerializer serializer;
        public LibrosBL()
        {
            _libros = new List<Books>();
        }

        

        

        public void Add(Books item)
        {
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
                session.Add("biblioteca/libros", ms);
                session.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Books> getLibros()
        {
            List<Books> retvalue = new List<Books>();
            try
            {
                Session session = new Session("localhost", 1984, "admin", "admin");
                session.Execute("check biblioteca");
                string _query = " //libro ";
                Query query = session.Query(_query);

                while (query.More())
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Books));
                    var strWriter = new StringReader(query.Next());
                    object _item = serializer.Deserialize(strWriter);
                    retvalue.Add((Books)_item);
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
