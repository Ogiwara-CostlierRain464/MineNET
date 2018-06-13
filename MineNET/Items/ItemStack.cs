using MineNET.Blocks;
using MineNET.NBT.Tags;
using System;

namespace MineNET.Items
{
    public class ItemStack : ICloneable<ItemStack>
    {
        public Item Item { get; }
        public int Damage { get; set; }
        public int Count { get; set; }

        public CompoundTag Tags { get; set; } = null;
        public byte[] BinaryTags { get; } = null;

        public string[] CanPlaceOn { get; private set; } = new string[0];
        public string[] CanDestroy { get; private set; } = new string[0];

        //NBT

        public ItemStack(Item item)
        {
            this.Item = item;
            this.Damage = item.Damage;
            this.Count = 1;
        }

        public ItemStack(Item item, int damage)
        {
            this.Item = item;
            this.Damage = damage;
            this.Count = 1;
        }

        public ItemStack(Item item, int damage, int count)
        {
            this.Item = item;
            this.Damage = damage;
            this.Count = count;
        }

        //NBT

        public ItemStack(Block block)
        {
            this.Item = new ItemBlock(block);
            this.Damage = block.Damage;
            this.Count = 1;
        }

        public ItemStack(Block block, int damage)
        {
            this.Item = new ItemBlock(block);
            this.Damage = damage;
            this.Count = 1;
        }

        public ItemStack(Block block, int damage, int count)
        {
            this.Item = new ItemBlock(block);
            this.Damage = damage;
            this.Count = count;
        }

        public ItemStack Clone()
        {
            return (ItemStack) this.MemberwiseClone();
        }

        object ICloneable.Clone()
        {
            return this.MemberwiseClone();
        }

        //NBT
    }
}
