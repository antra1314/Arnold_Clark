using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArnoldClark
{
    public class DateUtility
    {
        public static DateTime getFirstMondayOfMonthAndYear(int Month, int Year)
        {

            DateTime dt;
            DateTime.TryParse(String.Format("{0}/{1}/1", Year, Month), out dt);
            for (int i = 0; i < 7; i++)
            {
                if (dt.DayOfWeek == DayOfWeek.Monday)
                {
                    return dt;
                }
                else
                {
                    dt = dt.AddDays(1);
                }
            }
            // If get to here, show
            return DateTime.Now;
        }

        public static (int year, int month) ifYearChangeGetUpdatedYear(int totalMonths, int currentYear, int month2)
        {
            if ((totalMonths - 1) % 12 == 0)
            {
                currentYear = currentYear + 1;
                month2 = 1;

            }
            return (currentYear, month2);

        }

        public static void calculateDueDate(out DateTime dueDate, ref int year, ref int month2, int installment, DateTime deliveryDate)
        {
            int month = deliveryDate.Month + installment;
            month2 = month2 + 1;

            var result = DateUtility.ifYearChangeGetUpdatedYear(month, year, month2);
            month2 = result.month;
            year = result.year;

            dueDate = DateUtility.getFirstMondayOfMonthAndYear(month2, year);
        }
    }

}