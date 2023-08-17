#ifndef PLAYER_H
#define PLAYER_H
#include "armor.h"
#include "elements.h"
#include <vector>
class Player
{
public:
//default constructor
    Player();
//copy constructor(copying an object of this class is not allowed)
    Player(const Player& player) = delete;
//default destructor
    ~Player();
//decrease player stats, taking a stat enum vector to know which stat to decrease followed by how much to decrease
    void decrease_stats(const std::vector<stats>& stats_to_change, int diff_num);
//function to equip armor
    void equip_armor(const Armor& armor);
private:
//player stats
    int m_hp{};
    int m_attack{};
    int m_defense{};
    int m_agility{};
    int m_luck{};
//equipment
    Armor m_armor{};
};
#endif