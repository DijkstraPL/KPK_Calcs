namespace Build_IT_BeamStatica.Nodes.Interfaces
{
    public interface INumeration
    {
         short HorizontalMovementNumber { get;  }
         short VerticalMovementNumber { get;  }
         short LeftRotationNumber { get;  }
         short RightRotationNumber { get; }

        void SetDisplacementNumeration(ref short currentCounter);
         void SetReactionNumeration(ref short currentCounter);
    }
}
