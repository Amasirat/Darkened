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
#include "database.h"
#include "enemy.h"
#include "log.h"
#include "global.h"
#include "stat.h"
#include "input_output.h"
namespace fs = std::filesystem;
int main()
{
    try
    {
        std::vector<std::string> row_details{get_database_row(sys::enemy_database, 3)};
        std::cout << row_details[1] << '\n';
    }
    catch(const Error::exceptions& e)
    {
        Error{e}.print();
    }


    return 0;
}

