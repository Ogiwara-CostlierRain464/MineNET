﻿
using System;
using System.Collections.Generic;
using MineNET.Blocks;

namespace MineNET.Items
{
    public class ItemFactory
    {
        public const int SEA_PICKLE = -156;
        public const int CARVED_PUMPKIN = -155;
        public const int SPRUCE_PRESSURE_PLATE = -154;
        public const int JUNGLE_PRESSURE_PLATE = -153;
        public const int DARK_OAK_PRESSURE_PLATE = -152;
        public const int BIRCH_PRESSURE_PLATE = -151;
        public const int ACACIA_PRESSURE_PLATE = -150;
        public const int SPRUCE_TRAPDOOR = -149;
        public const int JUNGLE_TRAPDOOR = -148;
        public const int DARK_OAK_TRAPDOOR = -147;
        public const int BIRCH_TRAPDOOR = -146;
        public const int ACACIA_TRAPDOOR = -145;
        public const int SPRUCE_BUTTON = -144;
        public const int JUNGLE_BUTTON = -143;
        public const int DARK_OAK_BUTTON = -142;
        public const int BIRCH_BUTTON = -141;
        public const int ACACIA_BUTTON = -140;
        public const int DRIED_KELP_BLOCK = -139;
        public const int TILE_KELP = -138;
        public const int CORAL_FAN_HANG3 = -137;
        public const int CORAL_FAN_HANG2 = -136;
        public const int CORAL_FAN_HANG = -135;
        public const int CORALFAN_DEAD = -134;
        public const int CORAL_FAN = -133;
        public const int CORAL_BLOCK = -132;
        public const int CORAL = -131;
        public const int SEAGRASS = -130;
        public const int BLUE_ICE = -11;
        public const int STRIPPED_OAK_LOG = -10;
        public const int STRIPPED_DARK_OAK_LOG = -9;
        public const int STRIPPED_ACACIA_LOG = -8;
        public const int STRIPPED_JUNGLE_LOG = -7;
        public const int STRIPPED_BIRCH_LOG = -6;
        public const int STRIPPED_SPRUCE_LOG = -5;
        public const int PRISMARINE_BRICKS_STAIRS = -4;
        public const int DARK_PRISMARINE_STAIRS = -3;
        public const int PRISMARINE_STAIRS = -2;

        public const int IRON_SHOVEL = 256;
        public const int IRON_PICKAXE = 257;
        public const int IRON_AXE = 258;
        public const int FLINT_AND_STEEL = 259;
        public const int APPLE = 260;
        public const int BOW = 261;
        public const int ARROW = 262;
        public const int COAL = 263;
        public const int DIAMOND = 264;
        public const int IRON_INGOT = 265;
        public const int GOLD_INGOT = 266;
        public const int IRON_SWORD = 267;
        public const int WOODEN_SWORD = 268;
        public const int WOODEN_SHOVEL = 269;
        public const int WOODEN_PICKAXE = 270;
        public const int WOODEN_AXE = 271;
        public const int STONE_SWORD = 272;
        public const int STONE_SHOVEL = 273;
        public const int STONE_PICKAXE = 274;
        public const int STONE_AXE = 275;
        public const int DIAMOND_SWORD = 276;
        public const int DIAMOND_SHOVEL = 277;
        public const int DIAMOND_PICKAXE = 278;
        public const int DIAMOND_AXE = 279;
        public const int STICK = 280;
        public const int BOWL = 281;
        public const int MUSHROOM_STEW = 282;
        public const int GOLDEN_SWORD = 283;
        public const int GOLDEN_SHOVEL = 284;
        public const int GOLDEN_PICKAXE = 285;
        public const int GOLDEN_AXE = 286;
        public const int STRING = 287;
        public const int FEATHER = 288;
        public const int GUNPOWDER = 289;
        public const int WOODEN_HOE = 290;
        public const int STONE_HOE = 291;
        public const int IRON_HOE = 292;
        public const int DIAMOND_HOE = 293;
        public const int GOLDEN_HOE = 294;
        public const int WHEAT_SEEDS = 295;
        public const int WHEAT = 296;
        public const int BREAD = 297;
        public const int LEATHER_HELMET = 298;
        public const int LEATHER_CHESTPLATE = 299;
        public const int LEATHER_LEGGINGS = 300;
        public const int LEATHER_BOOTS = 301;
        public const int CHAINMAIL_HELMET = 302;
        public const int CHAINMAIL_CHESTPLATE = 303;
        public const int CHAINMAIL_LEGGINGS = 304;
        public const int CHAINMAIL_BOOTS = 305;
        public const int IRON_HELMET = 306;
        public const int IRON_CHESTPLATE = 307;
        public const int IRON_LEGGINGS = 308;
        public const int IRON_BOOTS = 309;
        public const int DIAMOND_HELMET = 310;
        public const int DIAMOND_CHESTPLATE = 311;
        public const int DIAMOND_LEGGINGS = 312;
        public const int DIAMOND_BOOTS = 313;
        public const int GOLDEN_HELMET = 314;
        public const int GOLDEN_CHESTPLATE = 315;
        public const int GOLDEN_LEGGINGS = 316;
        public const int GOLDEN_BOOTS = 317;
        public const int FLINT = 318;
        public const int PORKCHOP = 319;
        public const int COOKED_PORKCHOP = 320;
        public const int PAINTING = 321;
        public const int GOLDEN_APPLE = 322;
        public const int SIGN = 323;
        public const int WOODEN_DOOR = 324;
        public const int BUCKET = 325;

        public const int MINECART = 328;
        public const int SADDLE = 329;
        public const int IRON_DOOR = 330;
        public const int REDSTONE = 331;
        public const int SNOWBALL = 332;
        public const int BOAT = 333;
        public const int LEATHER = 334;
        public const int KELP = 335;
        public const int BRICK = 336;
        public const int CLAY_BALL = 337;
        public const int REEDS = 338;
        public const int PAPER = 339;
        public const int BOOK = 340;
        public const int SLIME_BALL = 341;
        public const int CHEST_MINECART = 342;

        public const int EGG = 344;
        public const int COMPASS = 345;
        public const int FISHING_ROD = 346;
        public const int CLOCK = 347;
        public const int GLOWSTONE_DUST = 348;
        public const int FISH = 349;
        public const int COOKED_FISH = 350;
        public const int DYE = 351;
        public const int BONE = 352;
        public const int SUGAR = 353;
        public const int CAKE = 354;
        public const int BED = 355;
        public const int REPEATER = 356;
        public const int COOKIE = 357;
        public const int FILLED_MAP = 358;
        public const int SHEARS = 359;
        public const int MELON = 360;
        public const int PUMPKIN_SEEDS = 361;
        public const int MELON_SEEDS = 362;
        public const int BEEF = 363;
        public const int COOKED_BEEF = 364;
        public const int CHICKEN = 365;
        public const int COOKED_CHICKEN = 366;
        public const int ROTTEN_FLESH = 367;
        public const int ENDER_PEARL = 368;
        public const int BLAZE_ROD = 369;
        public const int GHAST_TEAR = 370;
        public const int GOLD_NUGGET = 371;
        public const int NETHER_WART = 372;
        public const int POTION = 373;
        public const int GLASS_BOTTLE = 374;
        public const int SPIDER_EYE = 375;
        public const int FERMENTED_SPIDER_EYE = 376;
        public const int BLAZE_POWDER = 377;
        public const int MAGMA_CREAM = 378;
        public const int BREWING_STAND = 379;
        public const int CAULDRON = 380;
        public const int ENDER_EYE = 381;
        public const int SPECKLED_MELON = 382;
        public const int SPAWN_EGG = 383;
        public const int EXPERIENCE_BOTTLE = 384;
        public const int FIRE_CHARGE = 385;
        public const int WRITABLE_BOOK = 387;
        public const int EMERALD = 388;
        public const int ITEM_FRAME = 389;
        public const int FLOWER_POT = 390;
        public const int CARROT = 391;
        public const int POTATO = 392;
        public const int BAKED_POTATO = 393;
        public const int POISONOUS_POTATO = 394;
        public const int MAP = 395;
        public const int GOLDEN_CARROT = 396;
        public const int SKULL = 397;
        public const int CARROT_ON_A_STICK = 398;
        public const int NETHER_STAR = 399;
        public const int PUMPKIN_PIE = 400;
        public const int FIREWORKS = 401;
        public const int FIREWORK_CHARGE = 402;
        public const int ENCHANTED_BOOK = 403;
        public const int COMPARATOR = 404;
        public const int NETHERBRICK = 405;
        public const int QUARTZ = 406;
        public const int TNT_MINECART = 407;
        public const int HOPPER_MINECART = 408;
        public const int PRISMARINE_SHARD = 409;
        public const int HOPPER = 410;
        public const int RABBIT = 411;
        public const int COOKED_RABBIT = 412;
        public const int RABBIT_STEW = 413;
        public const int RABBIT_FOOT = 414;
        public const int RABBIT_HIDE = 415;
        public const int LEATHER_HORSE_ARMOR = 416;
        public const int IRON_HORSE_ARMOR = 417;
        public const int GOLDEN_HORSE_ARMOR = 418;
        public const int DIAMOND_HORSE_ARMOR = 419;
        public const int LEAD = 420;
        public const int NAME_TAG = 421;
        public const int PRISMARINE_CRYSTALS = 422;
        public const int MUTTON = 423;
        public const int COOKED_MUTTON = 424;
        public const int ARMOR_STAND = 425;
        public const int END_CRYSTAL = 426;
        public const int SPRUCE_DOOR = 427;
        public const int BIRCH_DOOR = 428;
        public const int JUNGLE_DOOR = 429;
        public const int ACACIA_DOOR = 430;
        public const int DARK_OAK_DOOR = 431;
        public const int CHORUS_FRUIT = 432;
        public const int POPPED_CHORUS_FRUIT = 433;

        public const int DRAGON_BREATH = 437;
        public const int SPLASH_POTION = 438;

        public const int LINGERING_POTION = 441;

        public const int COMMAND_BLOCK_MINECART = 443;
        public const int ELYTRA = 444;
        public const int SHULKER_SHELL = 445;
        public const int BANNER = 446;

        public const int TOTEM = 452;

        public const int TRIDENT = 455;

        public const int BEETROOT = 457;
        public const int BEETROOT_SEEDS = 458;
        public const int BEETROOT_SOUP = 459;
        public const int SALMON = 460;
        public const int CLOWNFISH = 461;
        public const int PUFFERFISH = 462;
        public const int COOKED_SALMON = 463;

        public const int APPLEENCHANTED = 466;
        public const int HEART_OF_THE_SEA = 467;

        public const int RECORD_13 = 500;
        public const int RECORD_CAT = 501;
        public const int RECORD_BLOCKS = 502;
        public const int RECORD_CHIRP = 503;
        public const int RECORD_FAR = 504;
        public const int RECORD_MALL = 505;
        public const int RECORD_MELLOHI = 506;
        public const int RECORD_STAL = 507;
        public const int RECORD_STRAD = 508;
        public const int RECORD_WARD = 509;
        public const int RECORD_11 = 510;
        public const int RECORD_WAIT = 511;

        #region Education Edition constant
        public const int ELEMENT_118 = -129;
        public const int ELEMENT_117 = -128;
        public const int ELEMENT_116 = -127;
        public const int ELEMENT_115 = -126;
        public const int ELEMENT_114 = -125;
        public const int ELEMENT_113 = -124;
        public const int ELEMENT_112 = -123;
        public const int ELEMENT_111 = -122;
        public const int ELEMENT_110 = -121;
        public const int ELEMENT_109 = -120;
        public const int ELEMENT_108 = -119;
        public const int ELEMENT_107 = -118;
        public const int ELEMENT_106 = -117;
        public const int ELEMENT_105 = -116;
        public const int ELEMENT_104 = -115;
        public const int ELEMENT_103 = -114;
        public const int ELEMENT_102 = -113;
        public const int ELEMENT_101 = -112;
        public const int ELEMENT_100 = -111;
        public const int ELEMENT_99 = -110;
        public const int ELEMENT_98 = -109;
        public const int ELEMENT_97 = -108;
        public const int ELEMENT_96 = -107;
        public const int ELEMENT_95 = -106;
        public const int ELEMENT_94 = -105;
        public const int ELEMENT_93 = -104;
        public const int ELEMENT_92 = -103;
        public const int ELEMENT_91 = -102;
        public const int ELEMENT_90 = -101;
        public const int ELEMENT_89 = -100;
        public const int ELEMENT_88 = -99;
        public const int ELEMENT_87 = -98;
        public const int ELEMENT_86 = -97;
        public const int ELEMENT_85 = -96;
        public const int ELEMENT_84 = -95;
        public const int ELEMENT_83 = -94;
        public const int ELEMENT_82 = -93;
        public const int ELEMENT_81 = -92;
        public const int ELEMENT_80 = -91;
        public const int ELEMENT_79 = -90;
        public const int ELEMENT_78 = -89;
        public const int ELEMENT_77 = -88;
        public const int ELEMENT_76 = -87;
        public const int ELEMENT_75 = -86;
        public const int ELEMENT_74 = -85;
        public const int ELEMENT_73 = -84;
        public const int ELEMENT_72 = -83;
        public const int ELEMENT_71 = -82;
        public const int ELEMENT_70 = -81;
        public const int ELEMENT_69 = -80;
        public const int ELEMENT_68 = -79;
        public const int ELEMENT_67 = -78;
        public const int ELEMENT_66 = -77;
        public const int ELEMENT_65 = -76;
        public const int ELEMENT_64 = -75;
        public const int ELEMENT_63 = -74;
        public const int ELEMENT_62 = -73;
        public const int ELEMENT_61 = -72;
        public const int ELEMENT_60 = -71;
        public const int ELEMENT_59 = -70;
        public const int ELEMENT_58 = -69;
        public const int ELEMENT_57 = -68;
        public const int ELEMENT_56 = -67;
        public const int ELEMENT_55 = -66;
        public const int ELEMENT_54 = -65;
        public const int ELEMENT_53 = -64;
        public const int ELEMENT_52 = -63;
        public const int ELEMENT_51 = -62;
        public const int ELEMENT_50 = -61;
        public const int ELEMENT_49 = -60;
        public const int ELEMENT_48 = -59;
        public const int ELEMENT_47 = -58;
        public const int ELEMENT_46 = -57;
        public const int ELEMENT_45 = -56;
        public const int ELEMENT_44 = -55;
        public const int ELEMENT_43 = -54;
        public const int ELEMENT_42 = -53;
        public const int ELEMENT_41 = -52;
        public const int ELEMENT_40 = -51;
        public const int ELEMENT_39 = -50;
        public const int ELEMENT_38 = -49;
        public const int ELEMENT_37 = -48;
        public const int ELEMENT_36 = -47;
        public const int ELEMENT_35 = -46;
        public const int ELEMENT_34 = -45;
        public const int ELEMENT_33 = -44;
        public const int ELEMENT_32 = -43;
        public const int ELEMENT_31 = -42;
        public const int ELEMENT_30 = -41;
        public const int ELEMENT_29 = -40;
        public const int ELEMENT_28 = -39;
        public const int ELEMENT_27 = -38;
        public const int ELEMENT_26 = -37;
        public const int ELEMENT_25 = -36;
        public const int ELEMENT_24 = -35;
        public const int ELEMENT_23 = -34;
        public const int ELEMENT_22 = -33;
        public const int ELEMENT_21 = -32;
        public const int ELEMENT_20 = -31;
        public const int ELEMENT_19 = -30;
        public const int ELEMENT_18 = -29;
        public const int ELEMENT_17 = -28;
        public const int ELEMENT_16 = -27;
        public const int ELEMENT_15 = -26;
        public const int ELEMENT_14 = -25;
        public const int ELEMENT_13 = -24;
        public const int ELEMENT_12 = -23;
        public const int ELEMENT_11 = -22;
        public const int ELEMENT_10 = -21;
        public const int ELEMENT_9 = -20;
        public const int ELEMENT_8 = -19;
        public const int ELEMENT_7 = -18;
        public const int ELEMENT_6 = -17;
        public const int ELEMENT_5 = -16;
        public const int ELEMENT_4 = -15;
        public const int ELEMENT_3 = -14;
        public const int ELEMENT_2 = -13;
        public const int ELEMENT_1 = -12;
        #endregion

        private static Dictionary<int, Type> Items = new Dictionary<int, Type>();

        public static Item GetItem(int id)
        {
            if (ItemFactory.Items.ContainsKey(id))
            {
                try
                {
                    Type type = ItemFactory.Items[id];
                    return (Item) Activator.CreateInstance(type);
                }
                catch { }
            }
            if (id < 256)
            {
                return new ItemBlock(Block.Get(id));
            }
            else if (id == IRON_SHOVEL)
            {
                return new ItemIronShovel();
            }
            else if (id == IRON_PICKAXE)
            {
                return new ItemIronPickaxe();
            }
            else if (id == IRON_AXE)
            {
                return new ItemIronAxe();
            }
            else if (id == FLINT_AND_STEEL)
            {
                return new ItemFlintAndSteel();
            }
            else if (id == APPLE)
            {
                return new ItemApple();
            }
            else if (id == BOW)
            {
                return new ItemBow();
            }
            else if (id == ARROW)
            {
                return new ItemArrow();
            }
            else if (id == COAL)
            {
                return new ItemCoal();
            }
            else if (id == DIAMOND)
            {
                return new ItemDiamond();
            }
            else if (id == IRON_INGOT)
            {
                return new ItemIronIngot();
            }
            else if (id == GOLD_INGOT)
            {
                return new ItemGoldIngot();
            }
            else if (id == IRON_SWORD)
            {
                return new ItemIronSword();
            }
            else if (id == WOODEN_SWORD)
            {
                return new ItemWoodenSword();
            }
            else if (id == WOODEN_SHOVEL)
            {
                return new ItemWoodenShovel();
            }
            else if (id == WOODEN_PICKAXE)
            {
                return new ItemWoodenPickaxe();
            }
            else if (id == WOODEN_AXE)
            {
                return new ItemWoodenAxe();
            }
            else if (id == STONE_SWORD)
            {
                return new ItemStoneSword();
            }
            else if (id == STONE_SHOVEL)
            {
                return new ItemStoneShovel();
            }
            else if (id == STONE_PICKAXE)
            {
                return new ItemStonePickaxe();
            }
            else if (id == STONE_AXE)
            {
                return new ItemStoneAxe();
            }
            else if (id == DIAMOND_SWORD)
            {
                return new ItemDiamondSword();
            }
            else if (id == DIAMOND_SHOVEL)
            {
                return new ItemDiamondShovel();
            }
            else if (id == DIAMOND_PICKAXE)
            {
                return new ItemDiamondPickaxe();
            }
            else if (id == DIAMOND_AXE)
            {
                return new ItemDiamondAxe();
            }
            else if (id == STICK)
            {
                return new ItemStick();
            }
            else if (id == BOWL)
            {
                return new ItemBowl();
            }
            else if (id == MUSHROOM_STEW)
            {
                return new ItemMushroomStew();
            }
            else if (id == GOLDEN_SWORD)
            {
                return new ItemGoldenSword();
            }
            else if (id == GOLDEN_SHOVEL)
            {
                return new ItemGoldenShovel();
            }
            else if (id == GOLDEN_PICKAXE)
            {
                return new ItemGoldenPickaxe();
            }
            else if (id == GOLDEN_AXE)
            {
                return new ItemGoldenAxe();
            }
            else if (id == STRING)
            {
                return new ItemString();
            }
            else if (id == FEATHER)
            {
                return new ItemFeather();
            }
            else if (id == GUNPOWDER)
            {
                return new ItemGunpowder();
            }
            else if (id == WOODEN_HOE)
            {
                return new ItemWoodenHoe();
            }
            else if (id == STONE_HOE)
            {
                return new ItemStoneHoe();
            }
            else if (id == IRON_HOE)
            {
                return new ItemIronHoe();
            }
            else if (id == DIAMOND_HOE)
            {
                return new ItemDiamondHoe();
            }
            else if (id == GOLDEN_HOE)
            {
                return new ItemGoldenHoe();
            }
            else if (id == WHEAT_SEEDS)
            {
                return new ItemWheatSeeds();
            }
            else if (id == WHEAT)
            {
                return new ItemWheat();
            }
            else if (id == BREAD)
            {
                return new ItemBread();
            }
            else if (id == LEATHER_HELMET)
            {
                return new ItemLeatherHelmet();
            }
            else if (id == LEATHER_CHESTPLATE)
            {
                return new ItemLeatherChestplate();
            }
            else if (id == LEATHER_LEGGINGS)
            {
                return new ItemLeatherLeggings();
            }
            else if (id == LEATHER_BOOTS)
            {
                return new ItemLeatherBoots();
            }
            else if (id == CHAINMAIL_HELMET)
            {
                return new ItemChainmailHelmet();
            }
            else if (id == CHAINMAIL_CHESTPLATE)
            {
                return new ItemChainmailChestplate();
            }
            else if (id == CHAINMAIL_LEGGINGS)
            {
                return new ItemLeatherLeggings();
            }
            else if (id == CHAINMAIL_BOOTS)
            {
                return new ItemChainmailBoots();
            }
            else if (id == IRON_HELMET)
            {
                return new ItemIronHelmet();
            }
            else if (id == IRON_CHESTPLATE)
            {
                return new ItemIronChestplate();
            }
            else if (id == IRON_LEGGINGS)
            {
                return new ItemIronLeggings();
            }
            else if (id == IRON_BOOTS)
            {
                return new ItemIronBoots();
            }
            else if (id == DIAMOND_HELMET)
            {
                return new ItemDiamondHelmet();
            }
            else if (id == DIAMOND_CHESTPLATE)
            {
                return new ItemDiamondChestplate();
            }
            else if (id == DIAMOND_LEGGINGS)
            {
                return new ItemDiamondLeggings();
            }
            else if (id == DIAMOND_BOOTS)
            {
                return new ItemDiamondBoots();
            }
            else if (id == GOLDEN_HELMET)
            {
                return new ItemGoldenHelmet();
            }
            else if (id == GOLDEN_CHESTPLATE)
            {
                return new ItemGoldenChestplate();
            }
            else if (id == GOLDEN_LEGGINGS)
            {
                return new ItemGoldenLeggings();
            }
            else if (id == GOLDEN_BOOTS)
            {
                return new ItemGoldenBoots();
            }
            else if (id == FLINT)
            {
                return new ItemFlint();
            }
            else if (id == PORKCHOP)
            {
                return new ItemPorkchop();
            }
            else if (id == COOKED_PORKCHOP)
            {
                return new ItemCookedPorkchop();
            }
            else if (id == PAINTING)
            {
                return new ItemPainting();
            }
            else if (id == GOLDEN_APPLE)
            {
                return new ItemGoldenApple();
            }
            else if (id == SIGN)
            {
                return new ItemSign();
            }
            else if (id == WOODEN_DOOR)
            {
                return new ItemDoorWooden();
            }
            else if (id == BUCKET)
            {
                return new ItemBucket();
            }

            else if (id == MINECART)
            {
                return new ItemMinecart();
            }
            else if (id == SADDLE)
            {
                return new ItemSaddle();
            }
            else if (id == IRON_DOOR)
            {
                return new ItemDoorIron();
            }
            else if (id == REDSTONE)
            {
                return new ItemRedstone();
            }
            else if (id == SNOWBALL)
            {
                return new ItemSnowball();
            }
            else if (id == BOAT)
            {
                return new ItemBoat();
            }
            else if (id == LEATHER)
            {
                return new ItemLeather();
            }

            else if (id == BRICK)
            {
                return new ItemBrick();
            }
            else if (id == CLAY_BALL)
            {
                return new ItemClayBall();
            }
            else if (id == REEDS)
            {
                return new ItemReeds();
            }
            else if (id == PAPER)
            {
                return new ItemPaper();
            }
            else if (id == BOOK)
            {
                return new ItemBook();
            }
            else if (id == SLIME_BALL)
            {
                return new ItemSlimeBall();
            }
            else if (id == CHEST_MINECART)
            {
                return new ItemChestMinecart();
            }

            else if (id == EGG)
            {
                return new ItemEgg();
            }
            else if (id == COMPASS)
            {
                return new ItemCompass();
            }
            else if (id == FISHING_ROD)
            {
                return new ItemFishingRod();
            }
            else if (id == CLOCK)
            {
                return new ItemClock();
            }
            else if (id == GLOWSTONE_DUST)
            {
                return new ItemGlownstoneDust();
            }
            else if (id == FISH)
            {
                return new ItemFish();
            }
            else if (id == COOKED_FISH)
            {
                return new ItemCookedFish();
            }
            else if (id == DYE)
            {
                return new ItemDye();
            }
            else if (id == BONE)
            {
                return new ItemBone();
            }
            else if (id == SUGAR)
            {
                return new ItemSugar();
            }
            else if (id == CAKE)
            {
                return new ItemCake();
            }
            else if (id == BED)
            {
                return new ItemBed();
            }
            else if (id == REPEATER)
            {
                return new ItemRepeater();
            }
            else if (id == COOKIE)
            {
                return new ItemCookie();
            }
            else if (id == FILLED_MAP)
            {
                return new ItemFilledMap();
            }
            else if (id == SHEARS)
            {
                return new ItemShears();
            }
            else if (id == MELON)
            {
                return new ItemMelon();
            }
            else if (id == PUMPKIN_SEEDS)
            {
                return new ItemPumpkinSeeds();
            }
            else if (id == MELON_SEEDS)
            {
                return new ItemMelonSeeds();
            }
            else if (id == BEEF)
            {
                return new ItemBeef();
            }
            else if (id == COOKED_BEEF)
            {
                return new ItemCookedBeef();
            }
            else if (id == CHICKEN)
            {
                return new ItemChicken();
            }
            else if (id == COOKED_CHICKEN)
            {
                return new ItemCookedChicken();
            }
            else if (id == ROTTEN_FLESH)
            {
                return new ItemRottenFlesh();
            }
            else if (id == ENDER_PEARL)
            {
                return new ItemEnderPearl();
            }
            else if (id == BLAZE_ROD)
            {
                return new ItemBlazeRod();
            }
            else if (id == GHAST_TEAR)
            {
                return new ItemGhastTear();
            }
            else if (id == GOLD_NUGGET)
            {
                return new ItemGoldNugget();
            }
            else if (id == NETHER_WART)
            {
                return new ItemNetherWart();
            }
            else if (id == POTION)
            {
                return new ItemPotion();
            }
            else if (id == GLASS_BOTTLE)
            {
                return new ItemGlassBottle();
            }
            else if (id == SPIDER_EYE)
            {
                return new ItemSpiderEye();
            }
            else if (id == FERMENTED_SPIDER_EYE)
            {
                return new ItemFermentedSpiderEye();
            }
            else if (id == BLAZE_POWDER)
            {
                return new ItemBlazePowder();
            }
            else if (id == MAGMA_CREAM)
            {
                return new ItemMagmaCream();
            }
            else if (id == BREWING_STAND)
            {
                return new ItemBrewingStand();
            }
            else if (id == CAULDRON)
            {
                return new ItemCauldron();
            }
            else if (id == ENDER_EYE)
            {
                return new ItemEnderEye();
            }
            else if (id == SPECKLED_MELON)
            {
                return new ItemSpeckledMelon();
            }
            else if (id == SPAWN_EGG)
            {
                return new ItemSpawnEgg();
            }
            else if (id == EXPERIENCE_BOTTLE)
            {
                return new ItemExperienceBottle();
            }
            else if (id == FIRE_CHARGE)
            {
                return new ItemFireCharge();
            }
            else if (id == WRITABLE_BOOK)
            {
                return new ItemWritableBook();
            }
            else if (id == EMERALD)
            {
                return new ItemEmerald();
            }
            else if (id == ITEM_FRAME)
            {
                return new ItemFrame();
            }
            else if (id == FLOWER_POT)
            {
                return new ItemFlowerPot();
            }
            else if (id == CARROT)
            {
                return new ItemCarrot();
            }
            else if (id == POTATO)
            {
                return new ItemPotato();
            }
            else if (id == BAKED_POTATO)
            {
                return new ItemBakedPotato();
            }
            else if (id == POISONOUS_POTATO)
            {
                return new ItemPoisonousPotato();
            }
            else if (id == MAP)
            {
                return new ItemMap();
            }
            else if (id == GOLDEN_CARROT)
            {
                return new ItemGoldenCarrot();
            }
            else if (id == SKULL)
            {
                return new ItemSkull();
            }
            else if (id == CARROT_ON_A_STICK)
            {
                return new ItemCarrotOnAStick();
            }
            else if (id == NETHER_STAR)
            {
                return new ItemNetherStar();
            }
            else if (id == PUMPKIN_PIE)
            {
                return new ItemPumpkinPie();
            }
            else if (id == FIREWORKS)
            {
                return new ItemFireworks();
            }
            else if (id == FIREWORK_CHARGE)
            {
                return new ItemFireworkCharge();
            }
            else if (id == ENCHANTED_BOOK)
            {
                return new ItemEnchantedBook();
            }
            else if (id == COMPARATOR)
            {
                return new ItemComparator();
            }
            else if (id == NETHERBRICK)
            {
                return new ItemNetherBrick();
            }
            else if (id == QUARTZ)
            {
                return new ItemQuartz();
            }
            else if (id == TNT_MINECART)
            {
                return new ItemTntMinecart();
            }
            else if (id == HOPPER_MINECART)
            {
                return new ItemHopperMinecart();
            }
            else if (id == PRISMARINE_SHARD)
            {
                return new ItemPrismarineShard();
            }
            else if (id == HOPPER)
            {
                return new ItemHopper();
            }
            else if (id == RABBIT)
            {
                return new ItemRabbit();
            }
            else if (id == COOKED_RABBIT)
            {
                return new ItemCookedRabbit();
            }
            else if (id == RABBIT_STEW)
            {
                return new ItemRabbitStew();
            }
            else if (id == RABBIT_FOOT)
            {
                return new ItemRabbitFoot();
            }
            else if (id == RABBIT_HIDE)
            {
                return new ItemRabbitHide();
            }
            else if (id == LEATHER_HORSE_ARMOR)
            {
                return new ItemLeatherHorseArmor();
            }
            else if (id == IRON_HORSE_ARMOR)
            {
                return new ItemIronHorseArmor();
            }
            else if (id == GOLDEN_HORSE_ARMOR)
            {
                return new ItemGoldenHorseArmor();
            }
            else if (id == DIAMOND_HORSE_ARMOR)
            {
                return new ItemDiamondHorseArmor();
            }
            else if (id == LEAD)
            {
                return new ItemLead();
            }
            else if (id == NAME_TAG)
            {
                return new ItemNameTag();
            }
            else if (id == PRISMARINE_CRYSTALS)
            {
                return new ItemPrismarineCrystals();
            }
            else if (id == MUTTON)
            {
                return new ItemMutton();
            }
            else if (id == COOKED_MUTTON)
            {
                return new ItemCookedMutton();
            }
            else if (id == ARMOR_STAND)
            {
                return new ItemArmorStand();
            }
            else if (id == END_CRYSTAL)
            {
                return new ItemEndCrystal();
            }
            else if (id == SPRUCE_DOOR)
            {
                return new ItemDoorSpruce();
            }
            else if (id == BIRCH_DOOR)
            {
                return new ItemDoorBirch();
            }
            else if (id == JUNGLE_DOOR)
            {
                return new ItemDoorJungle();
            }
            else if (id == ACACIA_DOOR)
            {
                return new ItemDoorAcacia();
            }
            else if (id == DARK_OAK_DOOR)
            {
                return new ItemDoorDarkOak();
            }
            else if (id == CHORUS_FRUIT)
            {
                return new ItemChorusFruit();
            }
            else if (id == POPPED_CHORUS_FRUIT)
            {
                return new ItemPoppedChorusFruit();
            }

            else if (id == DRAGON_BREATH)
            {
                return new ItemDragonBreath();
            }
            else if (id == SPLASH_POTION)
            {
                return new ItemSplashPotion();
            }

            else if (id == LINGERING_POTION)
            {
                return new ItemLingeringPotion();
            }

            else if (id == COMMAND_BLOCK_MINECART)
            {
                return new ItemCommandBlockMinecart();
            }
            else if (id == ELYTRA)
            {
                return new ItemElytra();
            }
            else if (id == SHULKER_SHELL)
            {
                return new ItemShulkerShell();
            }
            else if (id == BANNER)
            {
                return new ItemBanner();
            }

            else if (id == TOTEM)
            {
                return new ItemTotem();
            }

            else if (id == BEETROOT)
            {
                return new ItemBeetroot();
            }
            else if (id == BEETROOT_SEEDS)
            {
                return new ItemBeetrootSeed();
            }
            else if (id == BEETROOT_SOUP)
            {
                return new ItemBeetrootSoup();
            }
            else if (id == SALMON)
            {
                return new ItemSalmon();
            }
            else if (id == CLOWNFISH)
            {
                return new ItemClownfish();
            }
            else if (id == PUFFERFISH)
            {
                return new ItemPufferfish();
            }
            else if (id == COOKED_SALMON)
            {
                return new ItemCookedSalmon();
            }

            else if (id == APPLEENCHANTED)
            {
                return new ItemAppleenchanted();
            }

            else if (id == RECORD_13)
            {
                return new ItemRecord13();
            }
            else if (id == RECORD_CAT)
            {
                return new ItemRecordCat();
            }
            else if (id == RECORD_BLOCKS)
            {
                return new ItemRecordBlocks();
            }
            else if (id == RECORD_CHIRP)
            {
                return new ItemRecordChirp();
            }
            else if (id == RECORD_FAR)
            {
                return new ItemRecordFar();
            }
            else if (id == RECORD_MALL)
            {
                return new ItemRecordMall();
            }
            else if (id == RECORD_MELLOHI)
            {
                return new ItemRecordMellohi();
            }
            else if (id == RECORD_STAL)
            {
                return new ItemRecordStal();
            }
            else if (id == RECORD_STRAD)
            {
                return new ItemRecordStrad();
            }
            else if (id == RECORD_WARD)
            {
                return new ItemRecordWard();
            }
            else if (id == RECORD_11)
            {
                return new ItemRecord11();
            }
            else if (id == RECORD_WAIT)
            {
                return new ItemRecordWait();
            }
            else
            {
                return new Item(id);
            }
        }

        public static Item GetItem(string name)
        {
            string[] data = name.Replace("minecraft:", "").Replace(" ", "_").ToUpper().Split(':');
            int id = 0;
            int meta = 0;

            if (data.Length == 1)
            {
                int.TryParse(data[0], out id);
            }

            if (data.Length == 2)
            {
                int.TryParse(data[0], out id);
                int.TryParse(data[1], out meta);
            }

            try
            {
                ItemFactory factory = new ItemFactory();
                id = (int) factory.GetType().GetField(data[0]).GetValue(factory);
            }
            catch
            {
                try
                {
                    BlockFactory factory = new BlockFactory();
                    id = (int) factory.GetType().GetField(data[0]).GetValue(factory);
                }
                catch
                {

                }
            }

            Item item = Item.Get(id, meta);
            return item;
        }

        public static void RegisterItem(Item item)
        {
            ItemFactory.Items[item.ID] = item.GetType();
        }
    }
}
