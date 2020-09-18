using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using cnxAPI.DAL.Domain;

namespace cnxAPI.DAL.BusinessLogic
{ 
    public class MembersBL
    {
        private List<Member> _members;
        
        
        public MembersBL()
        {
            _members = new List<Member>();
        }

        public void Add(Member item)
        {
            //Tranforma un objeto a formato XML
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
                //Agrega un miembro a la biblioteca
                session.Add("members", ms);
                session.Close();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Member getMemberById(int id)
        {
            Member retvalue = new Member();
            try
            {
                Session session = new Session("localhost", 1984, "admin", "admin");
                session.Execute("check biblioteca");
                //Consulta miembros de la biblioteca por id
                string _query = " //member[id="+ id + "]";
                Query query = session.Query(_query);

                while (query.More())
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Member));
                    var strXML = query.Next();
                    var strWriter = new StringReader(strXML);
                    object _item = serializer.Deserialize(strWriter);
                    ((Member)_item).XMLFormat = strXML;
                    retvalue = (Member)_item;
                }
                session.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return retvalue;

        }

        public List<Member> getMembers()
        {
            List<Member> retvalue = new List<Member>();
            try
            {
                Session session = new Session("localhost", 1984, "admin", "admin");
                session.Execute("check biblioteca");
                //Consulta todos los miembros de la biblioteca
                string _query = " //member ";
                Query query = session.Query(_query);
                
                while (query.More())
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Member));
                    var strXML = query.Next();
                    var strWriter = new StringReader(strXML);
                    object _item = serializer.Deserialize(strWriter);
                    ((Member)_item).XMLFormat = strXML;
                    retvalue.Add((Member)_item);
                }
                session.Close();

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return retvalue;
        }
    }
}
