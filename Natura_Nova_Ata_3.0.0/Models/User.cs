using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Natura_Nova_Ata_3._0._0.Models
{
    [Serializable()]
    public class User
    {
        public int userId;
        public string alias;
        public string name;
        public string exchangeName;
        public string email;
        public string area;
        public string managerName;
        public string managerLogin;
        public string managerEmail;
        public string type;
        
        public User()
        {
        }

        public User(string alias, string name, string email, string area)
        {
            setAlias(alias);
            setName(name);
            setEmail(email);
            setArea(area);
        }

        public User(int userId, string alias, string name, string email, string area)
        {
            setUserId(userId);
            setAlias(alias);
            setName(name);
            setEmail(email);
            setArea(area);
        }

        public User(int userId, string alias, string name, string exchangeName, string email, string area,
            string managerName, string managerLogin, string managerEmail, string type)
        {
            setUserId(userId);
            setAlias(alias);
            setName(name);
            setExchangeName(exchangeName);
            setEmail(email);
            setArea(area);
            setManagerName(managerName);
            setManagerLogin(managerLogin);
            setManagerEmail(managerEmail);
            setType(type);
        }

        public void setUserId(int userId)
        {
            this.userId = userId;
        }

        public void setAlias(string alias)
        {
            this.alias = alias.ToUpper();
        }

        public void setName(string name)
        {
            this.name = name.ToUpper();
        }

        public void setExchangeName(string exchangeName)
        {
            this.exchangeName = exchangeName.ToUpper();
        }

        public void setEmail(string email)
        {
            this.email = email.ToUpper();
        }

        public void setArea(string area)
        {
            this.area = area.ToUpper();
        }

        public void setManagerName(string managerName)
        {
            this.managerName = managerName.ToUpper();
        }

        public void setManagerLogin(string managerLogin)
        {
            this.managerLogin = managerLogin.ToUpper();
        }

        public void setManagerEmail(string managerEmail)
        {
            this.managerEmail = managerEmail.ToUpper();
        }

        public void setType(string type)
        {
            if (type != null)
            {
                this.type = type.ToUpper();
            }
        }

        public int getUserId()
        {
            return this.userId;
        }

        public string getAlias()
        {
            return this.alias;
        }

        public string getName()
        {
            return this.name;
        }

        public string getExchangeName()
        {
            return this.exchangeName;
        }

        public string getEmail()
        {
            return this.email;
        }

        public string getArea()
        {
            return this.area;
        }

        public string getManagerName()
        {
            return this.managerName;
        }

        public string getManagerLogin()
        {
            return this.managerLogin;
        }

        public string getManagerEmail()
        {
            return this.managerEmail;
        }

        public string getType()
        {
            return this.type;
        }

        public string toString()
        {
            return string.Format("User ID: {0}, Alias: {1}, Name: {2}, E-mail: {3}, Area: {4}", this.userId, this.alias, this.name, this.email, this.area);
        }
    }
}