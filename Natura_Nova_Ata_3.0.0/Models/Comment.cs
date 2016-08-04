using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Soap;
using System.Web;
using System.Xml.Serialization;

namespace Natura_Nova_Ata_3._0._0.Models
{
    [Serializable()]
    [XmlRoot("Comment")]
    public class Comment
    {
        public int commentId;
        public int taskId;
        public string comment;
        public string owner;
        public DateTime dateTime;
        public string creationDate;
        public string creationTime;

        public Comment()
        {
        }

        public Comment(int commentId, int taskId, string comment, string owner, DateTime dateTime)
        {
            setCommentId(commentId);
            setTaskId(taskId);
            setComment(comment);
            setOwner(owner);
            setDateTime(dateTime);
            setCreationDate();
            setCreationTime();
        }

        public Comment(int commentId, int taskId, string comment, string owner, string creationDate, string creationTime)
        {
            setCommentId(commentId);
            setTaskId(taskId);
            setComment(comment);
            setOwner(owner);
            setCreationDate(creationDate);
            setCreationTime(creationTime);
        }

        public void setCommentId(int commentId)
        {
            this.commentId = commentId;
        }

        public void setTaskId(int taskId)
        {
            this.taskId = taskId;
        }

        public void setComment(string comment)
        {
            this.comment = comment;
        }

        public void setOwner(string owner)
        {
            this.owner = owner;
        }

        public void setDateTime(DateTime dateTime)
        {
            this.dateTime = dateTime;
        }

        public void setCreationDate()
        {
            this.creationDate = string.Format("{0:dd/MM/yyyy}", this.dateTime);
        }

        public void setCreationDate(string creationDate)
        {
            this.creationDate = creationDate;
        }

        public void setCreationTime()
        {
            this.creationTime = string.Format("{0:HH:mm:ss}", this.dateTime);
        }

        public void setCreationTime(string creationTime)
        {
            this.creationTime = creationTime;
        }

        public int getCommentId()
        {
            return this.commentId;
        }

        public int getTaskId()
        {
            return this.taskId;
        }

        public string getComment()
        {
            return this.comment;
        }

        public string getOwner()
        {
            return this.owner;
        }

        public DateTime getDateTime()
        {
            return this.dateTime;
        }

        public string getCreationDate()
        {
            return this.creationDate;
        }

        public string getCreationTime()
        {
            return this.creationTime;
        }

        public string toString()
        {
            return string.Format("Id: {0}, Comment: {1}", this.commentId, this.comment);
        }

        public static void commentToXml(Comment comment)
        {
            try
            {
                FileStream fs = new FileStream(@"C:\Users\resource\Desktop\Nova Ata\comment.xml", FileMode.OpenOrCreate);
                SoapFormatter serializer = new SoapFormatter();
                serializer.Serialize(fs, comment);
                fs.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static Comment xmlToComment(User requester, HttpContext context)
        {
            try
            {
                Stream stream = context.Request.InputStream;
                stream.Position = 0;
                SoapFormatter serializer = new SoapFormatter();
                Comment comment = (Comment)serializer.Deserialize(stream);
                stream.Close();
                return comment;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}