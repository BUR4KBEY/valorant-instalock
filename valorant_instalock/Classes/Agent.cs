using System.Collections.Generic;
using System.Linq;
using valorant_instalock.Models;

namespace valorant_instalock.Classes
{
    public static class Agent
    {
        public static Coordinate SelectedAgent { get; set; }

        public static Dictionary<string, Coordinate> agentCoordinates = new Dictionary<string, Coordinate>
        {
            { "clove", new Coordinate(1296, 931) },
            { "astra", new Coordinate(545, 927) },
            { "breach", new Coordinate(629, 932) },
            { "brimstone", new Coordinate(714, 934) },
            { "chamber", new Coordinate(792, 922) },
            { "cypher", new Coordinate(895, 917) },
            { "fade", new Coordinate(968, 935) },
            { "jett", new Coordinate(1050, 925) },
            { "kayo", new Coordinate(1151, 927) },
            { "killjoy", new Coordinate(1215, 924) },
            { "neon", new Coordinate(1311, 917) },
            { "omen", new Coordinate(1384, 930) },
            { "phoenix", new Coordinate(534, 1016) },
            { "raze", new Coordinate(634, 1011) },
            { "reyna", new Coordinate(713, 1004) },
            { "sage", new Coordinate(799, 1010) },
            { "skye", new Coordinate(888, 996) },
            { "sova", new Coordinate(949, 1004) },
            { "viper", new Coordinate(1047, 998) },
            { "yoru", new Coordinate(1111, 1011) },
            { "gekko", new Coordinate(1229, 998) },
            { "harbor", new Coordinate(1319, 993) }
        };

        public static Coordinate GetAgentCoordinatesByName(string agentName)
        => agentCoordinates.Where(c => c.Key == agentName).Select(c => c.Value).FirstOrDefault();

        public static string GetAgentNameByCoordinates(int X, int Y)
        => agentCoordinates.Where(c => c.Value.X == X && c.Value.Y == Y).Select(c => c.Key).FirstOrDefault();

        public static string[] getAgents()
        => agentCoordinates.Keys.ToArray();
    }
}
