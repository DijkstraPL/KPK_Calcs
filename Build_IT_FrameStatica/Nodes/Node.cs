﻿using Build_IT_FrameStatica.Coords;
using Build_IT_FrameStatica.Loads.Interfaces;
using Build_IT_FrameStatica.Nodes.Interfaces;
using Build_IT_FrameStatica.Results.Interfaces;
using System;
using System.Collections.Generic;

namespace Build_IT_FrameStatica.Nodes
{
    internal abstract class Node : INode
    {
        #region Properties

        public Point Position { get; protected set; }

        public short HorizontalMovementNumber { get; protected set; }
        public short VerticalMovementNumber { get; protected set; }
        public short LeftRotationNumber { get; protected set; }
        public short RightRotationNumber { get; protected set; }

        public abstract short DegreesOfFreedom { get; }

        public ICollection<INodeLoad> ConcentratedForces { get; set; } = new List<INodeLoad>();

        public IResultValue NormalForce { get; protected set; } = null;
        public IResultValue ShearForce { get; protected set; } = null;
        public IResultValue BendingMoment { get; protected set; } = null;

        public IResultValue HorizontalDeflection { get; protected set; } = null;
        public IResultValue VerticalDeflection { get; protected set; } = null;
        public IResultValue LeftRotation { get; protected set; } = null;
        public IResultValue RightRotation { get; protected set; } = null;

        #endregion // Properties

        #region Constructors

        public Node(Point position)
        {
            Position = position;
        }

        #endregion // Constructors

        #region Public_Methods

        public abstract void SetDisplacementNumeration(ref short currentCounter);
        public abstract void SetReactionNumeration(ref short currentCounter);

        #endregion // Public_Methods
    }
}
