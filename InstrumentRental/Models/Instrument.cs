using System;

namespace InstrumentRental.Models
{
    public class Instrument
    {
        public int InstrumentID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal RentalPricePerDay { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }

        // Отображение статуса на русском
        public string StatusDisplay
        {
            get
            {
                switch (Status)
                {
                    case "Available": return "В наличии";
                    case "Rented": return "Арендован";
                    case "UnderRepair": return "На ремонте";
                    default: return Status;
                }
            }
        }

        // Полное название инструмента
        public string FullName => $"{Brand} {Name} {Model}".Trim();
    }
}