using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MultGenerater
{
    public partial class ShowCase : System.Web.UI.Page
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

            //int start = 10; //baseInt
            //int End = 9; //coefInt
            int counter = 1;

            for (int i = 0; i < ((baseInt / 3) + 1); i++)
            {
                TableRow tRow = new TableRow();     //create a new object of type TableRow
                table.Rows.Add(tRow);
                for (int iii = 0; iii < 3; iii++)
                {
                    TableCell tCell_0 = new TableCell();
                    //tCell_0.Text = ii.ToString();
                    //tRow.Cells.Add(tCell_0);
                    if (counter <= baseInt)
                    {
                        tCell_0.Text += $"基數{counter} <br/>";
                        tCell_0.Text += "--------------------<br/>";
                        for (int ii = 0; ii < coefInt; ii++)
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
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    int baseInt = Convert.ToInt32(HttpContext.Current.Session["Base"] as string);
        //    int coefInt = Convert.ToInt32(HttpContext.Current.Session["Coef"] as string);

        //    Literal[] ShowCase = new Literal[baseInt];    //Label  ShowCase

        //    for (int i = 0; i < ShowCase.Length; i++)
        //    {
        //        ShowCase[i] = new Literal();
        //        ShowCase[i].ID = "SC" + (i + 1).ToString();
        //        ShowCase[i].Text = $"基數{i+1} <br/>";
        //        ShowCase[i].Text += "--------------------<br/>";
        //        //ShowCase[i].Height = 25;
        //        //ShowCase[i].Width = 70;
        //        //ShowCase[i].BorderStyle = "Double";
        //        PanelCase.Controls.Add(ShowCase[i]);

        //        for (int ii = 0; ii < coefInt; ii++)
        //        {
        //            ShowCase[i].Text += $"{i+1} * {ii+1} = {(i+1)*(ii+1)}  <br/>";
        //        }
        //        ShowCase[i].Text += "--------------------<br/>";
        //    }

        //}
        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Default.aspx");
        }
    }

}