#ifndef PLAYER_H
#define PLAYER_H

#include "armor.h"
#include "stat.h"
#include "item.h"
#include "enemy.h"

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
    Player(const std::string& name = "user", int level = 1);
//copy constructor(copying an object of this class is not allowed)
    Player(const Player& player) = delete;
//default destructor
    ~Player() = default;
//attack an enemy
    void attack(Enemy& enemy) const;
//decrease player stats, taking a stat enum vector to know which stat to decrease, and how much to decrease
    void decrease_stats(Stat::stat_name stat_to_change, int diff_num);
//increase player stats, taking a stat enum to know which stat to increase, and how much to increase
    void increase_stats(Stat::stat_name stat_to_change, int diff_num);
//level up player
    void level_up();
//function to equip armor
//void equip_armor(const Armor& armor);
//getters
//returns name of player
    std::string name() const
    { return m_name; }
//returns level of player
    int level() const
    { return m_level; }
private:
//name
    std::string m_name{};
//level
    int m_level{};
//player stats
    std::vector<Stat> m_stats{
        Stat{Stat::hp},
        Stat{Stat::attack},
        Stat{Stat::defense},
        Stat{Stat::agility},
        Stat{Stat::luck}
    };
//equipment
//Armor m_armor{};
//player items
//std::vector<Item*> m_items{};
};
#endif