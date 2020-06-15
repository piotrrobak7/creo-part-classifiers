using pfcls;

namespace MPExport.MPObjects
{
    class PrincipalAxes
    {
        public double X1 { get; }
        public double Y1 { get; }
        public double Z1 { get; }

        public double X2 { get; }
        public double Y2 { get; }
        public double Z2 { get; }

        public double X3 { get; }
        public double Y3 { get; }
        public double Z3 { get; }

        public PrincipalAxes(IpfcMassProperty massProps)
        {
            X1 = massProps.PrincipalAxes[0][0];
            Y1 = massProps.PrincipalAxes[0][1];
            Z1 = massProps.PrincipalAxes[0][2];

            Y2 = massProps.PrincipalAxes[1][1];
            X2 = massProps.PrincipalAxes[1][0];
            Z2 = massProps.PrincipalAxes[1][2];

            Y3 = massProps.PrincipalAxes[2][0];
            X3 = massProps.PrincipalAxes[2][1];
            Z3 = massProps.PrincipalAxes[2][2];
        }
    }
}
