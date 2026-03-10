using System;

namespace InstrumentRental.Models
{
    public class Rental
    {
        public int RentalID { get; set; }
        public int ClientID { get; set; }
        public int InstrumentID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? ActualReturnDate { get; set; }
        public decimal DepositAmount { get; set; }
        public decimal TotalCost { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }

        // Навигационные свойства (заполняются из JOIN)
        public string ClientName { get; set; }
        public string InstrumentName { get; set; }

        // Отображение статуса на русском
        public string StatusDisplay
        {
            get
            {
                switch (Status)
                {
                    case "Active": return "Активна";
                    case "Completed": return "Завершена";
                    case "Overdue": return "Просрочена";
                    default: return Status;
                }
            }
        }

        // Количество дней аренды
        public int DaysCount
        {
            get
            {
                DateTime end = ActualReturnDate ?? EndDate;
                return (int)(end - StartDate).TotalDays + 1;
            }
        }

        // Фактическая стоимость (если есть возврат)
        public decimal ActualCost { get; set; }

        // Остаток долга
        public decimal Debt { get; set; }
    }
}