#ifndef PLAYER_H
#define PLAYER_H
#include "enemy.h"
#include "armor.h"
#include "stat.h"
#include "item.h"
#include "error.h"

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
    void attack() const;    
//change player stats, taking a stat enum to know which stat to change, and how much.
//use neative numbers to decrease and positive numbers to increase
    void change_stats(Stat::stat_name stat_to_change, int diff_num);
//increase player stat's size, taking a stat enum to know which stat to increase
//pass in negative number to decrease and positive number to increase
    void stat_size_change(Stat::stat_name stat_to_change, int diff_num);
//level up player
    void level_up(Stat::stat_name stat_to_change);
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

//functions only used by this class
//translating stat to its corresponding vector index
    int translate_stat_name(Stat::stat_name stat)
    {
        int stat_index{};
        switch(stat)
        {
            case Stat::hp:
                stat_index = 0;
                break;
            case Stat::attack:
                stat_index = 1;
                break;
            case Stat::defense:
                stat_index = 2;
                break;
            case Stat::agility:
                stat_index = 3;
                break;
            case Stat::luck:
                stat_index = 4;
                break;
            default:
                throw Error("undefined index recieved");
        }
        return stat_index;
    }
};
#endif