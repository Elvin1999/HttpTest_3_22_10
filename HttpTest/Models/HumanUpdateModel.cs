﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpTest.Models
{
    public class HumanUpdateModel
    {
        public string? Name { get; set; }
        public string? Job { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
