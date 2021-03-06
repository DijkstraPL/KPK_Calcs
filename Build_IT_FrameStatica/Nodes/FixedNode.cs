﻿using Build_IT_FrameStatica.Coords;
using Build_IT_FrameStatica.Results.Interfaces;
using Build_IT_FrameStatica.Results.Reactions;

namespace Build_IT_FrameStatica.Nodes
{
    internal class FixedNode : Node
    {
        #region Properties

        public override short DegreesOfFreedom => 0;

        #endregion // Properties

        #region Constructors

        public FixedNode(
            Point position,
            IResultValue normalForce = null,
            IResultValue shearForce = null,
            IResultValue bendingMoment = null)
            : base(position)
        {
            NormalForce = normalForce ?? new NormalForce();
            ShearForce = shearForce ?? new ShearForce();
            BendingMoment = bendingMoment ?? new BendingMoment();
        }

        #endregion // Constructors

        #region Public_Methods

        public override void SetDisplacementNumeration(ref short currentCounter)
        {
        }

        public override void SetReactionNumeration(ref short currentCounter)
        {
            HorizontalMovementNumber = currentCounter++;
            VerticalMovementNumber = currentCounter++;
            LeftRotationNumber = currentCounter++;
            RightRotationNumber = LeftRotationNumber;
        }

        #endregion // Public_Methods
    }
}
