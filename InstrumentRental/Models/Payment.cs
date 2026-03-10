using System;

namespace InstrumentRental.Models
{
    public class Payment
    {
        public int PaymentID { get; set; }
        public int RentalID { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }
        public int ReceivedBy { get; set; }

        // Навигационные свойства
        public string ClientName { get; set; }
        public string InstrumentName { get; set; }
        public string ReceivedByName { get; set; }

        // Отображение метода оплаты на русском
        public string PaymentMethodDisplay
        {
            get
            {
                switch (PaymentMethod)
                {
                    case "Cash": return "Наличные";
                    case "Card": return "Карта";
                    case "Transfer": return "Перевод";
                    default: return PaymentMethod;
                }
            }
        }
    }
}