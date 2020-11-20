﻿using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TryItWeather
{
    public partial class _Default : Page
    {
        WeatherService.Service1Client weaService = new WeatherService.Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void tb4_TextChanged(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(tb4.Text))
            {
                errorLabel.Visible = true;
                myTable.Visible = false;
                headerTable.Visible = false;
                errorLabel.Text = "ERROR: " + "Please enter valid zipcode";
                return;
            }
            try
            {
                var output = weaService.Weather5day(tb4.Text);

                if (output.Length > 0 && string.Equals(output[0].ToString(), "ERROR"))
                {
                    myTable.Visible = false;
                    headerTable.Visible = false;
                    errorLabel.Visible = true;
                    errorLabel.Text = "ERROR: " + output[1].ToString();

                }
                if (output.Length > 0 && !string.Equals(output[0].ToString(), "ERROR"))
                {
                    headerTable.Visible = true;
                    errorLabel.Visible = false;
                    TableRow row;
                    TableCell cell1;
                    TableCell cell2;
                    TableCell cell3;
                    TableCell cell4;
                    TableCell cell5;
                    TableCell cell6;


                    row = new TableRow();
                    cell1 = new TableCell();
                    cell2 = new TableCell();
                    cell3 = new TableCell();
                    cell4 = new TableCell();
                    cell5 = new TableCell();
                    cell6 = new TableCell();
                    string[] colvalues = output[0].Split(',');
                    cell1.Text = colvalues[2];
                    cell2.Text = colvalues[0];
                    cell3.Text = colvalues[1];
                    cell4.Text = colvalues[3];
                    cell5.Text = colvalues[4];
                    row.Cells.Add(cell1);
                    row.Cells.Add(cell2);
                    row.Cells.Add(cell3);
                    row.Cells.Add(cell4);
                    row.Cells.Add(cell5);
                    headerTable.Rows.Add(row);

                    myTable.Visible = true;
                    var flag = false;

                    foreach (var op in output)
                    {
                        if (flag)
                        {
                            row = new TableRow();
                            cell1 = new TableCell();
                            cell2 = new TableCell();
                            cell3 = new TableCell();
                            cell4 = new TableCell();
                            cell5 = new TableCell();
                            cell6 = new TableCell();
                            colvalues = op.Split(',');
                            cell1.Text = colvalues[0];
                            cell2.Text = colvalues[1];
                            cell3.Text = colvalues[2];
                            cell4.Text = colvalues[3];
                            cell5.Text = colvalues[4];
                            cell6.Text = colvalues[5];
                            row.Cells.Add(cell1);
                            row.Cells.Add(cell2);
                            row.Cells.Add(cell3);
                            row.Cells.Add(cell4);
                            row.Cells.Add(cell5);
                            row.Cells.Add(cell6);
                            myTable.Rows.Add(row);
                        }
                        flag = true;

                    }

                }
                else
                {
                    myTable.Visible = false;
                    headerTable.Visible = false;
                }

            }
            catch (Exception ex)
            {
                errorLabel.Visible = true;
                myTable.Visible = false;
                headerTable.Visible = false;
                errorLabel.Text = "ERROR: " + ex.Message.ToString();
            }
        }

        protected void b1_Click(object sender, EventArgs e)
        {

        }
    }
}