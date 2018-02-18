﻿using System;

namespace MineNET.NBT.Tags
{
    public class LongArrayTag : ArrayDataTag<long>
    {
        public override NBTTagType TagType
        {
            get
            {
                return NBTTagType.LONG_ARRAY;
            }
        }

        public LongArrayTag(long[] data) : this("", data)
        {

        }

        public LongArrayTag(string name, long[] data) : base(name, data)
        {

        }

        public override string ToString()
        {
            return $"ByteArrayTag : Name {this.Name}  : Data {this.Data}";
        }

        internal override void Write(NBTStream stream)
        {
            throw new NotImplementedException();
        }

        internal override void WriteTag(NBTStream stream)
        {
            throw new NotImplementedException();
        }

        internal override void Read(NBTStream stream)
        {
            throw new NotImplementedException();
        }

        internal override void ReadTag(NBTStream stream)
        {
            throw new NotImplementedException();
        }
    }
}