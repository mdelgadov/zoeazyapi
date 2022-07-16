using System.ComponentModel.DataAnnotations.Schema;

namespace ZoEazy.Api.Model
{
    [ComplexType]
    public class HumanName : IHumanName
    {
        public HumanName(string first, string middle, string last)
        {
            First = first;
            Last = last;
            Middle = middle;

        }
        public string First { get; set; }
        public string Middle { get; set; }
        public string Last { get; set; }
        [NotMapped]
        public string MiddleInitial
        {
            get { return Middle.Substring(0, 1); }
            set
            {
                if (Middle.Length > 0)
                {
                    Middle = value;
                }
            }
        }
        public string Full { get { return First + " " + Last; } }
        public string FullWithMiddleInitial { get { return First + " " + MiddleInitial + " " + Last; } }
        public string FullWithMiddleName { get { return First + " " + Middle + " " + Last; } }
        public string FullLastFirst{ get { return Last  + " " +  First; } }
        public string FullLastFirstWithMiddleInitial { get { return Last  + " " + MiddleInitial + " " + First; } }
        public string FullLastFirstWithMiddleName { get { return Last + " " + Middle + " " + First; } }
    }
}


