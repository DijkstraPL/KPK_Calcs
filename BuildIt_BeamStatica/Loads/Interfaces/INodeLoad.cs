namespace Build_IT_BeamStatica.Loads.Interfaces
{
    public interface INodeLoad : ILoad
    {
        bool IncludeInSpanLoadCalculations { get; }

        double CalculateNormalForce();
        double CalculateShear();
        double CalculateBendingMoment(double distanceFromLoad);

        double CalculateHorizontalDisplacement();
        double CalculateVerticalDisplacement();
        double CalculateRotationDisplacement();

        double CalculateJointLoadVectorNormalForceMember();
        double CalculateJointLoadVectorShearMember();
        double CalculateJointLoadVectorBendingMomentMember();
    }
}
