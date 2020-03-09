using System;

using System.Data;
using System.Web.UI;


namespace ArnoldClark
{
    public partial class _Default : Page
    {
        DateTime deliveryDate;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[2] { new DataColumn("Date"), new DataColumn("Amount Due") });
                ViewState["Summary"] = dt;
                this.bindGrid(dt);
            }

        }
        protected void bindGrid(DataTable dt)
        {
            grdSummary.DataSource = dt;
            grdSummary.DataBind();
        }



        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            lblSummary.Visible = true;
            int deposit = Convert.ToInt32(txtDepositAmount.Text);
            int vehiclePrice = Convert.ToInt32(txtVehiclePrice.Text);
            int financialYearSelected = Convert.ToInt32(drpFinanceYear.SelectedValue);
            //validations
            Boolean validateVehiclePriceIsNotZeroResult = validateVehiclePriceIsNotZero(vehiclePrice);
            Boolean validateMinimumDepositResult = validateMinimumDeposit(deposit, vehiclePrice);
            validateDeliveryDateSelection(deliveryDate);
            deliveryDate = calendarDeliveryDate.SelectedDate;

            if (validateVehiclePriceIsNotZeroResult == true && validateMinimumDepositResult == true && deliveryDate >= DateTime.Today)
            {
                lblVehiclePriceIsNotValid.Text = "";
                lblMinDepositError.Text = "";
                lblDeliveryDateError.Text = "";

                decimal emiForEachMonth = calculateAmountForEachMonth(deposit, vehiclePrice, financialYearSelected);
                DrawGrid drawGrid = new DrawGrid(deliveryDate, drpFinanceYear, grdSummary, emiForEachMonth);
                drawGrid.designGrid();
            }
        }

        
        private void validateDeliveryDateSelection(DateTime deliveryDate)
        {
            if (deliveryDate.Year == 1 && deliveryDate.Month == 1 && deliveryDate.Day == 1)
            { lblDeliveryDateError.Text = "Please select delivery date (date must not be in the past)"; }
        }

        public Boolean validateVehiclePriceIsNotZero(int vehiclePrice)
        {
          if(vehiclePrice == 0)
            {
                lblVehiclePriceIsNotValid.Text = "Please enter valid vehicle price";
                return false;
            }          
            return true;
        }

        public Boolean validateMinimumDeposit(int deposit, int vehiclePrice)
        {
            //check for minimum deposit
            int minDeposit = (vehiclePrice * 15) / 100;
            if (deposit < minDeposit)
            {
                if (lblMinDepositError != null)
                {
                    lblMinDepositError.Text = "Minimum Deposit should be atleast 15% of Vehicle Price";
                }
                return false;
            }            
            return true;
        }

        public decimal calculateAmountForEachMonth(int deposit, int vehiclePrice, int financialYearSelected)
        {
            //Calculate amount due for every month

            decimal remainingAmount = vehiclePrice - deposit;
            decimal emiForEachMonth = 0;

            switch (financialYearSelected)
            {
                case 1:
                    emiForEachMonth = remainingAmount / 12;
                    break;
                case 2:
                    emiForEachMonth = remainingAmount / 24;
                    break;
                case 3:
                    emiForEachMonth = remainingAmount / 36;
                    break;
            }
            return emiForEachMonth;
        }

        protected void calendarDeliveryDate_SelectionChanged(object sender, EventArgs e)
        {
            deliveryDate = calendarDeliveryDate.SelectedDate;
        }
    }
}