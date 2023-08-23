#include "player.h"
#include "stat.h"
#include "global.h"
#include "error.h"

//default constructor
Player::Player(const std::string& name, int level) : m_name{name},
m_level{level}
{}
//decrease player stats, taking a stat enum vector to know which stat to decrease, and how much to decrease
void Player::decrease_stats(Stat::stat_name stat_to_change, int diff_num)
{
    switch(stat_to_change)
    {
        case Stat::hp:
            m_stats[0].decrease(diff_num);
            break;
        case Stat::attack:
            m_stats[1].decrease(diff_num);
            break;
        case Stat::defense:
            m_stats[2].decrease(diff_num);
            break;
        case Stat::agility:
            m_stats[3].decrease(diff_num);
            break;
        case Stat::luck:
            m_stats[4].decrease(diff_num);
            break;
        default:
            throw Error("Player recieved unknown stat literal\n");
    }
}
//increase player stats, taking a stat enum to know which stat to increase, and how much to increase
void Player::increase_stats(Stat::stat_name stat_to_change, int diff_num)
{
    switch(stat_to_change)
    {
        case Stat::hp:
            m_stats[0].increase(diff_num);
            break;
        case Stat::attack:
            m_stats[1].increase(diff_num);
            break;
        case Stat::defense:
            m_stats[2].increase(diff_num);
            break;
        case Stat::agility:
            m_stats[3].increase(diff_num);
            break;
        case Stat::luck:
            m_stats[4].increase(diff_num);
            break;
        default:
            throw Error("Player recieved unknown stat literal\n");
    } 
}
//level up player
void Player::level_up(Stat::stat_name stat_to_change)
{
    if(m_level == game::level_limit)
    {
        std::cerr << "Level Limit has Reached\n";
        return;
    }
    constexpr int increase_by{1};
    increase_stats(stat_to_change, increase_by);
    ++m_level;
}