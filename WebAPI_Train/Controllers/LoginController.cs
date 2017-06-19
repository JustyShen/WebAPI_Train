using System;
using System.Collections.Generic; 
using System.Net;
using System.Net.Http;
using System.Data;
using System.Web.Http;
using System.Web;


namespace WebAPI_Train.Controllers
{
    public class LoginController : ApiController
    {
        JDB.JDB Main = new JDB.JDB();
        JDB.CommTool Comm = new JDB.CommTool();

        // POST: api/Login
        public int Post([FromBody]Models.Login login)
        {
            int result = 0;
            Main.ParaClear();
            Main.ParaAdd("@User_ID", login.uid, System.Data.SqlDbType.VarChar);
            string str = "Select * from Users where User_ID=@User_ID";
            DataTable d = Main.GetDataSet(str);
            if (d.Rows.Count > 0)
            {
                DataRow dw = d.Rows[0];
                if (login.pwd == dw["Password"].ToString())
                {
                    HttpContext.Current.Session["User_ID"] = dw["User_ID"].ToString();
                    result = 1;
                }
                else
                {
                    result = 0;
                }
            }
            return result;
        }
    }
}
