using pfcls;

namespace MPExport.MPObjects
{
    class PrincipalMoments
    {
        public double I1 { get; }
        public double I2 { get; }
        public double I3 { get; }

        public PrincipalMoments(IpfcMassProperty massProps)
        {
            I1 = massProps.GravityCenter[0];
            I2 = massProps.GravityCenter[1];
            I3 = massProps.GravityCenter[2];
        }
    }
}
