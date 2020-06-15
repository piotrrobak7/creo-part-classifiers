using pfcls;

namespace MPExport.MPObjects
{
    class MPData
    {
        public string PartNo { get; }

        public double Mass { get; }
        public double Volume { get; }
        public double Density { get; }
        public double SurfaceArea { get; }

        public GravityCenter GravityCenter { get; }

        public InertiaCordSys InertiaCordSys { get; }
        public InertiaTensorCordSys InertiaTensorCordSys { get; }
        public InertiaTensorGravityCenter InertiaTensorGravityCenter { get; }

        public PrincipalMoments PrincipalMoments { get; }
        public PrincipalAxes PrincipalAxes { get; }

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
