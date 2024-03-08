﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAppTv.Models
{

    public class Customer
    {
        public int Id { get; set; }
        public string Serial { get; set; }


        public string Name { get; set; }


        public string Email { get; set; }


        public string Phone { get; set; }
    }
}
