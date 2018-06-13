namespace MineNET.Entities
{
    public abstract class Entity
    {
        private static long nextEntityId = 0;

        public abstract string Name { get; protected set; }

        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public float Yaw { get; set; }
        public float Pitch { get; set; }

        public float HeadYaw { get; set; }

        public float MotionX { get; set; }
        public float MotionY { get; set; }
        public float MotionZ { get; set; }

        public long EntityID { get; }

        public virtual bool IsPlayer { get { return false; } }
        public virtual bool Closed { get; protected set; }

        public Entity()
        {
            this.EntityID = ++Entity.nextEntityId;
        }
    }
}
