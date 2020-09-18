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
                //conexión a la base de datos
                Session session = new Session("localhost", 1984, "admin", "admin");
                //abre base de datos
                session.Execute("check biblioteca");
                //Agrega un miembro a la biblioteca
                session.Add("book", ms);
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
                //conexión a la base de datos
                Session session = new Session("localhost", 1984, "admin", "admin");
                //abre base de datos
                session.Execute("check biblioteca");
                //Consulta a la base de datos
                string _query = " //book ";
                Query query = session.Query(_query);

                while (query.More())
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Books));
                    var strXML = query.Next();
                    var strWriter = new StringReader(strXML);
                    //Deserealiza xml a objeto
                    object _item = serializer.Deserialize(strWriter);
                    ((Books)_item).XMLFormat = strXML;
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

        public Books getLibros(int id)
        {
            Books retvalue = new Books();
            try
            {
                //conexión a la base de datos
                Session session = new Session("localhost", 1984, "admin", "admin");
                //abre base de datos
                session.Execute("check biblioteca");
                string _query = " //book[id=" + id + "]";
                Query query = session.Query(_query);

                while (query.More())
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Books));
                    var strXML = query.Next();
                    var strWriter = new StringReader(strXML);
                    //Deserealiza xml a objeto
                    object _item = serializer.Deserialize(strWriter);
                    ((Books)_item).XMLFormat = strXML;
                    retvalue =(Books)_item;
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
