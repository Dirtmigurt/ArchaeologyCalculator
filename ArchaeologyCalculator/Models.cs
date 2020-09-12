using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArchaeologyCalculator
{
    /// <summary>
    /// Enum containing all possible material types.
    /// </summary>
    public enum MaterialType
    {
        ThirdAgeIron,
        ZarosianInsignia,
        SamiteSilk,
        ImperialSteel,
        WhiteOak,
        Goldrune,
        Orthenglass,
        Vellum,
        CadmiumRed,
        AncientVis,
        TyrianPurple,
        LeatherScraps,
        ChaoticBrimstone,
        Demonhide,
        EyeOfDagon,
        HellfireMetal,
        Keramos,
        WhiteMarble,
        CobaltBlue,
        Silvthril,
        StarOfSaradomin,
        BloodOfOrcus,
        StormguardSteel,
        WingsOfWar,
        AnimalFurs,
        ArmadyleanYellow,
        MalachiteGreen,
        MarkOfTheKyzaj,
        VulcanizedRubber,
        WarforgedBronze,
        FossilizedBone,
        YubiuskClay,
        AetheriumAlloy,
        Quintessence,
        Soapstone
    };

    /// <summary>
    /// Enum containing all possible excavation sites. RIP Orthen in a month.
    /// </summary>
    public enum ExcavationSite
    {
        KharidEt,
        InfernalSource,
        Everlight,
        StormguardCitadel,
        Warforge
    }

    /// <summary>
    /// Object used to hold the type of material and its chance of excavation from a hotspot.
    /// </summary>
    public class MaterialEntry
    {
        public MaterialType Type { get; set; }

        public double Chance { get; set; }
    }

    /// <summary>
    /// Object used to hold all useful information about an excavation hostpot.
    /// </summary>
    public class ExcavationHotspot
    {
        /// <summary>
        /// The name of the excavation site
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The level required to dig at the excavation site.
        /// </summary>
        public int LevelReq { get; set; }

        /// <summary>
        /// How much xp is gained from successfully excavating a material at this site.
        /// </summary>
        public double XpMaterial { get; set; }

        /// <summary>
        /// How much xp is gained from failing to find a material at this site.
        /// </summary>
        public double XpFail { get; set; }

        /// <summary>
        /// How much xp is gained from discovering an artifact at this site.
        /// </summary>
        public double XpArtifact { get; set; }

        /// <summary>
        /// How much xp do the artifacts at this site provide when restored.
        /// </summary>
        public double XpRestoration { get; set; }

        /// <summary>
        /// How many unique artifacts can be found at this site.
        /// </summary>
        public int ArtifactCount { get; set; }

        /// <summary>
        /// How many of the artifacts from this site are you interested in restoring.
        /// </summary>
        public int UsedArtifactCount { get; set; } = int.MaxValue;

        /// <summary>
        /// The location of this excavations ite.
        /// </summary>
        public ExcavationSite Site { get; set; }

        /// <summary>
        /// The potential materials that can be found while excavating this site.
        /// </summary>
        public List<MaterialEntry> PotentialMats { get; set; }

        /// <summary>
        /// The type and amount of materials required to restore 1 of each of the unique artifacts in this site that you are interested in restoring (UsedArtifactCount).
        /// </summary>
        public Dictionary<MaterialType, int> RequiredMaterails { get; set; }

        /// <summary>
        /// How much XP will you gan from excavating and restoring all artifacts from this set that you are interested in.
        /// </summary>
        public double XpGainedFromArtifactSet { get; set; }

        /// <summary>
        /// Calculate the XP gained from restoring the artifacts from the site that you are interested in.
        /// Also compute how many successful material rolls you will have while excavating a full set of artifacts.
        /// </summary>
        /// <param name="xpModifier">
        /// XP Modifier for things like Master Arch outfit, clan avatar, pulse core, dxp weekend, bonus xp, etc.
        /// </param>
        /// <returns>
        /// Total XP from a full set of artifacts.
        /// </returns>
        public double CalculateXpGainedFromRestoringSet(double xpModifier = 1.0)
        {
            // What is the xp from restoring the set of artifacts
            double restoreXp = this.XpRestoration * Math.Min(this.ArtifactCount, this.UsedArtifactCount);

            // How many seconds will it take to excavate the set of artifacts?
            double t = 3600.0 * (this.ArtifactCount / 10.0);
            double attempts = t / 2.4; // attempt is made to excavate a material every 4 ticks (2.4) seconds.

            // Mattock of Time/Space + Master outfit gave these success/fail percentages at Culinarioum debris
            double excavateXp = (0.32 * attempts * this.XpMaterial) + (0.68 * attempts * this.XpFail) + (this.XpArtifact * this.ArtifactCount);
            this.MaterialsPerSet = (int)(0.32 * attempts);
            double tomeXp = (2 * this.LevelReq) / 250000.0;
            tomeXp = Helpers.TomeXpList[this.LevelReq] * attempts * 0.32 * tomeXp;
            return ((restoreXp + excavateXp) * xpModifier) + tomeXp;
        }

        /// <summary>
        /// The number of materials you will have found while digging up all artifacts in a set.
        /// </summary>
        public int MaterialsPerSet { get; set; }
    }

    /// <summary>
    /// Holds an excavation site, and the number of times you intend to fully restore each artifact at that site.
    /// </summary>
    public class SpotRestorations
    {
        /// <summary>
        /// An excavation site.
        /// </summary>
        public ExcavationHotspot Spot { get; set; }

        /// <summary>
        /// How many times you want to restore each of the artifacts found at the site.
        /// </summary>
        public int RestoreCount { get; set; }
    }

    /// <summary>
    /// Contains all of the useful information about an arch collection in one object.
    /// </summary>
    public class ArchCollection
    {
        /// <summary>
        /// A List of all of the excavation sites you will need to dig at to complete the collection.
        /// </summary>
        public List<ExcavationHotspot> SpotsInCollection { get; set; }

        /// <summary>
        /// The name of the collection (ex. Saradominist IV)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Number of times this collection should be completed.
        /// </summary>
        public int RestorationCount { get; set; } = 0;

        /// <summary>
        /// The XP gained from excavating+restoring all of the artifacts that are available at your level.
        /// If the lowest level artifact in the collection is 115, and you are only level 99, this will be 0.
        /// </summary>
        public double XpFromSpotAtOrBelow { get; set; } = 0;

        /// <summary>
        /// The average XP gained per artifact in the collection. Some collections span almost 30 levels and the difference between the high/low XP rates can be large.
        /// </summary>
        public double XpPerArtifact { get; set; } = 0;

        /// <summary>
        /// Constructor to fill in the collection information.
        /// </summary>
        /// <param name="spots"></param>
        /// <param name="name"></param>
        public ArchCollection(IList<ExcavationHotspot> spots, string name)
        {
            this.SpotsInCollection = new List<ExcavationHotspot>(spots);
            this.Name = name;
            foreach(ExcavationHotspot spot in spots)
            {
                spot.XpGainedFromArtifactSet = spot.CalculateXpGainedFromRestoringSet(1.06);
            }
        }

        /// <summary>
        /// Add up all of the XP gains in the collection that you can complete at the specified level.
        /// </summary>
        /// <param name="level">
        /// Your current Arch level.
        /// </param>
        /// <returns>
        /// XP Gained from completing the collection UP TO your level.
        /// </returns>
        public double GetXpFromSpotsAtOrBelowLevel(int level)
        {
            double xp = 0.0;
            int artifacts = 0;
            foreach(ExcavationHotspot spot in this.SpotsInCollection)
            {
                if (spot.LevelReq <= level)
                {
                    xp += spot.XpGainedFromArtifactSet;
                    artifacts += spot.ArtifactCount;
                }
            }

            return xp;
        }

        /// <summary>
        /// Add up all of the XP gains in the collection  that you can complete at the specified level, and divide it by the 
        /// number of artifacts that were part of that calculation.
        /// </summary>
        /// <param name="level">
        /// Your current arch level.
        /// </param>
        /// <returns>
        /// Average XP gained from completing a single artifact in the collection.
        /// </returns>
        public double GetAverageXpPerArtifact(int level)
        {
            double xp = 0.0;
            int artifacts = 0;
            foreach (ExcavationHotspot spot in this.SpotsInCollection)
            {
                if (spot.LevelReq <= level)
                {
                    xp += spot.XpGainedFromArtifactSet;
                    artifacts += spot.ArtifactCount;
                }
            }

            return xp / Math.Max(1, artifacts);
        }
    }

    /// <summary>
    /// Miscellaneous helper methods for random things.
    /// </summary>
    public static class Helpers
    {
        /// <summary>
        /// List of XP Values that Arch tomes give at each level.
        /// </summary>
        private static string tomeXpString = "0,300,331.2,369.6,408,447.6,499.2,590.4,609.6,932.4,736.8,816,902.4,986.4,1099.20,1209.60,1255.20,1315.20,1368,1430.40,1488,1557.60,1617.60,1689.60,1764,1843.20,1915.20,1945.20,1987.20,2174.40,2270.40,2367.60,2467.20,2572.80,2684.40,2798.40,2920.80,3048,3177.60,3319.20,3458.40,3609.60,3765.60,3926.40,4096.80,4269.60,4459.20,4658.40,4860,5064,5284.80,5511.60,5760,5997.60,6261.60,6537.60,6825.60,7128,7420.80,7759.20,8084.40,8436,8810.40,9174,9621.60,10118.40,10423.20,11419.20,11856,12445.20,12926.40,13484.40,14143.20,14793.60,15426,16029.60,16776,17504.40,18202.80,19104,19996.80,20868,21704.40,22857.60,23608.80,24158.40,25802.40,26844,28428,29383.20,30968,31750,33257,34733,36156,38710,40068,41290,43299,45002,46704.50,48407,50109.50,51812,53514.50,55217,56919.50,58622,60324.50,62027,63729.50,65432,67134.50,68837,70539.50,72242,73944.50,75647,77351,80261,86561";

        /// <summary>
        /// List of XP Values that standard (non-elite) skills in RS follow.
        /// </summary>
        private static string levelXpString = "0,83,174,276,388,512,650,801,969,1154,1358,1584,1833,2107,2411,2746,3115,3523,3973,4470,5018,5624,6291,7028,7842,8740,9730,10824,12031,13363,14833,16456,18247,20224,22406,24815,27473,30408,33648,37224,41171,45529,50339,55649,61512,67983,75127,83014,91721,101333,111945,123660,136594,150872,166636,184040,203254,224466,247886,273742,302288,333804,368599,407015,449428,496254,547953,605032,668051,737627,814445,899257,992895,1096278,1210421,1336443,1475581,1629200,1798808,1986068,2192818,2421087,2673114,2951373,3258594,3597792,3972294,4385776,4842295,5346332,5902831,6517253,7195629,7944614,8771558,9684577,10692629,11805606,13034431,14391160,15889109,17542976,19368992,21385073,23611006,26068632,28782069,31777943,35085654,38737661,42769801,47221641,52136869,57563718,63555443,70170840,77474828,85539082,94442737,104273167";

        /// <summary>
        /// Break the tome xp string up and turn them into numbers.
        /// </summary>
        public static List<double> TomeXpList = tomeXpString.Split(',').Select(s => double.Parse(s)).ToList();

        /// <summary>
        /// Break the level xp string up and turn it into numbers.
        /// </summary>
        public static List<int> StandardXpList = levelXpString.Split(',').Select(s => int.Parse(s)).ToList();

        /// <summary>
        /// Convert a runscape level (1-120) into the minimum amount of experience you can have in the skill and still be that level.
        /// An example would be once you hit 83 xp in a skill you are now level 2, so giving level 2 into this function will return 83.
        /// </summary>
        /// <param name="level">
        /// The level you would like to convert to XP.
        /// </param>
        /// <returns>
        /// The minimum amount of XP it takes to reach the indicated level.
        /// </returns>
        public static long LevelToXp(int level)
        {
            if (level <= 0)
            {
                return 0;
            }

            level = Math.Min(120, level);
            return StandardXpList[level - 1];
        }

        /// <summary>
        /// Convert an amount of experience to a runescape level (1-120).
        /// For example having 85 experience puts you at level 2.
        /// Even though the list is only 120 items long, binary search the list for correct xp value.
        /// </summary>
        /// <param name="xp">
        /// The amount of XP you have in the skill.
        /// </param>
        /// <returns>
        /// The level that that amount of XP will get you.
        /// </returns>
        public static int XpToLevel(long xp)
        {
            int left = 0;
            int right = StandardXpList.Count - 1;
            int mid = right / 2;

            // terminate when StandardXpList[mid] <= xp AND StandardXpList[mid+1] > xp
            while(left < right)
            {
                if (StandardXpList[mid] <= xp && StandardXpList[mid + 1] > xp)
                {
                    return mid + 1;
                }
                else if (StandardXpList[mid] < xp)
                {
                    left = Math.Max(mid, left + 1);
                    mid = (left + right) / 2;
                }
                else
                {
                    right = Math.Min(mid, right - 1);
                    mid = (left + right) / 2;
                }
            }

            return mid + 1;
        }
    }
}
