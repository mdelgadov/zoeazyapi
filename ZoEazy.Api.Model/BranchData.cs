namespace ZoEazy.Api.Model
{
    public class BranchData
    {
       
        public BranchData()
        {
        }

        public BranchData(string branch)
        {
            Branch = branch;
        }

        public string Branch { get; set; }

    }

    public class SchedulesData
    {

        public SchedulesData()
        {
        }

        public SchedulesData(string schedules)
        {
            Schedules = schedules;
        }

        public string Schedules { get; set; }

    }
    public class ContractData {
        public ContractData(string order, string creditCard, string contract) {
            Order = order;
            CreditCard = creditCard;
            Contract = contract;
        }

        public string Order { get; set; }
        public string CreditCard { get; set; }
        public string Contract { get; set; }
    }
}