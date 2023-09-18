#include "player.h"
#include "stat.h"
#include "log.h"
#include "global.h"
#include "random.h"
#include "error.h"
#include "math.h"

#include <iostream>

//default constructor
Player::Player(const std::string& name, int level) : m_name{name},
m_level{level}
{
    Log().write("Player constructed");
}
//attack an enemy(it's unfinished)
void Player::attack() const
{
    Random rng{};
    int enemy_stat_decrease{((int)rng.generate() + m_stats[1].current()) * (int)log((double)m_stats[4].current())};
    std::cout << enemy_stat_decrease << '\n';
}            
//change player stats, taking a stat enum to know which stat to change, and how much.
//use neative numbers to decrease and positive numbers to increase
void Player::change_stats(Stat::stat_name stat_to_change, int diff_num)
{
    int index{translate_stat_name(stat_to_change)};
    m_stats[index].change(diff_num);
}
//increase player stat's size, taking a stat enum to know which stat to increase, and how much to increase
void Player::stat_size_change(Stat::stat_name stat_to_change, int diff_num)
{
    int stat_index{translate_stat_name(stat_to_change)};
    m_stats[stat_index].change_size(diff_num);

Log().write("player stat size changed");
}
//level up player, player levels up when a stat is increased
void Player::level_up(Stat::stat_name stat_to_change)
{
    if(m_level >= game::level_limit)
    {
        std::string message{"ERROR: Level limit has reached(Player level_up method)"};
        Log().write(message);
        return;
    }
    constexpr int increase_by{1};
    change_stats(stat_to_change, increase_by);
    ++m_level;
}