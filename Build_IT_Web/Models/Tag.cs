﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Build_IT_Web.Models
{
    [Table("Tags")]
    public class Tag
    {
        public long Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}