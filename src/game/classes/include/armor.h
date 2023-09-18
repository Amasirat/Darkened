#ifndef ARMOR_H
#define ARMOR_H
#include "stat.h"
class Armor
{
public:
//list of all armor values in game equipable by both player and enemies as enum
    enum armor_name
    {
        none,
    };
//default non-value constructor(zero initializes all members)
    Armor();
//default value constructor
    Armor(armor_name name, Stat defense);
//default constructor
    ~Armor();
private:
    armor_name m_name{};
    Stat m_defense{Stat::defense};
};
#endif