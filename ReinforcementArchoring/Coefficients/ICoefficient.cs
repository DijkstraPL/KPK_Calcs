namespace ReinforcementArchoring.Coefficients
{
    public interface ICoefficient
    {
        double Coefficient { get; }
        void Calculate();
    }
}
