using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERGenerator.Samples
{
    /// <summary>
    /// Employee Info
    /// </summary>
    internal class Emp : EntityBase
    {
        [Key]
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        /// 姓
        public string LastName { get; set; }
        /// 名
        public string FirstName { get; set; }
        /// Company Id
        public string ComapyId { get; set; }
    }
}
