using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClanManager.Scripts
{
    public class PlayerInfo
    {
        public string tag;
        public string name;
        public int townHallLevel;//大本营等级
        public int townHallWeaponLevel;//大本营武器等级（低于12本没有）
        public int expLevel;//经验值等级
        public int trophies;//当前奖杯
        public int bestTrophies;//最高奖杯
        public int warStars;//部落战星星数
        public int attackWins;//攻击获胜
        public int defenseWins;//防御获胜
        public int builderHallLevel;//建筑大师大本营等级
        public int versusTrophies;//夜奖杯
        public int bestVersusTrophies;//夜最高奖杯
        public int versusBattleWins;//夜获胜次数
        public string role;//职位
        public int donations;//捐兵
        public int donationsReceived;//收兵
        public Clan clan;
        public League league;
        public List<Achievements> achievements;
        public int versusBattleWinCount;
        public List<Troops> troops;
        public List<Heroes> heroes;
        public List<Spells> spells;
    }
}
