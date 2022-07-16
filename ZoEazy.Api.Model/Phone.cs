using System.ComponentModel.DataAnnotations;

namespace ZoEazy.Api.Model
{
    public abstract class Phone : Delete, IPhone {
        

        public string Number { get; set; }
        public Phone() 
        {
            IsCell = false;
            Sms = false;
            AndFax = false;
        }

        public int? Extension { get; set; }
        public bool IsCell { get; set; }
        public bool Sms { get; set; }
        public string Memo { get; set; }
        public bool AndFax { get; set; }
        
    }
}