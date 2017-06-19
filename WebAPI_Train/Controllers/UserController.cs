using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;

namespace WebAPI_Train.Controllers
{
    public class UserController : ApiController
    {
        JDB.JDB Main = new JDB.JDB();
        JDB.CommTool Comm = new JDB.CommTool();

        // GET: api/User
        public List<Models.User> Get()
        {
            Main.ParaClear();
            string str = "Select * from Users ";
            DataTable d = Main.GetDataSet(str);

           List<Models.User> us = new List< Models.User>() { };
            if (d.Rows.Count > 0)
            {
                foreach (DataRow dw in d.Rows)
                {
                    us.Add(new Models.User()
                    {
                        id = Comm.Cint2(dw["IDNo"].ToString()),
                        userId = dw["User_ID"].ToString(),
                        userName = dw["User_Name"].ToString()
                    });
                }
            }
            return us;
        }

        // GET: api/User/5
        public Models.User Get(int id)
        {
            Main.ParaClear();
            Main.ParaAdd("@IDNo", id, System.Data.SqlDbType.VarChar);
            string str = "Select * from Users where IDNo=@IDNo";
            DataTable d = Main.GetDataSet(str);

            Models.User us = new Models.User() { };
            if (d.Rows.Count > 0)
            {
                DataRow dw = d.Rows[0];
                us.id = Comm.Cint2(dw["IDNo"].ToString());
                us.userId = dw["User_ID"].ToString();
                us.userName = dw["User_Name"].ToString();
            }
            return us;
        }
         
    }
}
