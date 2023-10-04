using System.ComponentModel.DataAnnotations;

namespace ERGenerator.Samples
{
    /// <summary>
    /// Company Info
    /// </summary>
    public class Company : EntityBase
    {
        [Key]
        /// Id
        public int Id { get; set; }
        /// Company Name
        public string　Name { get; set; }
        /// <summary>
        /// Company Address
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// TEL
        /// </summary>
        public string Tel { get; set; }
    }
}