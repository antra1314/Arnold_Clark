using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArnoldClark
{
    public class DrawGrid 
    {
        private DateTime deliveryDate;
        private DropDownList drpFinanceYear;
        private GridView gridView;
        private decimal emiForEachMonth;

        public DrawGrid(DateTime deliveryDate, DropDownList drpFinanceYear, GridView gridView, decimal emiForEachMonth)
        {
            this.deliveryDate = deliveryDate;
            this.drpFinanceYear = drpFinanceYear;
            this.gridView = gridView;
            this.emiForEachMonth = emiForEachMonth;
        }
        public void designGrid()
        {           
            DateTime dueDate;
            int numberOfInstallment = Convert.ToInt32(drpFinanceYear.SelectedValue) * 12;
            int year = deliveryDate.Year;
            int month2 = deliveryDate.Month;
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[2] { new DataColumn("Date"), new DataColumn("Amount Due") });

            for (int installment = 1; installment <= numberOfInstallment; installment++)
            {
                DateUtility.calculateDueDate(out dueDate, ref year, ref month2, installment, deliveryDate);
                
                //Dsiplay Summary in Gridview
                if (installment == 1)
                {
                    dt.Rows.Add(dueDate.Date.ToShortDateString(), String.Format("{0:.##}", (emiForEachMonth + 88)));
                }
                else if (installment == numberOfInstallment)
                {
                    dt.Rows.Add(dueDate.Date.ToShortDateString(), String.Format("{0:.##}", (emiForEachMonth + 20)));
                }
                else
                {
                    dt.Rows.Add(dueDate.Date.ToShortDateString(), String.Format("{0:.##}", emiForEachMonth));
                }
              
              

            }
            this.bindGrid(dt);

        }

        protected void bindGrid(DataTable dt)
        {
            gridView.DataSource = dt;
            gridView.DataBind();
        }

    }
}