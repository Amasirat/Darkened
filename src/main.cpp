/*
||||         ||||        |||||      ||     ||   ||||||  ||||     || ||||||  ||||  
||  ||      ||  ||       ||   ||    ||    ||    ||      || ||    || ||      || ||
||   ||    ||    ||      ||    ||   ||  ||      ||      ||  ||   || ||      ||  ||
||   ||   ||||||||||     |||||||    ||||        ||||||  ||   ||  || ||||||  ||  ||
||  ||   ||        ||    ||   ||    ||  ||      ||      ||    || || ||      || ||
||||    ||          ||   ||    ||   ||    ||    ||||||  ||     |||| ||||||  ||||
*/
#include <iostream>
#include "player.h"
#include "battle.h"
#include "enemy.h"
#include "log.h"
#include "stat.h"

int main()
{
    Player* player = new Player("Amir", 2);
    
    std::cout << "You've encountered an enemy!!!\n";
    std::vector<int> stats{5,3,1,6,4};
    std::vector<Enemy*> enemies{
        new Enemy(Enemy::dark_lurker, stats),
        new Enemy(Enemy::dark_lurker, stats),
    };

    Battle* battle{new Battle(player, enemies)};
    bool battle_won{battle->battle_arena()};

    if(battle_won)
    {
        std::cout << "Congratulations!\n";
    }
    return 0;
}

