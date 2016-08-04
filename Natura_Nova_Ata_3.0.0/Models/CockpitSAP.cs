using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Natura_Nova_Ata_3._0._0.Models
{
    [Serializable()]
    [XmlRoot("CockpitSAP")]
    public class CockpitSAP : Cockpit
    {
        public string cen;
        public string codCntrl;
        public string material;
        public string sellCode;
        public string materialShortText;
        public string createdIn;
        public string created;
        public string tmat;
        public string sm;
        public string umb;
        public string gross;
        public string net;
        public string un;
        public string volume;
        public string uvl;
        public string prcStand;
        public string money;
        public string workflow;
        public string ident;
        public string task;
        public string status1;
        public string status2;
        public string status3;
        public string messageText;
        public string currentResponsible;
        public string generationDate;
        public string generationTime;
        public string realInDate;
        public string realExDate;
        public string finished;
        public string endTime;
        public string utlEndTime;

        public CockpitSAP()
        {
        }

        public CockpitSAP(int cockpitId, int projectId, string projectName, string description, string type, string code,
            string dummyCode, string parentSellCode, string parentZpac, string hash, string sm, string workItemText,
            string currentResponsible, string generationDate, string realInDate, string finished, string deadline,
            string sellCode)
        {
            setCockpitId(cockpitId);
            setProjectId(projectId);
            setProjectName(projectName);
            setDescription(description);
            setType(type);
            setCode(code);
            setDummyCode(dummyCode);
            setParentSellCode(parentSellCode);
            setParentZpac(parentZpac);
            setHash(hash);
            setSm(sm);
            setWorkItemText(workItemText);
            setCurrentResponsible(currentResponsible);
            setGenerationDate(generationDate);
            setRealInDate(realInDate);
            setFinished(finished);
            setDeadline(deadline);
            setSellCode(sellCode);
        }

        public void setCen(string cen)
        {
            this.cen = cen;
        }

        public void setCodCntrl(string codCntrl)
        {
            this.codCntrl = codCntrl;
        }

        public void setMaterial(string material)
        {
            this.material = material;
        }

        public void setSellCode(string sellCode)
        {
            this.sellCode = sellCode;
        }

        public void setMaterialShortText(string materialShortText)
        {
            this.materialShortText = materialShortText;
        }

        public void setCreatedIn(string createdIn)
        {
            this.createdIn = createdIn;
        }

        public void setCreated(string created)
        {
            this.created = created;
        }

        public void setTmat(string tmat)
        {
            this.tmat = tmat;
        }

        public void setSm(string sm)
        {
            this.sm = sm;
        }

        public void setUmb(string umb)
        {
            this.umb = umb;
        }

        public void setGross(string gross)
        {
            this.gross = gross;
        }

        public void setLiquido(string net)
        {
            this.net = net;
        }

        public void setUn(string un)
        {
            this.un = un;
        }

        public void setVolume(string volume)
        {
            this.volume = volume;
        }

        public void setUvl(string uvl)
        {
            this.uvl = uvl;
        }

        public void setPrcStand(string prcStand)
        {
            this.prcStand = prcStand;
        }

        public void setMoney(string money)
        {
            this.money = money;
        }

        public void setWorkflow(string workflow)
        {
            this.workflow = workflow;
        }

        public void setIdent(string ident)
        {
            this.ident = ident;
        }

        public void setTask(string task)
        {
            this.task = task;
        }

        public void setStatus1(string status1)
        {
            this.status1 = status1;
        }

        public void setStatus2(string status2)
        {
            this.status2 = status2;
        }

        public void setStatus3(string status3)
        {
            this.status3 = status3;
        }

        public void setMessageText(string messageText)
        {
            this.messageText = messageText;
        }

        public void setCurrentResponsible(string currentResponsible)
        {
            this.currentResponsible = currentResponsible;
        }

        public void setGenerationDate(string generationDate)
        {
            this.generationDate = generationDate;
        }

        public void setGenerationTime(string generationTime)
        {
            this.generationTime = generationTime;
        }

        public void setRealInDate(string realInDate)
        {
            this.realInDate = realInDate;
        }

        public void setRealExDate(string realExDate)
        {
            this.realExDate = realExDate;
        }

        public void setFinished(string finished)
        {
            this.finished = finished;
        }

        public void setEndTime(string endTime)
        {
            this.endTime = endTime;
        }
        
        public void setUtlEndTime(string utlEndTime)
        {
            this.utlEndTime = utlEndTime;
        }

        public string getCen()
        {
            return this.cen;
        }

        public string getCodCntrl()
        {
            return this.codCntrl;
        }

        public string getMaterial()
        {
            return this.material;
        }

        public string getSellCode()
        {
            return this.sellCode;
        }

        public string getMaterialShortText()
        {
            return this.materialShortText;
        }

        public string getCreatedIn()
        {
            return this.createdIn;
        }

        public string getCreated()
        {
            return this.created;
        }

        public string getTmat()
        {
            return this.tmat;
        }

        public string getSm()
        {
            return this.sm;
        }

        public string getUmb()
        {
            return this.umb;
        }

        public string getGross()
        {
            return this.gross;
        }

        public string getLiquido()
        {
            return this.net;
        }

        public string getUn()
        {
            return this.un;
        }

        public string getVolume()
        {
            return this.volume;
        }

        public string getUvl()
        {
            return this.uvl;
        }

        public string getPrcStand()
        {
            return this.prcStand;
        }

        public string getMoney()
        {
            return this.money;
        }

        public string getWorkflow()
        {
            return this.workflow;
        }

        public string getIdent()
        {
            return this.ident;
        }

        public string getTask()
        {
            return this.task;
        }
        
        public string getStatus1()
        {
            return this.status1;
        }

        public string getStatus2()
        {
            return this.status2;
        }

        public string getStatus3()
        {
            return this.status3;
        }

        public string getMessageText()
        {
            return this.messageText;
        }

        public string getCurrentResponsible()
        {
            return this.currentResponsible;
        }

        public string getGenerationDate()
        {
            return this.generationDate;
        }

        public string getGenerationTime()
        {
            return this.generationTime;
        }

        public string getRealInDate()
        {
            return this.realInDate;
        }

        public string getRealExDate()
        {
            return this.realExDate;
        }

        public string getFinished()
        {
            return this.finished;
        }

        public string getEndTime()
        {
            return this.endTime;
        }

        public string getUtlEndTime()
        {
            return this.utlEndTime;
        }

        public string toString()
        {
            return string.Format("Id: {0}", this.cockpitId);
        }
    }
}