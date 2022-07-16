using System.ComponentModel.DataAnnotations;

namespace ZoEazy.Api.Model
{
    public abstract class Fax : Delete, IMetaPhone
    {
        public string Number { get; set; }
        public bool AndPhone { get; set; }
    }

}
