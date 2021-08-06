using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MultGenerater
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int baseInt = Convert.ToInt32(HttpContext.Current.Session["Base"] as string);
            int coefInt = Convert.ToInt32(HttpContext.Current.Session["Coef"] as string);
            //Literal[] ShowCase = new Literal[baseInt];    //Label  ShowCase

            Table table = new Table();                  //create one object of type Table
            table.ID = "Table_Item";
            table.Attributes.Add("border", "1px");  //自己加一個屬性
            table.Style["font-size"] = "9pt";         //設定Style
            table.Style["width"] = "100%";

            int start = 10; //baseInt
            int End = 9; //coefInt
            int counter = 1;

            for (int i = 0; i < ((start / 3) + 1); i++)
            {
                TableRow tRow = new TableRow();     //create a new object of type TableRow
                table.Rows.Add(tRow);
                for (int iii = 0; iii < 3; iii++)
                {
                    TableCell tCell_0 = new TableCell();
                    //tCell_0.Text = ii.ToString();
                    //tRow.Cells.Add(tCell_0);
                    if (counter <= start)
                    {
                        tCell_0.Text += $"基數{counter} <br/>";
                        tCell_0.Text += "--------------------<br/>";
                        for (int ii = 0; ii < End; ii++)
                        {
                            tCell_0.Text += $"{counter} * {ii + 1} = {counter * (ii + 1)}  <br/>";
                            tRow.Cells.Add(tCell_0);
                        }
                        counter++;
                    }
                }
            }
            Page.Controls.Add(table);
        }
    }
}