using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERGenerator.Samples
{
    public  class Branch : EntityBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 支店名
        /// </summary>
        public string Name { get; set; }
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
