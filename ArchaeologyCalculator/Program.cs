using System;
using System.Collections.Generic;
using System.Linq;

namespace ArchaeologyCalculator
{
    class Program
    {
        private static int CurrentLevel = 99;
        private static int CurrentXp = (int)Helpers.LevelToXp(99);

        static void Main(string[] args)
        {
            //LevelGuideHighestLevelSpot();
            LevelGuideTetracompassPath();
            return;

        }

        /// <summary>
        /// Calculate how many artifacts need to be restored from which spots in order to reach 120.
        /// Most 1-99 excavation spots are no included in this program because I'm already 99 so too bad.
        /// The Lower level spots can always be added to the ExcavationSpots.cs file in the future.
        /// </summary>
        private static void LevelGuideHighestLevelSpot()
        {
            // These are the potential spots that will be excavated along the way.
            List<ExcavationHotspot> spots = new List<ExcavationHotspot>
            {
                ExcavationSpots.OikosFishingHutRemnants,
                ExcavationSpots.DisOVerspill,
                ExcavationSpots.AcropolisDebris,
                ExcavationSpots.GoblinTraineeRemains,
                ExcavationSpots.ByzrothRemains,
                ExcavationSpots.DestroyedGolem,
                ExcavationSpots.IcyeneWeaponRack,
                ExcavationSpots.CulinarumDebris,
                ExcavationSpots.KyzajChampionsBoudoir,
                ExcavationSpots.KeshikWeaponRack,
                ExcavationSpots.HellfireForge,
                ExcavationSpots.WarforgeScrapPile,
                ExcavationSpots.StockpiledArt,
                ExcavationSpots.AncientMagickMunitions,
                ExcavationSpots.BibliothekeDebris,
                ExcavationSpots.ChthonianTrophies,
                ExcavationSpots.WarforgeWeaponRack,
                ExcavationSpots.FlightResearchDebris,
                ExcavationSpots.AetheriumForge,
                ExcavationSpots.PraetorianRemains,
                ExcavationSpots.BandosSanctumDebris,
                ExcavationSpots.TsutsarothRemains,
                ExcavationSpots.OptimatoiRemains,
                ExcavationSpots.WarTableDebris,
                ExcavationSpots.HowlsWorkshopDebris,
                ExcavationSpots.MakeshiftPieOven
            };

            // Filter out some spots that may not be worth doing like the three level 100 spots, its probably best to only do the single best xp spot at lvl 100 instead of all 3
            // Build a sorted dictionary with key = spot level so that only the highest xp spot per level is left
            Dictionary<ExcavationSite, int> sitePriorities = new Dictionary<ExcavationSite, int> { { ExcavationSite.Warforge, 5 }, { ExcavationSite.KharidEt, 4 }, { ExcavationSite.Everlight, 3 }, { ExcavationSite.InfernalSource, 2 }, { ExcavationSite.StormguardCitadel, 1 } };
            SortedDictionary<int, ExcavationHotspot> spotByLevel = new SortedDictionary<int, ExcavationHotspot>();
            foreach (ExcavationHotspot spot in spots)
            {
                // Set xp modifier to 6% for master archaeology outfit.
                spot.XpGainedFromArtifactSet = spot.CalculateXpGainedFromRestoringSet(1.06);
                if (spotByLevel.ContainsKey(spot.LevelReq))
                {
                    // only replace the existing spot if the current one has higher priority.
                    if (sitePriorities[spot.Site] > sitePriorities[spotByLevel[spot.LevelReq].Site])
                    {
                        spotByLevel[spot.LevelReq] = spot;
                    }
                }
                else
                {
                    spotByLevel[spot.LevelReq] = spot;
                }
            }

            // determine how many sets of artifact restorations are necessary to get from the level of the current spot to the next, or if at the end, lvl 120.
            List<ExcavationHotspot> orderedSpots = spotByLevel.Values.ToList();
            int tot = 0, port = 0, imp = 0;
            for (int i = 0; i < orderedSpots.Count; i++)
            {
                ExcavationHotspot currentSpot = orderedSpots[i];
                int startLevel = orderedSpots[i].LevelReq;
                int endLevel = i + 1 >= orderedSpots.Count ? 120 : orderedSpots[i + 1].LevelReq;
                if (endLevel <= CurrentLevel)
                {
                    continue;
                }

                long xpRequired = Helpers.LevelToXp(endLevel) - Math.Max(CurrentXp, Helpers.LevelToXp(Math.Max(startLevel, CurrentLevel)));
                int setsRequired = (int)Math.Ceiling(xpRequired / orderedSpots[i].XpGainedFromArtifactSet);

                // Calculate the materials required to restore
                Dictionary<MaterialType, Tuple<int, int>> materials = new Dictionary<MaterialType, Tuple<int, int>>();
                foreach (MaterialEntry mat in currentSpot.PotentialMats)
                {
                    materials[mat.Type] = new Tuple<int, int>(0, (int)(mat.Chance * currentSpot.MaterialsPerSet * setsRequired));
                }

                foreach (KeyValuePair<MaterialType, int> kvp in currentSpot.RequiredMaterails)
                {
                    if (materials.ContainsKey(kvp.Key))
                    {
                        materials[kvp.Key] = new Tuple<int, int>(kvp.Value * setsRequired, materials[kvp.Key].Item2);
                    }
                    else
                    {
                        materials[kvp.Key] = new Tuple<int, int>(kvp.Value * setsRequired, 0);
                    }
                }

                Console.WriteLine($"{currentSpot.LevelReq}-{currentSpot.Name} => Requires {setsRequired} sets. ({setsRequired * currentSpot.ArtifactCount} artifacts)");
                Console.WriteLine($"{"Material",20}  {"Required",8}  {"From Hotspot",12}  {"From Cache",10}");
                int total = 0;
                foreach (KeyValuePair<MaterialType, Tuple<int, int>> kvp in materials)
                {
                    Console.WriteLine($"{kvp.Key.ToString(),20}  {kvp.Value.Item1,8}  {kvp.Value.Item2,12}  {kvp.Value.Item1 - kvp.Value.Item2,10}");
                    total += kvp.Value.Item1;
                }
                tot += total;
                port += (int)Math.Ceiling(total * 0.804);
                imp += (int)Math.Floor(total * 0.196);
                Console.WriteLine($"{"Total",20}  {total,8}  {$"{Math.Ceiling(total * 0.804)} (porter)",12}  {$"{Math.Floor(total * 0.196)} (imp)",10}");
                Console.WriteLine();
            }

            Console.WriteLine($"{"Total",20}  {tot,8}  {$"{port} (porter)",12}  {$"{imp} (imp)",10}");
            Console.ReadKey();
        }

        /// <summary>
        /// Calculate how many Arch collections that reward tetracompass pieces should be completed to get from 99-120.
        /// All the other collection reward pretty garbage stuff so these are the only ones really worth repeating.
        /// The lower level tetracompass collections are ignored so, get to 99 before following this guide.
        /// </summary>
        private static void LevelGuideTetracompassPath()
        {
            // SARA 3
            ArchCollection Sara3 = new ArchCollection(new List<ExcavationHotspot>
            {
                ExcavationSpots.OikosFishingHutRemnants,
                ExcavationSpots.AcropolisDebris,
                ExcavationSpots.IcyeneWeaponRack
            },
            "Saradominist III");

            // SARA 4
            ArchCollection Sara4 = new ArchCollection(new List<ExcavationHotspot>
            {
                ExcavationSpots.StockpiledArt,
                ExcavationSpots.BibliothekeDebris,
                ExcavationSpots.OptimatoiRemains
            },
            "Saradominist IV");

            // ZAM 3
            ArchCollection Zammy3 = new ArchCollection(new List<ExcavationHotspot>
            {
                ExcavationSpots.DisOVerspill,
                ExcavationSpots.ByzrothRemains,
                ExcavationSpots.HellfireForge
            },
            "Zamorakian III");

            // ZAM 4
            ArchCollection Zammy4 = new ArchCollection(new List<ExcavationHotspot>
            {
                ExcavationSpots.ChthonianTrophies,
                ExcavationSpots.TsutsarothRemains,
            },
            "Zamorakian IV");

            // This one is wonky af
            // RR2 + GG3
            ArchCollection RR2AndGG3 = new ArchCollection(new List<ExcavationHotspot>
            {
                ExcavationSpots.GoblinTraineeRemainsRR2, // must be modified, dont need to repair the anchors
                ExcavationSpots.KyzajChampionsBoudoir,
                ExcavationSpots.WarforgeScrapPile,
                ExcavationSpots.WarforgeWeaponRack,
                ExcavationSpots.MakeshiftPieOven,
            },
            "Red Rum Relics II + Green Gobbo Goodies III");

            ArchCollection RR3 = new ArchCollection(new List<ExcavationHotspot>
            {
                ExcavationSpots.BandosSanctumDebris,
                ExcavationSpots.MakeshiftPieOvenBossManOnly // must be modified, don't need to repair the cooking pots
            },
            "Red Rum Relics III");

            List<ArchCollection> collections = new List<ArchCollection> { Sara3, Sara4, Zammy3, Zammy4, RR2AndGG3, RR3 };
            while(true)
            {
                double finalXp = ComputeFinalXp(collections, (double)CurrentXp, out double xpShortfall);
                int finalLevel = Helpers.XpToLevel((long)finalXp);
                if (finalLevel >= 120)
                {
                    break;
                }

                foreach(ArchCollection collection in collections)
                {
                    collection.XpFromSpotAtOrBelow = collection.GetXpFromSpotsAtOrBelowLevel(finalLevel);
                    collection.XpPerArtifact = collection.GetAverageXpPerArtifact(finalLevel);
                }

                ArchCollection bestCollection = collections.OrderByDescending(k => k.XpFromSpotAtOrBelow).First();
                bestCollection.RestorationCount += (int)Math.Ceiling(xpShortfall / bestCollection.XpFromSpotAtOrBelow);
            }

            List<SpotRestorations> orderedSpots = new List<SpotRestorations>();
            // order all excavation hotspots by level
            foreach (ArchCollection col in collections)
            {
                if (col.RestorationCount == 0)
                {
                    continue;
                }

                Console.WriteLine($"Restore {col.RestorationCount,6} - {$"{col.Name}",12}");
                foreach (ExcavationHotspot spot in col.SpotsInCollection)
                {
                    orderedSpots.Add(new SpotRestorations { Spot = spot, RestoreCount = col.RestorationCount });
                }
            }

            orderedSpots = orderedSpots.OrderBy(k => k.Spot.LevelReq).ToList();
            PrintSummary(orderedSpots);
        }

        /// <summary>
        /// Semi-pretty print the results to the console.
        /// </summary>
        /// <param name="spots"></param>
        private static void PrintSummary(List<SpotRestorations> spots)
        {
            int tot = 0, port = 0, imp = 0;
            foreach (SpotRestorations spot in spots)
            {
                // Calculate the materials required to restore
                Dictionary<MaterialType, Tuple<int, int>> materials = new Dictionary<MaterialType, Tuple<int, int>>();
                foreach (MaterialEntry mat in spot.Spot.PotentialMats)
                {
                    materials[mat.Type] = new Tuple<int, int>(0, (int)(mat.Chance * spot.Spot.MaterialsPerSet * spot.RestoreCount));
                }

                foreach (KeyValuePair<MaterialType, int> kvp in spot.Spot.RequiredMaterails)
                {
                    if (materials.ContainsKey(kvp.Key))
                    {
                        materials[kvp.Key] = new Tuple<int, int>(kvp.Value * spot.RestoreCount, materials[kvp.Key].Item2);
                    }
                    else
                    {
                        materials[kvp.Key] = new Tuple<int, int>(kvp.Value * spot.RestoreCount, 0);
                    }
                }

                Console.WriteLine($"{spot.Spot.LevelReq}-{spot.Spot.Name} => Requires {spot.RestoreCount} sets. ({spot.RestoreCount * spot.Spot.ArtifactCount} artifacts)");
                Console.WriteLine($"{"Material",20}  {"Required",8}  {"From Hotspot",12}  {"From Cache",10}");
                int total = 0;
                foreach (KeyValuePair<MaterialType, Tuple<int, int>> kvp in materials)
                {
                    Console.WriteLine($"{kvp.Key.ToString(),20}  {kvp.Value.Item1,8}  {kvp.Value.Item2,12}  {kvp.Value.Item1 - kvp.Value.Item2,10}");
                    total += kvp.Value.Item1;
                }
                tot += total;
                port += (int)Math.Ceiling(total * 0.804);
                imp += (int)Math.Floor(total * 0.196);
                Console.WriteLine($"{"Total",20}  {total,8}  {$"{Math.Ceiling(total * 0.804)} (porter)",12}  {$"{Math.Floor(total * 0.196)} (imp)",10}");
                Console.WriteLine();
            }

            Console.WriteLine($"{"Total",20}  {tot,8}  {$"{port} (porter)",12}  {$"{imp} (imp)",10}");
            Console.ReadKey();
        }

        /// <summary>
        /// Given a list of arch collections and how many you intend on completing, along with your starting XP value, compute how much XP you gain,
        /// and how much xp is required to hit the next level milestone.
        /// </summary>
        /// <param name="collections">
        /// The list of all arch collections that reward tetracompass pieces, and how many times you inted to complete each one.
        /// </param>
        /// <param name="initialXp">
        /// Your starting XP. If you are under level 84 this method will always fail as thats the lowest level excavation spot I have added.
        /// </param>
        /// <param name="xpShortfall">
        /// How much XP is required after the spcified collections have been completed, to get to the next excavation spot.
        /// </param>
        /// <returns>
        /// How much xp you will have total after all the collections have been completed.
        /// </returns>
        private static double ComputeFinalXp(List<ArchCollection> collections, double initialXp, out double xpShortfall)
        {
            xpShortfall = 0;
            List<SpotRestorations> orderedSpots = new List<SpotRestorations>();
            // order all excavation hotspots by level
            foreach(ArchCollection col in collections)
            {
                foreach(ExcavationHotspot spot in col.SpotsInCollection)
                {
                    orderedSpots.Add(new SpotRestorations { Spot = spot, RestoreCount = col.RestorationCount });
                }
            }

            orderedSpots = orderedSpots.OrderBy(k => k.Spot.LevelReq).ToList();
            foreach(SpotRestorations spot in orderedSpots)
            {
                int currentLevel = Helpers.XpToLevel((long)initialXp);
                if (spot.Spot.LevelReq <= currentLevel)
                {
                    initialXp += spot.Spot.XpGainedFromArtifactSet * spot.RestoreCount;
                }
                else
                {
                    xpShortfall = Helpers.LevelToXp(spot.Spot.LevelReq) - initialXp;
                    break;
                }
            }

            return initialXp;
        }
    }
}
