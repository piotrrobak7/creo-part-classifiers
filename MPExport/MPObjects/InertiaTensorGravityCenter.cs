using pfcls;

namespace MPExport.MPObjects
{
    class InertiaTensorGravityCenter : InertiaTensor
    {
        public InertiaTensorGravityCenter(IpfcMassProperty massProps) : base(massProps)
        {
            Ixx = massProps.CenterGravityInertiaTensor[0, 0];
            Ixy = massProps.CenterGravityInertiaTensor[0, 1];
            Ixz = massProps.CenterGravityInertiaTensor[0, 2];

            Iyx = massProps.CenterGravityInertiaTensor[1, 0];
            Iyy = massProps.CenterGravityInertiaTensor[1, 1];
            Iyz = massProps.CenterGravityInertiaTensor[1, 2];

            Izx = massProps.CenterGravityInertiaTensor[2, 0];
            Izy = massProps.CenterGravityInertiaTensor[2, 1];
            Izz = massProps.CenterGravityInertiaTensor[2, 2];
        }
    }
}
