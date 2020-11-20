using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TryitWsOperationWebPage
{
    public partial class _Default : Page
    {
        WsOperationsService.WsOperationsServiceClient wsOpService = new WsOperationsService.WsOperationsServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void tb4_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void b1_Click(object sender, EventArgs e)
        {
            try
            {
                var output = wsOpService.WsOperations(tb4.Text.ToString());
                if(output.Length>0 && string.Equals(output[0].ToString(), "ERROR"))
                {
                    myTable.Visible = false;
                    errorLabel.Visible = true;
                    errorLabel.Text = "ERROR: " + output[1].ToString();

                }
                if(output.Length > 0 && !string.Equals(output[0].ToString(), "ERROR"))
                {

                    myTable.Visible = true;
                    errorLabel.Visible = false;
                    TableRow row;
                    TableCell cell1;
                    TableCell cell2;
                    TableCell cell3;

                    foreach (var op in output)
                    {
                        row = new TableRow();
                        cell1 = new TableCell();
                        cell2 = new TableCell();
                        cell3 = new TableCell();
                        string[] colvalues = op.Split(',');
                        cell1.Text = colvalues[0];
                        cell2.Text = colvalues[1];
                        cell3.Text = colvalues[2];
                        row.Cells.Add(cell1);
                        row.Cells.Add(cell2);
                        row.Cells.Add(cell3);
                        myTable.Rows.Add(row);
                        
                    }
                }
                else
                {
                    myTable.Visible = false;
                }

            }
            catch (Exception ex)
            {
                errorLabel.Visible = true;
                myTable.Visible = false;
                errorLabel.Text = "ERROR: " + ex.Message.ToString();
            }

        }
    }
}