namespace ReinforcementAnchoring.Interfaces
{
    public interface ICoefficient
    {
        double Coefficient { get; }
        void Calculate();
    }
}
