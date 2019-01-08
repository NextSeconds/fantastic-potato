using System;
using System.Collections.Generic;

namespace ClanManager.Scripts
{
    public class ClanInfo
    {
        public string tag;
        public string name;
        public Location location;
        public BadgeUrls badgeUrls;
        public int clanLevel;
        public int clanPoints;
        public int clanVersusPoints;
        public int members;
        public string type;
        public int requiredTrophies;
        public string warFrequency;
        public int warWinStreak;
        public int warWins;
        public int warTies;
        public int warLosses;
        public bool isWarLogPublic;
        public string description;
        public List<Members> memberList;
    }
}
