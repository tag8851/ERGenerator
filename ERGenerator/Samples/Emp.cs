using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERGenerator.Samples
{
    /// <summary>
    /// 従業員情報
    /// </summary>
    internal class Emp : EntityBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// 姓
        public string LastName { get; set; }
        /// 名
        public string FirstName { get; set; }
        /// 性別
        public string Sex { get; set; }
        /// 会社ID
        public string ComapyId { get; set; }
    }
}
