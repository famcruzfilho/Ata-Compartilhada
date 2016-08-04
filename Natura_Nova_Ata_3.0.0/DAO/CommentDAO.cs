using Adodb;
using Natura_Nova_Ata_3._0._0.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace Natura_Nova_Ata_3._0._0.DAO
{
    public class CommentDAO
    {
        public static Response insert(User requester, Comment comment)
        {
            var c = (dynamic)null;
            try
            {
                nova_ataEntities db = new nova_ataEntities();
                c = db.comments.Create();
                c.taskId = comment.getTaskId();
                c.comment = comment.getComment();
                c.owner = requester.getUserId();
                DateTime dateTime = DateTime.Now;
                c.creationDate = string.Format("{0:dd/MM/yyyy}", dateTime);
                c.creationTime = string.Format("{0:hh:mm:ss}", dateTime);
                db.comments.Add(c);
                db.SaveChanges();
                return new Response(c.taskId, "Created", "");
            }
            catch (DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}", validationErrors.Entry.Entity.ToString(), validationError.ErrorMessage);
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
        }

        public static List<Comment> select(int taskId)
        {
            try
            {
                nova_ataEntities db = new nova_ataEntities();
                List<Comment> lc = new List<Comment>();
                var com = from c in db.comments
                          where c.taskId == taskId
                          select new { c.commentId, c.taskId, c.comment, owner = c.users.exchangeName, c.creationDate, c.creationTime };
                foreach (var c in com.ToList())
                {
                    Comment comment = new Comment(c.commentId, c.taskId, c.comment, c.owner, c.creationDate, c.creationTime);
                    lc.Add(comment);
                }
                return lc;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static string selectLastComment(int taskId)
        {
            try
            {
                nova_ataEntities db = new nova_ataEntities();
                try
                {
                    var uc = (from c in db.comments
                              where c.taskId == taskId
                              orderby c.commentId descending
                              select c).First();
                    return uc.comment;
                }
                catch
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}