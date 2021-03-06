﻿using MineNET.Inventories;
using MineNET.NBT.Data;
using MineNET.NBT.IO;
using MineNET.NBT.Tags;
using MineNET.Values;

namespace MineNET.BlockEntities
{
    public class BlockEntityChest : BlockEntity, InventoryHolder
    {
        Inventory InventoryHolder.Inventory
        {
            get
            {
                return this.Inventory;
            }
        }

        public ChestInventory Inventory { get; protected set; }

        public BlockEntityChest(Position position, CompoundTag nbt = null) : base(position, nbt)
        {
            this.Inventory = new ChestInventory(this);

            if (!this.NamedTag.Exist("items"))
            {
                this.NamedTag.PutList(new ListTag("items", NBTTagType.COMPOUND));
            }

            ListTag items = this.NamedTag.GetList("items");
            for (int i = 0; i < items.Count; ++i)
            {
                this.Inventory.SetItem(i, NBTIO.ReadItem((CompoundTag) items[i]));
            }
        }

        public override string Name
        {
            get
            {
                return "Chest";
            }
        }
    }
}
