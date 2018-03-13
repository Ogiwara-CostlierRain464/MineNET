﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MineNET.NBT.Tags;
using MineNET.Utils;

namespace MineNET.NBT.IO.Tests
{
    [TestClass()]
    public class NBTIOTests
    {
        [TestMethod()]
        public void WriteRawFileTest()
        {
            ListTag<IntTag> list = new ListTag<IntTag>("list");
            list.Add(new IntTag(12345));
            list.Add(new IntTag(67890));
            CompoundTag subTag = new CompoundTag();
            subTag.PutBool("bool", true);
            subTag.PutByte("byte", 123);
            CompoundTag tag = new CompoundTag();
            tag.PutBool("bool", true);
            tag.PutByte("byte", 123);
            tag.PutByteArray("byteArray", ArrayUtils.CreateArray<byte>(200));
            tag.PutShort("short", 12345);
            tag.PutInt("int", 12345678);
            //tag.PutIntArray("intArray", ArrayUtils.CreateArray<int>(200));
            tag.PutLong("long", 123456789123456);
            //tag.PutLongArray("longArray", ArrayUtils.CreateArray<long>(200));
            tag.PutFloat("float", 12.3456f);
            tag.PutDouble("double", 12.3456789);
            //tag.PutList(list);
            tag.PutCompound("com", subTag);
            NBTIO.WriteRawFile(Environment.CurrentDirectory + "\\test.nbt", tag);
        }

        [TestMethod()]
        public void ReadRawFileTest()
        {
            CompoundTag tag = NBTIO.ReadRawFile(Environment.CurrentDirectory + "\\test.nbt");
            Console.WriteLine(tag);
        }
    }
}