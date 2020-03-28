using pfcls;

namespace MPExport.MPObjects
{
    public class MPData
    {
        public string PartNo { get; private set; }

        public double Mass { get; private set; }
        public double Volume { get; private set; }
        public double Density { get; private set; }
        public double SurfaceArea { get; private set; }

        public GravityCenter GravityCenter { get; private set; }

        public InertiaCordSys InertiaCordSys { get; private set; }
        public InertiaTensorCordSys InertiaTensorCordSys { get; private set; }
        public InertiaTensorGravityCenter InertiaTensorGravityCenter { get; private set; }

        public PrincipalMoments PrincipalMoments { get; private set; }
        public PrincipalAxes PrincipalAxes { get; private set; }

        public MPData(string partNo, IpfcMassProperty massProps)
        {
            PartNo = partNo;

            Mass = massProps.Mass;
            Volume = massProps.Volume;
            Density = massProps.Density;
            SurfaceArea = massProps.SurfaceArea;

            GravityCenter = new GravityCenter(massProps);

            InertiaCordSys = new InertiaCordSys(massProps);
            InertiaTensorCordSys = new InertiaTensorCordSys(massProps);
            InertiaTensorGravityCenter = new InertiaTensorGravityCenter(massProps);

            PrincipalMoments = new PrincipalMoments(massProps);
            PrincipalAxes = new PrincipalAxes(massProps);
        }
    }
}
