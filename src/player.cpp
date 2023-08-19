#include "player.h"
#include "global.h"
#include "error.h"

//default constructor
Player::Player(const std::string& name) : m_name{name},
m_level{1}
{
}
//decrease player stats, taking a stat enum vector to know which stat to decrease, and how much to decrease
void Player::decrease_stats(Stat::stat_name stat_to_change, int diff_num)
{
    switch(stat_to_change)
    {
        case Stat::hp:
            m_stats.m_hp.decrease(diff_num);
            break;
        case Stat::attack:
            m_stats.m_attack.decrease(diff_num);
            break;
        case Stat::agility:
            m_stats.m_agility.decrease(diff_num);
            break;
        case Stat::defense:
            m_stats.m_defense.decrease(diff_num);
            break;
        case Stat::luck:
            m_stats.m_luck.decrease(diff_num);
            break;
        default:
            throw Error("Player recieved unknown stat literal\n");
    }
}