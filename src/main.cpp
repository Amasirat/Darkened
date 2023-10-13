/*
||||         ||||        |||||      ||     ||   ||||||  ||||     || ||||||  ||||  
||  ||      ||  ||       ||   ||    ||    ||    ||      || ||    || ||      || ||
||   ||    ||    ||      ||    ||   ||  ||      ||      ||  ||   || ||      ||  ||
||   ||   ||||||||||     |||||||    ||||        ||||||  ||   ||  || ||||||  ||  ||
||  ||   ||        ||    ||   ||    ||  ||      ||      ||    || || ||      || ||
||||    ||          ||   ||    ||   ||    ||    ||||||  ||     |||| ||||||  ||||
*/
#include <iostream>
#include <filesystem>
#include <fstream>
#include "player.h"
#include "battle.h"
#include "enemy.h"
#include "log.h"
#include "stat.h"
namespace fs = std::filesystem;
int main()
{
    std::ifstream database{"../database/enemies.csv"};
    if (!database)
    {
        std::cout << "couldn't\n";
        return -1;
    }
    while(database)
    {
        std::string row{};
        std::getline(database, row);

        std::cout << row << '\n';
    }
    return 0;
}

