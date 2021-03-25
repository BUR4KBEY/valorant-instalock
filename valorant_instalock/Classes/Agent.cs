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
            { "brimstone", new Coordinate(668, 926) },
            { "jett", new Coordinate(761, 927) },
            { "killjoy", new Coordinate(834, 921) },
            { "phoenix", new Coordinate(916, 924) },
            { "raze", new Coordinate(1006, 921) },
            { "reyna", new Coordinate(1091, 923) },
            { "sage", new Coordinate(1176, 927) },
            { "sova", new Coordinate(1247, 927) },
            { "astra", new Coordinate(667, 1003) },
            { "breach", new Coordinate(753, 1000) },
            { "cypher", new Coordinate(835, 1008) },
            { "omen", new Coordinate(921, 1003) },
            { "syke", new Coordinate(1011, 1008) },
            { "viper", new Coordinate(1093, 1005) },
            { "yoru", new Coordinate(1181, 1011) },
        };

        public static Coordinate GetAgentCoordinatesByName(string agentName)
        => agentCoordinates.Where(c => c.Key == agentName).Select(c => c.Value).FirstOrDefault();

        public static string GetAgentNameByCoordinates(int X, int Y)
        => agentCoordinates.Where(c => c.Value.X == X && c.Value.Y == Y).Select(c => c.Key).FirstOrDefault();

        public static string[] getAgents()
        => agentCoordinates.Keys.ToArray();
    }
}