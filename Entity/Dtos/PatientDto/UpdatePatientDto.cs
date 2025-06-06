﻿using Entity.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dtos.PatientDto
{
    public class UpdatePatientDto : BaseDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public int DNI { get; set; }
    }
}
