﻿using Build_IT_BeamStatica.Results.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Build_IT_BeamStatica.Results.Displacements
{
    public class Rotation : Displacement
    {
        public Rotation(double? position = null) : base(position)
        {
        }
    }
}