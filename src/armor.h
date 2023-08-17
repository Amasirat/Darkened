#ifndef ARMOR_H
#define ARMOR_H
#include "elements.h"
#include "stat.h"
class Armor
{
public:
//default non-value constructor(zero initializes all members)
    Armor();
//default value constructor
    Armor(armor_name name, Stat defense);
//default constructor
    ~Armor();
private:
    armor_name m_name{};
    Stat m_defense{defense};
};
#endif