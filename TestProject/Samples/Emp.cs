using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestProject.Samples
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
        /// 会社コード
        public string ComapyId { get; set; }
    }
}
