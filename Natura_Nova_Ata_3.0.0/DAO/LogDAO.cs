using Adodb;
using Natura_Nova_Ata_3._0._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Natura_Nova_Ata_3._0._0.DAO
{
    public class LogDAO
    {
        public static void insert(Log log)
        {
            try
            {
                nova_ataEntities db = new nova_ataEntities();
                var l = db.logs.Create();
                l.controller = log.getController();
                l.requestType = log.getRequestType();
                l.requester = log.getRequester().getUserId();
                l.date = log.getDate();
                l.time = log.getTime();
                l.attribute1 = log.getAttribute1();
                l.attribute2 = log.getAttribute2();
                l.body = log.getBody();
                db.logs.Add(l);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}