﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MineNET.Blocks;
using MineNET.Entities.Data;
using MineNET.Entities.Players;
using MineNET.Network.Packets;
using MineNET.Utils;
using MineNET.Values;
using MineNET.Worlds.Formats.WorldSaveFormats;

namespace MineNET.Worlds
{
    public class World
    {
        public Dictionary<Tuple<int, int>, Chunk> chunks = new Dictionary<Tuple<int, int>, Chunk>();

        public static void CreateWorld(string worldName)
        {
            World.CreateWorld(worldName, new RegionWorldSaveFormat(worldName));
        }

        public static void CreateWorld(string worldName, IWorldSaveFormat format)
        {
            World world = new World();
            world.Format = format;

            world.Name = worldName;
            world.Format.WorldData.Create(world);
            world.Format.WorldData.Save(world);

            Server.Instance.worlds.Add(worldName, world);
        }

        public static void LoadWorld(string worldName)
        {
            World.LoadWorld(worldName, new RegionWorldSaveFormat(worldName));
        }

        public static void LoadWorld(string worldName, IWorldSaveFormat format)
        {
            if (World.Exists(worldName))
            {
                World world = new World();
                world.Format = format;
                world.Name = worldName;
                world.Format.WorldData.Load(world);

                Server.Instance.worlds.Add(worldName, world);
            }
            else
            {
                CreateWorld(worldName);
            }
        }

        public static World GetWorld(string worldName)
        {
            if (World.Exists(worldName))
            {
                if (World.LoadedWorld(worldName))
                {
                    return Server.Instance.worlds[worldName];
                }
            }

            return null;
        }

        public static World GetMainWorld()
        {
            return Server.Instance.worlds[Server.ServerConfig.MainWorldName];
        }

        public static bool LoadedWorld(string worldName)
        {
            if (Server.Instance.worlds.ContainsKey(worldName))
            {
                return true;
            }

            return false;
        }

        public static bool Exists(string worldName)
        {
            if (Directory.Exists($"{Server.ExecutePath}\\worlds\\{worldName}"))
            {
                if (File.Exists($"{Server.ExecutePath}\\worlds\\{worldName}\\level.dat"))
                {
                    return true;
                }
            }

            return false;
        }

        public IWorldSaveFormat Format { get; set; }
        public string Name { get; private set; }

        public Vector3 SpawnPoint { get; set; } = new Vector3(128f, 6f, 128f);

        public GameMode DefaultGameMode { get; set; } = GameMode.Survival;
        public int Difficulty { get; set; } = 1;

        public Block GetBlock(Vector3 pos)
        {
            Tuple<int, int> chunkPos = new Tuple<int, int>((int) pos.X >> 4, (int) pos.Z >> 4);
            Chunk chunk = null;
            if (this.chunks.ContainsKey(chunkPos))
            {
                chunk = this.chunks[chunkPos];
            }
            else
            {
                throw new Exception();
            }

            byte id = chunk.GetBlock((int) pos.X, (int) pos.Y, (int) pos.Z);
            byte meta = chunk.GetMetadata((int) pos.X, (int) pos.Y, (int) pos.Z);

            return Block.Get(id, meta);
        }

        public void SetBlock(Vector3 pos, Block block)
        {
            Tuple<int, int> chunkPos = new Tuple<int, int>((int) pos.X >> 4, (int) pos.Z >> 4);
            Chunk chunk = null;
            if (this.chunks.ContainsKey(chunkPos))
            {
                chunk = this.chunks[chunkPos];
            }
            else
            {
                throw new Exception();
            }

            chunk.SetBlock((int) pos.X, (int) pos.Y, (int) pos.Z, (byte) block.ID);
            chunk.SetMetadata((int) pos.X, (int) pos.Y, (int) pos.Z, (byte) block.Damage);

            this.SendBlocks(Server.Instance.GetPlayers(), new Vector3[] { pos });
        }

        public IEnumerable<Chunk> LoadChunks(Vector2 chunkXZ, int radius)
        {
            lock (this.chunks)
            {
                Dictionary<Tuple<int, int>, double> newOrders = new Dictionary<Tuple<int, int>, double>();

                double radiusSquared = Math.Pow(radius, 2);
                Vector2 center = chunkXZ;

                for (int x = -radius; x <= radius; ++x)
                {
                    for (int z = -radius; z <= radius; ++z)
                    {
                        int distance = (x * x) + (z * z);
                        if (distance > radiusSquared)
                        {
                            continue;
                        }
                        int chunkX = (int) (x + center.X);
                        int chunkZ = (int) (z + center.Y);
                        Tuple<int, int> index = new Tuple<int, int>(chunkX, chunkZ);
                        newOrders[index] = distance;
                    }
                }

                foreach (Tuple<int, int> chunkKey in this.chunks.Keys.ToArray())
                {
                    if (!newOrders.ContainsKey(chunkKey))
                    {
                        //this.Format.SetChunk(chunks[chunkKey]);//TODO:
                        this.chunks.Remove(chunkKey);
                    }
                }

                foreach (var pair in newOrders.OrderBy(pair => pair.Value))
                {
                    if (this.chunks.ContainsKey(pair.Key)) continue;

                    Chunk chunk = null;
                    try
                    {
                        chunk = this.Format.GetChunk(pair.Key.Item1, pair.Key.Item2);
                        this.chunks.Add(pair.Key, chunk);
                    }
                    catch (Exception e)
                    {
                        Logger.Error(e);
                    }

                    yield return chunk;
                }
            }
        }

        public void SendBlocks(Player[] players, Vector3[] vector3, int flags = UpdateBlockPacket.FLAG_NONE)
        {
            for (int i = 0; i < vector3.Length; ++i)
            {
                Block block = this.GetBlock(vector3[i]);
                UpdateBlockPacket pk = new UpdateBlockPacket();
                pk.Vector3 = vector3[i].ToVector3i();
                pk.BlockId = block.ID;
                pk.BlockData = block.Damage;
                pk.Flags = flags;
                for (int j = 0; j < players.Length; ++j)
                {
                    players[j].SendPacket(pk);
                }
            }
        }
    }
}
