using System.ComponentModel.DataAnnotations;

namespace TestProject.Samples
{
    /// <summary>
    /// Company Info
    /// </summary>
    public class Company : EntityBase
    {
        [Key]
        /// Id
        public int Id { get; set; }
        /// 会社名
        public string　Name { get; set; }
        /// <summary>
        /// 住所
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// TEL
        /// </summary>
        public string Tel { get; set; }
    }
}