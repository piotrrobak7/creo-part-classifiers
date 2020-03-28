using pfcls;

namespace MPExport.MPObjects
{
    public abstract class InertiaTensor
    {
        public double Ixx { get; protected set; }
        public double Ixy { get; protected set; }
        public double Ixz { get; protected set; }

        public double Iyx { get; protected set; }
        public double Iyy { get; protected set; }
        public double Iyz { get; protected set; }

        public double Izx { get; protected set; }
        public double Izy { get; protected set; }
        public double Izz { get; protected set; }

        public InertiaTensor(IpfcMassProperty massProps) { }
    }
}
