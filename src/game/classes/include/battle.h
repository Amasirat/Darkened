#ifndef FIGHT_H
#define FIGHT_H
#include "player.h"
#include "enemy.h"
#include <vector>
/*
Battle class tasked with managing fights with player and various enemies
*/
class Battle
{
//default constructor
Battle(Player* player, std::vector<Enemy> enemies);
//default destructor
~Battle();

private:
    Player* m_player{};
    std::vector<Enemy> m_enemies;
};
#endif