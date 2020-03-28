using pfcls;

namespace MPExport.MPObjects
{
    public class InertiaTensorCordSys : InertiaTensor
    {
        public InertiaTensorCordSys(IpfcMassProperty massProps) : base(massProps)
        {
            Ixx = massProps.CoordSysInertiaTensor[0, 0];
            Ixy = massProps.CoordSysInertiaTensor[0, 1];
            Ixz = massProps.CoordSysInertiaTensor[0, 2];

            Iyx = massProps.CoordSysInertiaTensor[1, 0];
            Iyy = massProps.CoordSysInertiaTensor[1, 1];
            Iyz = massProps.CoordSysInertiaTensor[1, 2];

            Izx = massProps.CoordSysInertiaTensor[2, 0];
            Izy = massProps.CoordSysInertiaTensor[2, 1];
            Izz = massProps.CoordSysInertiaTensor[2, 2];
        }
    }
}
