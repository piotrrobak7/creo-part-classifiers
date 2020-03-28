using pfcls;

namespace MPExport.MPObjects
{
    public class PrincipalMoments
    {
        public double I1 { get; private set; }
        public double I2 { get; private set; }
        public double I3 { get; private set; }

        public PrincipalMoments(IpfcMassProperty massProps)
        {
            I1 = massProps.GravityCenter[0];
            I2 = massProps.GravityCenter[1];
            I3 = massProps.GravityCenter[2];
        }
    }
}
