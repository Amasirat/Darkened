#ifndef PLAYER_H
#define PLAYER_H

#include "armor.h"
#include "stat.h"
#include "item.h"

#include <string>
#include <vector>
#include <string>
/*
Player Class

*/
class Player
{
public:
//default constructor
    Player(const std::string& name);
//copy constructor(copying an object of this class is not allowed)
    Player(const Player& player) = delete;
//default destructor
    ~Player() = default;
//decrease player stats, taking a stat enum vector to know which stat to decrease, and how much to decrease
    void decrease_stats(Stat::stat_name stat_to_change, int diff_num);
//increase player stats, taking a stat enum to know which stat to increase, and how much to increase
    void increase_stats(Stat::stat_name stat_to_change, int diff_num);
//function to equip armor
    void equip_armor(const Armor& armor);
private:
//name
    std::string m_name{};
//level
    int m_level{};
//player stats
    struct player_stats
    {
        Stat m_hp{Stat::hp};
        Stat m_attack{Stat::attack};
        Stat m_defense{Stat::defense};
        Stat m_agility{Stat::agility};
        Stat m_luck{Stat::luck};
    };
    player_stats m_stats{};
//equipment
    Armor m_armor{};
//player items
    std::vector<Item*> m_items{};
};
#endif