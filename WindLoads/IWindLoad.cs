namespace WindLoads
{
    public interface IWindLoad
    {
        void CalculateWindLoad(double heightForCalculations, bool windAlongTheLength);
    }
}