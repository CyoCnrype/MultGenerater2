using DBSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MultGenerater
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        
            var dt = DBHelper.GatData();
            var Base_txt = dt.Rows[0][0] ;
            var Coef_txt= dt.Rows[0][1] ;
            //this.txtBase.Text = Base_txt.ToString();
            //this.txtCoef.Text = Coef_txt.ToString();
            this.Label1.Text = $"上次數值：基數={Base_txt.ToString()}、係數={Coef_txt.ToString()}";

  
        }

        protected void btnCocu_Click(object sender, EventArgs e)
        {
            string inp_Base = this.txtBase.Text;
            string inp_Coef = this.txtCoef.Text;

            if (CheckInput(inp_Base, inp_Coef))
            {
                HttpContext.Current.Session["Base"] = inp_Base;
                HttpContext.Current.Session["Coef"] = inp_Coef;
                DBHelper.SaveData(Convert.ToInt32(inp_Base), Convert.ToInt32(inp_Coef));
                Response.Redirect("/ShowCase.aspx");
            }


        }

        private bool CheckInput(string inp_Base, string inp_Coef)
        {

            if (string.IsNullOrWhiteSpace(this.txtBase.Text) || string.IsNullOrWhiteSpace(this.txtCoef.Text))
            {
                ltMsg.Text = "基數或係數不可空白";
                return false;
            }

            if (Convert.ToInt32(inp_Base) <= 0 || Convert.ToInt32(inp_Coef) < 0)
            {
                ltMsg.Text = "基數或係數不可小於0";
                return false;
            }
            return true;
        }
    }
}