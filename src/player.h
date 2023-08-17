#ifndef PLAYER_H
#define PLAYER_H

#include "armor.h"
#include "elements.h"
#include "stat.h"

#include <vector>
/*
Player Class

*/
class Player
{
public:
//default constructor
    Player();
//copy constructor(copying an object of this class is not allowed)
    Player(const Player& player) = delete;
//default destructor
    ~Player();
//decrease player stats, taking a stat enum vector to know which stat to decrease, and how much to decrease
    void decrease_stats(Stat stat_to_change, int diff_num);
//increase player stats, taking a stat enum to know which stat to increase, and how much to increase
    void increase_stats(Stat stat_to_change, int diff_num);
//function to equip armor
    void equip_armor(const Armor& armor);
private:
//player stats
    Stat m_hp{hp};
    Stat m_attack{attack};
    Stat m_defense{defense};
    Stat m_agility{agility};
    Stat m_luck{luck};
//equipment
    Armor m_armor{};
};
#endif