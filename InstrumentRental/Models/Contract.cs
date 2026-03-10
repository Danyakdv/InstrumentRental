using System;

namespace InstrumentRental.Models
{
    public class Contract
    {
        public int ContractID { get; set; }
        public int RentalID { get; set; }
        public string ContractNumber { get; set; }
        public DateTime ContractDate { get; set; }
        public string ContractText { get; set; }

        // Навигационные свойства
        public string ClientName { get; set; }
        public string InstrumentName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalCost { get; set; }
    }
}