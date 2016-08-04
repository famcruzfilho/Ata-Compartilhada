using Adodb;
using Natura_Nova_Ata_3._0._0.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;

namespace Natura_Nova_Ata_3._0._0.DAO
{
    public class UserDAO
    {
        public static User instanceById(int userId)
        {
            nova_ataEntities db = new nova_ataEntities();
            var usr = (from u in db.users
                       where u.userId == userId
                       select u).First();
            if (usr == null)
            {
                throw new Exception("No register was found");
            }
            User user = new User(usr.userId, usr.alias, usr.name, usr.exchangeName, usr.email, usr.area, usr.managerName,
                usr.managerLogin, usr.managerEmail, usr.type);
            return user;
        }

        public static List<User> instanceByBusinessUnit(string businessUnit)
        {
            nova_ataEntities db = new nova_ataEntities();
            List<User> listOfUsers = new List<User>();
            var users = from u in db.users
                        where u.type == businessUnit
                        select u;
            foreach (var u in users)
            {
                User user = new User(u.userId, u.alias, u.name, u.exchangeName, u.email, u.area, u.managerName,
                    u.managerLogin, u.managerEmail, u.type);
                listOfUsers.Add(user);
            }
            return listOfUsers;
        }

        public static User instanceByAlias(string alias)
        {
            if (alias.Contains('\\'))
            {
                alias = alias.Split('\\')[1].ToUpper();
            }
            if (alias.ToUpper().Equals("RESOURCE"))
            {
                /*
                 * Felipe Maranzato
                 * alias = "FMARAZAT";
                 * Hannah Ralha
                 * alias = "38861097";
                 * Nelis Ortiz
                 * alias = "BR91688";
                 * Clissia Postale
                 * alias = "BR88822";
                 * Emerson Tosco
                 * alias = "ETOSCO";
                 */
                alias = "81971095";
            }
            nova_ataEntities db = new nova_ataEntities();
            var usr = (from u in db.users
                        where u.alias == alias
                        select u).First();
            if (usr == null)
            {
                throw new Exception("No register was found");
            }
            User user = new User(usr.userId, usr.alias, usr.name, usr.exchangeName, usr.email, usr.area, usr.managerName,
                usr.managerLogin, usr.managerEmail, usr.type);
            return user;
        }

        public static User instanceByName(string name)
        {
            nova_ataEntities db = new nova_ataEntities();
            name = string.Format("%{0}%", name.Replace(' ', '%'));
            StringBuilder sb = new StringBuilder();
            var arrayText = name.Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (char letter in arrayText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(letter);
                }
            }
            name = sb.ToString();
            var usr = db.users.Where(x => SqlFunctions.PatIndex(name, x.name) > 0);
            if (usr.Count() > 0)
            {
                User user = new User(usr.ToList()[0].userId, usr.ToList()[0].alias, usr.ToList()[0].name, usr.ToList()[0].exchangeName,
                    usr.ToList()[0].email, usr.ToList()[0].area, usr.ToList()[0].managerName, usr.ToList()[0].managerLogin,
                    usr.ToList()[0].managerEmail, usr.ToList()[0].type);
                return user;
            }
            else
            {
                return null;
            }
        }
    }
}