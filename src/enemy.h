#ifndef ENEMY_H
#define ENEMY_H
#include "stat.h"
#include "player.h"
#include <vector>
class Player;
class Enemy
{
public:
//enums representing all possible enemy types
    enum enemy_name
    {
        revengeful_crow,
    };
//default constructor
    Enemy(enemy_name name, std::vector<int> stat_num);
//default destructor
    ~Enemy();
//attacking players
    void attack(Player* player) const;

private:
//enemy name
    enemy_name m_name{};
//A series of stats that enemies possess
    std::vector<Stat> m_stats{
        Stat(Stat::hp),
        Stat(Stat::attack),
        Stat(Stat::defense),
        Stat(Stat::agility),
        Stat(Stat::luck)
    };
};
#endif