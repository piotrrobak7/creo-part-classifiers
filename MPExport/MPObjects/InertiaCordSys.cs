using pfcls;

namespace MPExport.MPObjects
{
    public class InertiaCordSys : InertiaTensor
    {
        public InertiaCordSys(IpfcMassProperty massProps) : base(massProps)
        {
            Ixx = massProps.CoordSysInertia[0, 0];
            Ixy = massProps.CoordSysInertia[0, 1];
            Ixz = massProps.CoordSysInertia[0, 2];

            Iyx = massProps.CoordSysInertia[1, 0];
            Iyy = massProps.CoordSysInertia[1, 1];
            Iyz = massProps.CoordSysInertia[1, 2];

            Izx = massProps.CoordSysInertia[2, 0];
            Izy = massProps.CoordSysInertia[2, 1];
            Izz = massProps.CoordSysInertia[2, 2];
        }
    }
}
