using pfcls;

namespace MPExport.MPObjects
{
    class GravityCenter
    {
        public double X { get; }
        public double Y { get; }
        public double Z { get; }

        public GravityCenter(IpfcMassProperty massProps)
        {
            X = massProps.GravityCenter[0];
            Y = massProps.GravityCenter[1];
            Z = massProps.GravityCenter[2];
        }
    }
}
