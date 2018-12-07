﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamStatica.Nodes.Interfaces
{
    public interface INumeration
    {
         short MovementNumber { get;  }
         short LeftRotationNumber { get;  }
         short RightRotationNumber { get; }

        void SetDisplacementNumeration(ref short currentCounter);
         void SetReactionNumeration(ref short currentCounter);
    }
}
