using pfcls;

namespace MPExport.MPObjects
{
    public class GravityCenter
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        public double Z { get; private set; }

        public GravityCenter(IpfcMassProperty massProps)
        {
            X = massProps.GravityCenter[0];
            Y = massProps.GravityCenter[1];
            Z = massProps.GravityCenter[2];
        }
    }
}
