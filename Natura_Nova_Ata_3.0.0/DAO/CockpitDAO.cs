using Adodb;
using Natura_Nova_Ata_3._0._0.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace Natura_Nova_Ata_3._0._0.DAO
{
    public class CockpitDAO
    {
        public static Response delete(User requester, Cockpit cockpit)
        {
            try
            {
                nova_ataEntities db = new nova_ataEntities();
                var cp = db.cockpit.Find(cockpit.getCockpitId());
                if (cp != null)
                {
                    db.cockpit.Remove(cp);
                    db.SaveChanges();
                }
                return new Response(cockpit.getCockpitId(), "Deleted", cockpit.getHash());
            }
            catch
            {
                return new Response(cockpit.getCockpitId(), "Fail", cockpit.getHash());
            }
        }

        public static List<Response> insertOrUpdate(User requester, Cockpit[] listOfCockpits)
        {
            try
            {
                List<Response> listOfResponses = new List<Response>();
                nova_ataEntities db = new nova_ataEntities();
                foreach (Cockpit cockpit in listOfCockpits)
                {
                    if (cockpit.getCockpitId() < 0)
                    {
                        int cockpitId = Math.Abs(cockpit.getCockpitId());
                        cockpit.setCockpitId(cockpitId);
                        listOfResponses.Add(CockpitDAO.delete(requester, cockpit));
                        continue;
                    }
                    bool isNew = false;
                    var cp = (dynamic)null;
                    if (cockpit.getCockpitId() == 0)
                    {
                        isNew = true;
                        cp = db.cockpit.Create();
                    }
                    else
                    {
                        isNew = false;
                        cp = db.cockpit.Find(cockpit.getCockpitId());
                        if (cp == null)
                        {
                            listOfResponses.Add(new Response(cockpit.getCockpitId(), "Fail. Result not found", cockpit.getHash()));
                        }
                    }
                    cp.projectId = cockpit.getProjectId();
                    cp.description = cockpit.getDescription();
                    cp.type = cockpit.getType();
                    cp.code = cockpit.getCode();
                    cp.dummyCode = cockpit.getDummyCode();
                    cp.parentSellCode = cockpit.getParentSellCode();
                    cp.parentZpac = cockpit.getParentZpac();
                    cp.hash = cockpit.getHash();
                    if (isNew)
                    {
                        db.cockpit.Add(cp);
                    }
                    db.SaveChanges();
                    if (isNew)
                    {
                        listOfResponses.Add(new Response(cp.cockpitId, "Created", cockpit.getHash()));
                    }
                    else
                    {
                        listOfResponses.Add(new Response(cockpit.getCockpitId(), "Edited", cockpit.getHash()));
                    }
                }
                return listOfResponses;
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

        public static List<CockpitSAP> select(User requester, int[] projectIdList)
        {
            try
            {
                List<CockpitSAP> listOfCockpitSAPs = new List<CockpitSAP>();
                nova_ataEntities db = new nova_ataEntities();
                var data = from cp in db.cockpit
                           join p in db.projects on cp.projectId equals p.projectId
                           from cps in db.cockpit_sap
                               .Where(cps => cps.material == cp.code)
                               .DefaultIfEmpty()
                           where projectIdList.Contains(cp.projectId)
                           select new
                           {
                               cp.cockpitId,
                               cp.projectId,
                               p.name,
                               cp.description,
                               cp.type,
                               cp.code,
                               cp.dummyCode,
                               cp.parentSellCode,
                               cp.parentZpac,
                               cp.hash,
                               cps.sm,
                               cps.workItemText,
                               cps.currentResponsible,
                               cps.generationDate,
                               cps.realInDate,
                               cps.finished,
                               cps.deadline,
                               cps.sellCode
                           };
                foreach (var t in data)
                {
                    CockpitSAP cockpitSAP = new CockpitSAP(t.cockpitId, t.projectId, t.name, t.description, t.type, t.code, t.dummyCode,
                         t.parentSellCode, t.parentZpac, t.hash, t.sm, t.workItemText, t.currentResponsible, t.generationDate,
                         t.realInDate, t.finished, t.deadline, t.sellCode);
                    listOfCockpitSAPs.Add(cockpitSAP);
                }
                return listOfCockpitSAPs;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}