﻿using System.ComponentModel.DataAnnotations;

namespace ERGenerator.Samples
{
    /// <summary>
    /// 会社情報
    /// </summary>
    public class Company : EntityBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 会社名
        /// </summary>
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