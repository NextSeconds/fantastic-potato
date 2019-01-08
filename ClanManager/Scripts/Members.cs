namespace ClanManager.Scripts
{
    public class Members
    {
        public string tag;
        public string name;
        public string role;
        public int expLevel;
        public League league;
        public int trophies;
        public int versusTrophies;
        public int clanRank;
        public int previousClanRank;
        public int donations;
        public int donationsReceived;

        public string GetRoleText()
        {
            string roleText = string.Empty;
            switch (role)
            {
                case "leader": roleText = "首领"; break;
                case "coLeader": roleText = "副首领"; break;
                case "admin": roleText = "长老"; break;
                case "member": roleText = "成员"; break;
                default: roleText = "未知"; break;
            }
            return roleText;
        }
    }
}
