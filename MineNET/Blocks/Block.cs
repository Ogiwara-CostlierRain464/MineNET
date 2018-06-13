using System;

namespace MineNET.Blocks
{
    public class Block : ICloneable<Block>
    {
        public int ID { get; }
        public int Damage { get; set; }

        public Block(int id)
        {
            this.ID = id;
        }

        public virtual string Name
        {
            get
            {
                return "Unknown";
            }
        }

        public Block Clone()
        {
            return (Block) this.MemberwiseClone();
        }

        object ICloneable.Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
