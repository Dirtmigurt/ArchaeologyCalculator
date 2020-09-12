using System;
using System.Collections.Generic;
using System.Text;

namespace ArchaeologyCalculator
{
    public static class ExcavationSpots
    {
        public static ExcavationHotspot OikosFishingHutRemnants { get; set; } = new ExcavationHotspot
        {
            LevelReq = 84,
            XpArtifact = 478,
            XpMaterial = 43,
            XpFail = 4.7,
            XpRestoration = 8555.6,
            ArtifactCount = 2,
            Site = ExcavationSite.Everlight,
            Name = nameof(OikosFishingHutRemnants),
            PotentialMats = new List<MaterialEntry>
            {
                new MaterialEntry { Type = MaterialType.ThirdAgeIron, Chance = 0.3 },
                new MaterialEntry { Type = MaterialType.Goldrune, Chance = 0.3 },
                new MaterialEntry { Type = MaterialType.Silvthril, Chance = 0.2 },
                new MaterialEntry { Type = MaterialType.StarOfSaradomin, Chance = 0.2 }
            },
            RequiredMaterails = new Dictionary<MaterialType, int>
            {
                { MaterialType.Silvthril, 30 },
                { MaterialType.Keramos, 22 },
                { MaterialType.ThirdAgeIron, 52 },
                { MaterialType.StarOfSaradomin, 22 },
                { MaterialType.Goldrune, 22 }
            }
        };

        public static ExcavationHotspot DisOVerspill { get; set; } = new ExcavationHotspot
        {
            LevelReq = 89,
            XpArtifact = 576,
            XpMaterial = 51.8,
            XpFail = 5.7,
            XpRestoration = 10500,
            ArtifactCount = 2,
            Site = ExcavationSite.InfernalSource,
            Name = nameof(DisOVerspill),
            PotentialMats = new List<MaterialEntry>
            {
                new MaterialEntry { Type = MaterialType.ThirdAgeIron, Chance = 0.2 },
                new MaterialEntry { Type = MaterialType.CadmiumRed, Chance = 0.2 },
                new MaterialEntry { Type = MaterialType.EyeOfDagon, Chance = 0.3 },
                new MaterialEntry { Type = MaterialType.HellfireMetal, Chance = 0.3 }
            },
            RequiredMaterails = new Dictionary<MaterialType, int>
            {
                { MaterialType.EyeOfDagon, 20 },
                { MaterialType.ThirdAgeIron, 20 },
                { MaterialType.HellfireMetal, 38 },
                { MaterialType.WhiteOak, 12 },
                { MaterialType.SamiteSilk, 12 },
                { MaterialType.Vellum, 12 },
                { MaterialType.CadmiumRed, 42 }
            }
        };

        public static ExcavationHotspot AcropolisDebris { get; set; } = new ExcavationHotspot
        {
            LevelReq = 92,
            XpArtifact = 668,
            XpMaterial = 60.1,
            XpFail = 6.6,
            XpRestoration = 11666.7,
            ArtifactCount = 2,
            Site = ExcavationSite.Everlight,
            Name = nameof(AcropolisDebris),
            PotentialMats = new List<MaterialEntry>
            {
                new MaterialEntry { Type = MaterialType.Goldrune, Chance = 0.2 },
                new MaterialEntry { Type = MaterialType.Keramos, Chance = 0.3 },
                new MaterialEntry { Type = MaterialType.WhiteMarble, Chance = 0.3 },
                new MaterialEntry { Type = MaterialType.Silvthril, Chance = 0.2 }
            },
            RequiredMaterails = new Dictionary<MaterialType, int>
            {
                { MaterialType.Silvthril, 34 },
                { MaterialType.Keramos, 46 },
                { MaterialType.WhiteMarble, 30 },
                { MaterialType.StarOfSaradomin, 24 },
                { MaterialType.Goldrune, 26 }
            }
        };

        public static ExcavationHotspot GoblinTraineeRemains { get; set; } = new ExcavationHotspot
        {
            LevelReq = 97,
            XpArtifact = 793,
            XpMaterial = 71.4,
            XpFail = 7.9,
            XpRestoration = 15833.3,
            ArtifactCount = 3,
            Site = ExcavationSite.Warforge,
            Name = nameof(GoblinTraineeRemains),
            PotentialMats = new List<MaterialEntry>
            {
                new MaterialEntry { Type = MaterialType.ThirdAgeIron, Chance = 0.2 },
                new MaterialEntry { Type = MaterialType.LeatherScraps, Chance = 0.2 },
                new MaterialEntry { Type = MaterialType.FossilizedBone, Chance = 0.3 },
                new MaterialEntry { Type = MaterialType.WarforgedBronze, Chance = 0.3 }
            },
            RequiredMaterails = new Dictionary<MaterialType, int>
            {
                { MaterialType.WarforgedBronze, 32 },
                { MaterialType.MarkOfTheKyzaj, 46 },
                { MaterialType.ThirdAgeIron, 56 },
                { MaterialType.WhiteOak, 40 },
                { MaterialType.LeatherScraps, 42 },
                { MaterialType.Orthenglass, 26 },
                { MaterialType.MalachiteGreen, 22 }
            }
        };

        public static ExcavationHotspot GoblinTraineeRemainsRR2 { get; set; } = new ExcavationHotspot
        {
            LevelReq = 97,
            XpArtifact = 793,
            XpMaterial = 71.4,
            XpFail = 7.9,
            XpRestoration = 15833.3,
            ArtifactCount = 3,
            UsedArtifactCount = 2,
            Site = ExcavationSite.Warforge,
            Name = nameof(GoblinTraineeRemains),
            PotentialMats = new List<MaterialEntry>
            {
                new MaterialEntry { Type = MaterialType.ThirdAgeIron, Chance = 0.2 },
                new MaterialEntry { Type = MaterialType.LeatherScraps, Chance = 0.2 },
                new MaterialEntry { Type = MaterialType.FossilizedBone, Chance = 0.3 },
                new MaterialEntry { Type = MaterialType.WarforgedBronze, Chance = 0.3 }
            },
            RequiredMaterails = new Dictionary<MaterialType, int>
            {
                { MaterialType.WhiteOak, 40 },
                { MaterialType.LeatherScraps, 42 },
                { MaterialType.Orthenglass, 26 },
                { MaterialType.MalachiteGreen, 22 },
                { MaterialType.MarkOfTheKyzaj, 20 },
                { MaterialType.ThirdAgeIron, 26 }
            }
        };

        public static ExcavationHotspot ByzrothRemains { get; set; } = new ExcavationHotspot
        {
            LevelReq = 98,
            XpArtifact = 854,
            XpMaterial = 76.8,
            XpFail = 8.5,
            XpRestoration = 16666.7,
            ArtifactCount = 3,
            Site = ExcavationSite.InfernalSource,
            Name = nameof(ByzrothRemains),
            PotentialMats = new List<MaterialEntry>
            {
                new MaterialEntry { Type = MaterialType.WhiteOak, Chance = 0.2 },
                new MaterialEntry { Type = MaterialType.Orthenglass, Chance = 0.2 },
                new MaterialEntry { Type = MaterialType.LeatherScraps, Chance = 0.3 },
                new MaterialEntry { Type = MaterialType.HellfireMetal, Chance = 0.3 }
            },
            RequiredMaterails = new Dictionary<MaterialType, int>
            {
                { MaterialType.LeatherScraps, 60 },
                { MaterialType.ThirdAgeIron, 26 },
                { MaterialType.Orthenglass, 26 },
                { MaterialType.WhiteOak, 26 },
                { MaterialType.HellfireMetal, 132 }
            }
        };

        public static ExcavationHotspot DestroyedGolem { get; set; } = new ExcavationHotspot
        {
            LevelReq = 98,
            XpArtifact = 854,
            XpMaterial = 76.8,
            XpFail = 8.5,
            XpRestoration = 16666.7,
            ArtifactCount = 2,
            Site = ExcavationSite.StormguardCitadel,
            Name = nameof(DestroyedGolem),
            PotentialMats = new List<MaterialEntry>
            {
                new MaterialEntry { Type = MaterialType.Vellum, Chance = 0.2 },
                new MaterialEntry { Type = MaterialType.Soapstone, Chance = 0.2 },
                new MaterialEntry { Type = MaterialType.AetheriumAlloy, Chance = 0.3 },
                new MaterialEntry { Type = MaterialType.Quintessence, Chance = 0.3 }
            },
            RequiredMaterails = new Dictionary<MaterialType, int>
            {
                { MaterialType.AetheriumAlloy, 34 },
                { MaterialType.Quintessence, 69 },
                { MaterialType.Orthenglass, 16 },
                { MaterialType.Soapstone, 16 },
                { MaterialType.Vellum, 44 }
            }
        };

        public static ExcavationHotspot IcyeneWeaponRack { get; set; } = new ExcavationHotspot
        {
            LevelReq = 100,
            XpArtifact = 956,
            XpMaterial = 94,
            XpFail = 9.5,
            XpRestoration = 18666.7,
            ArtifactCount = 2,
            Site = ExcavationSite.Everlight,
            Name = nameof(IcyeneWeaponRack),
            PotentialMats = new List<MaterialEntry>
            {
                new MaterialEntry { Type = MaterialType.LeatherScraps, Chance = 0.5 },
                new MaterialEntry { Type = MaterialType.Silvthril, Chance = 0.5 },
            },
            RequiredMaterails = new Dictionary<MaterialType, int>
            {
                { MaterialType.LeatherScraps, 88 },
                { MaterialType.Silvthril, 96 }
            }
        };

        public static ExcavationHotspot CulinarumDebris { get; set; } = new ExcavationHotspot
        {
            LevelReq = 100,
            XpArtifact = 900,
            XpMaterial = 85.9,
            XpFail = 9,
            XpRestoration = 18666.7,
            ArtifactCount = 2,
            Site = ExcavationSite.KharidEt,
            Name = nameof(CulinarumDebris),
            PotentialMats = new List<MaterialEntry>
            {
                new MaterialEntry { Type = MaterialType.ImperialSteel, Chance = 0.3 },
                new MaterialEntry { Type = MaterialType.AncientVis, Chance = 0.3 },
                new MaterialEntry { Type = MaterialType.Vellum, Chance = 0.2 },
                new MaterialEntry { Type = MaterialType.BloodOfOrcus, Chance = 0.2 }
            },
            RequiredMaterails = new Dictionary<MaterialType, int>
            {
                { MaterialType.Vellum, 40 },
                { MaterialType.ImperialSteel, 54 },
                { MaterialType.AncientVis, 58 },
                { MaterialType.BloodOfOrcus, 32 }
            }
        };

        public static ExcavationHotspot KyzajChampionsBoudoir { get; set; } = new ExcavationHotspot
        {
            LevelReq = 100,
            XpArtifact = 1000,
            XpMaterial = 100,
            XpFail = 10,
            XpRestoration = 18666.7,
            ArtifactCount = 2,
            Site = ExcavationSite.Warforge,
            Name = nameof(KyzajChampionsBoudoir),
            PotentialMats = new List<MaterialEntry>
            {
                new MaterialEntry { Type = MaterialType.WhiteOak, Chance = 0.3 },
                new MaterialEntry { Type = MaterialType.YubiuskClay, Chance = 0.3 },
                new MaterialEntry { Type = MaterialType.WarforgedBronze, Chance = 0.4 }
            },
            RequiredMaterails = new Dictionary<MaterialType, int>
            {
                { MaterialType.WhiteOak, 42 },
                { MaterialType.WarforgedBronze, 100 },
                { MaterialType.YubiuskClay, 42 }
            }
        };

        public static ExcavationHotspot KeshikWeaponRack { get; set; } = new ExcavationHotspot
        {
            LevelReq = 103,
            XpArtifact = 1050,
            XpMaterial = 104.8,
            XpFail = 10,
            XpRestoration = 22166.7,
            ArtifactCount = 2,
            Site = ExcavationSite.StormguardCitadel,
            Name = nameof(KeshikWeaponRack),
            PotentialMats = new List<MaterialEntry>
            {
                new MaterialEntry { Type = MaterialType.StormguardSteel, Chance = 0.2 },
                new MaterialEntry { Type = MaterialType.WingsOfWar, Chance = 0.2 },
                new MaterialEntry { Type = MaterialType.AetheriumAlloy, Chance = 0.3 },
                new MaterialEntry { Type = MaterialType.Quintessence, Chance = 0.3 }
            },
            RequiredMaterails = new Dictionary<MaterialType, int>
            {
                { MaterialType.WhiteOak, 30 },
                { MaterialType.StormguardSteel, 30 },
                { MaterialType.Quintessence, 46 },
                { MaterialType.AetheriumAlloy, 50 },
                { MaterialType.WingsOfWar, 36 }
            }
        };

        public static ExcavationHotspot HellfireForge { get; set; } = new ExcavationHotspot
        {
            LevelReq = 104,
            XpArtifact = 1100,
            XpMaterial = 105,
            XpFail = 11,
            XpRestoration = 23333.3,
            ArtifactCount = 3,
            Site = ExcavationSite.InfernalSource,
            Name = nameof(HellfireForge),
            PotentialMats = new List<MaterialEntry>
            {
                new MaterialEntry { Type = MaterialType.CadmiumRed, Chance = 0.2 },
                new MaterialEntry { Type = MaterialType.ThirdAgeIron, Chance = 0.2 },
                new MaterialEntry { Type = MaterialType.EyeOfDagon, Chance = 0.3 },
                new MaterialEntry { Type = MaterialType.HellfireMetal, Chance = 0.3 }
            },
            RequiredMaterails = new Dictionary<MaterialType, int>
            {
                { MaterialType.ChaoticBrimstone, 60 },
                { MaterialType.ThirdAgeIron, 64 },
                { MaterialType.EyeOfDagon, 54 },
                { MaterialType.CadmiumRed, 24 },
                { MaterialType.HellfireMetal, 92 }
            }
        };

        public static ExcavationHotspot WarforgeScrapPile { get; set; } = new ExcavationHotspot
        {
            LevelReq = 104,
            XpArtifact = 1100,
            XpMaterial = 105,
            XpFail = 11,
            XpRestoration = 23333.3,
            ArtifactCount = 2,
            Site = ExcavationSite.Warforge,
            Name = nameof(WarforgeScrapPile),
            PotentialMats = new List<MaterialEntry>
            {
                new MaterialEntry { Type = MaterialType.ThirdAgeIron, Chance = 0.5 },
                new MaterialEntry { Type = MaterialType.WarforgedBronze, Chance = 0.5 },
            },
            RequiredMaterails = new Dictionary<MaterialType, int>
            {
                { MaterialType.EyeOfDagon, 20 },
                { MaterialType.WarforgedBronze, 88 },
                { MaterialType.ThirdAgeIron, 68 },
                { MaterialType.StarOfSaradomin, 20 }
            }
        };

        public static ExcavationHotspot StockpiledArt { get; set; } = new ExcavationHotspot
        {
            LevelReq = 105,
            XpArtifact = 1147,
            XpMaterial = 103.5,
            XpFail = 11.5,
            XpRestoration = 24500,
            ArtifactCount = 3,
            Site = ExcavationSite.Everlight,
            Name = nameof(StockpiledArt),
            PotentialMats = new List<MaterialEntry>
            {
                new MaterialEntry { Type = MaterialType.SamiteSilk, Chance = 0.2 },
                new MaterialEntry { Type = MaterialType.WhiteOak, Chance = 0.2 },
                new MaterialEntry { Type = MaterialType.Vellum, Chance = 0.2 },
                new MaterialEntry { Type = MaterialType.CobaltBlue, Chance = 0.4 }
            },
            RequiredMaterails = new Dictionary<MaterialType, int>
            {
                { MaterialType.CobaltBlue, 156 },
                { MaterialType.Vellum, 48 },
                { MaterialType.SamiteSilk, 48 },
                { MaterialType.WhiteOak, 48 }
            }
        };

        public static ExcavationHotspot AncientMagickMunitions { get; set; } = new ExcavationHotspot
        {
            LevelReq = 107,
            XpArtifact = 1293,
            XpMaterial = 116,
            XpFail = 13,
            XpRestoration = 27000,
            ArtifactCount = 3,
            Site = ExcavationSite.KharidEt,
            Name = nameof(AncientMagickMunitions),
            PotentialMats = new List<MaterialEntry>
            {
                new MaterialEntry { Type = MaterialType.Vellum, Chance = 0.2 },
                new MaterialEntry { Type = MaterialType.ImperialSteel, Chance = 0.2 },
                new MaterialEntry { Type = MaterialType.AncientVis, Chance = 0.3 },
                new MaterialEntry { Type = MaterialType.BloodOfOrcus, Chance = 0.3 }
            },
            RequiredMaterails = new Dictionary<MaterialType, int>
            {
                { MaterialType.Vellum, 40 },
                { MaterialType.ImperialSteel, 48 },
                { MaterialType.AncientVis, 84 },
                { MaterialType.BloodOfOrcus, 140 }
            }
        };

        public static ExcavationHotspot BibliothekeDebris { get; set; } = new ExcavationHotspot
        {
            LevelReq = 109,
            XpArtifact = 1300,
            XpMaterial = 121,
            XpFail = 13,
            XpRestoration = 29666.7,
            ArtifactCount = 2,
            Site = ExcavationSite.Everlight,
            Name = nameof(BibliothekeDebris),
            PotentialMats = new List<MaterialEntry>
            {
                new MaterialEntry { Type = MaterialType.Goldrune, Chance = 0.2 },
                new MaterialEntry { Type = MaterialType.Vellum, Chance = 0.3 },
                new MaterialEntry { Type = MaterialType.WhiteMarble, Chance = 0.3 },
                new MaterialEntry { Type = MaterialType.StarOfSaradomin, Chance = 0.2 }
            },
            RequiredMaterails = new Dictionary<MaterialType, int>
            {
                { MaterialType.WhiteMarble, 60 },
                { MaterialType.Vellum, 60 },
                { MaterialType.Goldrune, 50 },
                { MaterialType.StarOfSaradomin, 50 }
            }
        };

        public static ExcavationHotspot ChthonianTrophies { get; set; } = new ExcavationHotspot
        {
            LevelReq = 110,
            XpArtifact = 1450,
            XpMaterial = 134,
            XpFail = 14.5,
            XpRestoration = 31000,
            ArtifactCount = 2,
            Site = ExcavationSite.InfernalSource,
            Name = nameof(ChthonianTrophies),
            PotentialMats = new List<MaterialEntry>
            {
                new MaterialEntry { Type = MaterialType.WhiteOak, Chance = 0.3 },
                new MaterialEntry { Type = MaterialType.ChaoticBrimstone, Chance = 0.2 },
                new MaterialEntry { Type = MaterialType.Orthenglass, Chance = 0.2 },
                new MaterialEntry { Type = MaterialType.Demonhide, Chance = 0.3 }
            },
            RequiredMaterails = new Dictionary<MaterialType, int>
            {
                { MaterialType.ChaoticBrimstone, 52 },
                { MaterialType.Orthenglass, 34 },
                { MaterialType.HellfireMetal, 30 },
                { MaterialType.Demonhide, 44 },
                { MaterialType.WhiteOak, 64 }
            }
        };

        public static ExcavationHotspot WarforgeWeaponRack { get; set; } = new ExcavationHotspot
        {
            LevelReq = 110,
            XpArtifact = 1400,
            XpMaterial = 134,
            XpFail = 14.5,
            XpRestoration = 31000,
            ArtifactCount = 2,
            Site = ExcavationSite.Warforge,
            Name = nameof(WarforgeWeaponRack),
            PotentialMats = new List<MaterialEntry>
            {
                new MaterialEntry { Type = MaterialType.FossilizedBone, Chance = 0.3 },
                new MaterialEntry { Type = MaterialType.MalachiteGreen, Chance = 0.3 },
                new MaterialEntry { Type = MaterialType.WarforgedBronze, Chance = 0.4 },
            },
            RequiredMaterails = new Dictionary<MaterialType, int>
            {
                { MaterialType.WarforgedBronze, 110 },
                { MaterialType.FossilizedBone, 78 },
                { MaterialType.MalachiteGreen, 36 },
            }
        };

        public static ExcavationHotspot FlightResearchDebris { get; set; } = new ExcavationHotspot
        {
            LevelReq = 111,
            XpArtifact = 1400,
            XpMaterial = 130,
            XpFail = 14,
            XpRestoration = 32333.3,
            ArtifactCount = 2,
            Site = ExcavationSite.StormguardCitadel,
            Name = nameof(FlightResearchDebris),
            PotentialMats = new List<MaterialEntry>
            {
                new MaterialEntry { Type = MaterialType.SamiteSilk, Chance = 0.3 },
                new MaterialEntry { Type = MaterialType.LeatherScraps, Chance = 0.2 },
                new MaterialEntry { Type = MaterialType.Orthenglass, Chance = 0.2 },
                new MaterialEntry { Type = MaterialType.ArmadyleanYellow, Chance = 0.3 }
            },
            RequiredMaterails = new Dictionary<MaterialType, int>
            {
                { MaterialType.LeatherScraps, 40 },
                { MaterialType.SamiteSilk, 54 },
                { MaterialType.Orthenglass, 30 },
                { MaterialType.ArmadyleanYellow, 104 }
            }
        };

        public static ExcavationHotspot AetheriumForge { get; set; } = new ExcavationHotspot
        {
            LevelReq = 112,
            XpArtifact = 1500,
            XpMaterial = 135,
            XpFail = 15,
            XpRestoration = 33666.7,
            ArtifactCount = 3,
            Site = ExcavationSite.StormguardCitadel,
            Name = nameof(AetheriumForge),
            PotentialMats = new List<MaterialEntry>
            {
                new MaterialEntry { Type = MaterialType.Goldrune, Chance = 0.2 },
                new MaterialEntry { Type = MaterialType.WingsOfWar, Chance = 0.3 },
                new MaterialEntry { Type = MaterialType.AetheriumAlloy, Chance = 0.3 },
                new MaterialEntry { Type = MaterialType.Quintessence, Chance = 0.2 }
            },
            RequiredMaterails = new Dictionary<MaterialType, int>
            {
                { MaterialType.AetheriumAlloy, 150 },
                { MaterialType.Quintessence, 68 },
                { MaterialType.Goldrune, 34 },
                { MaterialType.WingsOfWar, 102 }
            }
        };

        public static ExcavationHotspot PraetorianRemains { get; set; } = new ExcavationHotspot
        {
            LevelReq = 114,
            XpArtifact = 1800,
            XpMaterial = 154,
            XpFail = 18,
            XpRestoration = 36666.7,
            ArtifactCount = 3,
            Site = ExcavationSite.KharidEt,
            Name = nameof(PraetorianRemains),
            PotentialMats = new List<MaterialEntry>
            {
                new MaterialEntry { Type = MaterialType.SamiteSilk, Chance = 0.2 },
                new MaterialEntry { Type = MaterialType.ImperialSteel, Chance = 0.2 },
                new MaterialEntry { Type = MaterialType.ZarosianInsignia, Chance = 0.3 },
                new MaterialEntry { Type = MaterialType.AncientVis, Chance = 0.3 }
            },
            RequiredMaterails = new Dictionary<MaterialType, int>
            {
                { MaterialType.ZarosianInsignia, 110 },
                { MaterialType.ImperialSteel, 36 },
                { MaterialType.SamiteSilk, 102 },
                { MaterialType.AncientVis, 124 }
            }
        };

        public static ExcavationHotspot BandosSanctumDebris { get; set; } = new ExcavationHotspot
        {
            LevelReq = 115,
            XpArtifact = 1600,
            XpMaterial = 144,
            XpFail = 16,
            XpRestoration = 38333.3,
            ArtifactCount = 3,
            Site = ExcavationSite.Warforge,
            Name = nameof(BandosSanctumDebris),
            PotentialMats = new List<MaterialEntry>
            {
                new MaterialEntry { Type = MaterialType.FossilizedBone, Chance = 0.3 },
                new MaterialEntry { Type = MaterialType.AnimalFurs, Chance = 0.2 },
                new MaterialEntry { Type = MaterialType.VulcanizedRubber, Chance = 0.3 },
                new MaterialEntry { Type = MaterialType.YubiuskClay, Chance = 0.2 }
            },
            RequiredMaterails = new Dictionary<MaterialType, int>
            {
                { MaterialType.VulcanizedRubber, 86 },
                { MaterialType.AnimalFurs, 100 },
                { MaterialType.ThirdAgeIron, 44 },
                { MaterialType.YubiuskClay, 66 },
                { MaterialType.FossilizedBone, 82 },
            }
        };

        public static ExcavationHotspot TsutsarothRemains { get; set; } = new ExcavationHotspot
        {
            LevelReq = 116,
            XpArtifact = 1800,
            XpMaterial = 160,
            XpFail = 18,
            XpRestoration = 40000,
            ArtifactCount = 3,
            Site = ExcavationSite.InfernalSource,
            Name = nameof(TsutsarothRemains),
            PotentialMats = new List<MaterialEntry>
            {
                new MaterialEntry { Type = MaterialType.ThirdAgeIron, Chance = 0.2 },
                new MaterialEntry { Type = MaterialType.Goldrune, Chance = 0.2 },
                new MaterialEntry { Type = MaterialType.HellfireMetal, Chance = 0.3 },
                new MaterialEntry { Type = MaterialType.EyeOfDagon, Chance = 0.3 }
            },
            RequiredMaterails = new Dictionary<MaterialType, int>
            {
                { MaterialType.EyeOfDagon, 120 },
                { MaterialType.Goldrune, 90 },
                { MaterialType.ThirdAgeIron, 40 },
                { MaterialType.HellfireMetal, 140 }
            }
        };

        public static ExcavationHotspot OptimatoiRemains { get; set; } = new ExcavationHotspot
        {
            LevelReq = 117,
            XpArtifact = 1760,
            XpMaterial = 162.9,
            XpFail = 17.6,
            XpRestoration = 41666.7,
            ArtifactCount = 2,
            Site = ExcavationSite.Everlight,
            Name = nameof(OptimatoiRemains),
            PotentialMats = new List<MaterialEntry>
            {
                new MaterialEntry { Type = MaterialType.SamiteSilk, Chance = 0.2 },
                new MaterialEntry { Type = MaterialType.WhiteOak, Chance = 0.2 },
                new MaterialEntry { Type = MaterialType.Silvthril, Chance = 0.3 }
            },
            RequiredMaterails = new Dictionary<MaterialType, int>
            {
                { MaterialType.SamiteSilk, 62 },
                { MaterialType.WhiteOak, 62 },
                { MaterialType.Silvthril, 140 }
            }
        };

        public static ExcavationHotspot WarTableDebris { get; set; } = new ExcavationHotspot
        {
            LevelReq = 118,
            XpArtifact = 1700,
            XpMaterial = 158,
            XpFail = 17,
            XpRestoration = 43333.3,
            ArtifactCount = 3,
            Site = ExcavationSite.KharidEt,
            Name = nameof(WarTableDebris),
            PotentialMats = new List<MaterialEntry>
            {
                new MaterialEntry { Type = MaterialType.WhiteOak, Chance = 0.3 },
                new MaterialEntry { Type = MaterialType.Vellum, Chance = 0.2 },
                new MaterialEntry { Type = MaterialType.TyrianPurple, Chance = 0.3 },
                new MaterialEntry { Type = MaterialType.AncientVis, Chance = 0.2 }
            },
            RequiredMaterails = new Dictionary<MaterialType, int>
            {
                { MaterialType.TyrianPurple, 188 },
                { MaterialType.ZarosianInsignia, 20 },
                { MaterialType.Vellum, 40 },
                { MaterialType.SamiteSilk, 20 },
                { MaterialType.AncientVis, 94 },
                { MaterialType.WhiteOak, 40 }
            }
        };

        public static ExcavationHotspot HowlsWorkshopDebris { get; set; } = new ExcavationHotspot
        {
            LevelReq = 118,
            XpArtifact = 1700,
            XpMaterial = 158,
            XpFail = 17,
            XpRestoration = 43333.3,
            ArtifactCount = 3,
            Site = ExcavationSite.StormguardCitadel,
            Name = nameof(HowlsWorkshopDebris),
            PotentialMats = new List<MaterialEntry>
            {
                new MaterialEntry { Type = MaterialType.AetheriumAlloy, Chance = 0.3 },
                new MaterialEntry { Type = MaterialType.Soapstone, Chance = 0.2 },
                new MaterialEntry { Type = MaterialType.Quintessence, Chance = 0.3 },
                new MaterialEntry { Type = MaterialType.ArmadyleanYellow, Chance = 0.2 }
            },
            RequiredMaterails = new Dictionary<MaterialType, int>
            {
                { MaterialType.Goldrune, 24 },
                { MaterialType.Soapstone, 40 },
                { MaterialType.Orthenglass, 48 },
                { MaterialType.AetheriumAlloy, 86 },
                { MaterialType.StormguardSteel, 40 },
                { MaterialType.ArmadyleanYellow, 40 },
                { MaterialType.Quintessence, 84 },
                { MaterialType.WhiteOak, 40 }
            }
        };

        public static ExcavationHotspot MakeshiftPieOven { get; set; } = new ExcavationHotspot
        {
            LevelReq = 119,
            XpArtifact = 1800,
            XpMaterial = 162,
            XpFail = 18,
            XpRestoration = 45000,
            ArtifactCount = 2,
            Site = ExcavationSite.Warforge,
            Name = nameof(MakeshiftPieOven),
            PotentialMats = new List<MaterialEntry>
            {
                new MaterialEntry { Type = MaterialType.Soapstone, Chance = 0.3 },
                new MaterialEntry { Type = MaterialType.MalachiteGreen, Chance = 0.3 },
                new MaterialEntry { Type = MaterialType.YubiuskClay, Chance = 0.4 }
            },
            RequiredMaterails = new Dictionary<MaterialType, int>
            {
                { MaterialType.Soapstone, 84 },
                { MaterialType.MalachiteGreen, 82 },
                { MaterialType.YubiuskClay, 110 }
            }
        };

        public static ExcavationHotspot MakeshiftPieOvenBossManOnly { get; set; } = new ExcavationHotspot
        {
            LevelReq = 119,
            XpArtifact = 1800,
            XpMaterial = 162,
            XpFail = 18,
            XpRestoration = 45000,
            ArtifactCount = 2,
            UsedArtifactCount = 1,
            Site = ExcavationSite.Warforge,
            Name = nameof(MakeshiftPieOven),
            PotentialMats = new List<MaterialEntry>
            {
                new MaterialEntry { Type = MaterialType.Soapstone, Chance = 0.3 },
                new MaterialEntry { Type = MaterialType.MalachiteGreen, Chance = 0.3 },
                new MaterialEntry { Type = MaterialType.YubiuskClay, Chance = 0.4 }
            },
            RequiredMaterails = new Dictionary<MaterialType, int>
            {
                { MaterialType.Soapstone, 44 },
                { MaterialType.MalachiteGreen, 44 },
                { MaterialType.YubiuskClay, 50 }
            }
        };
    }
}
