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
#include "enemy.h"
#include "log.h"
#include "stat.h"

int main()
{
    try
    {
        std::vector<int> stats{5,6,4,8};
        Enemy enemy{Enemy::dark_lurker, stats};

        while(true)
        {
            int x;
            std::cin >> x;
            Player player{"user", 400};
            player.level_up(Stat::defense);
        }
    }
    catch(const Error& error)
    {
        error.print();
    }
    catch(...)
    {
        std::cerr << "unknown error\n";
    }
    return 0;
}
