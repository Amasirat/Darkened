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

    }
    catch(const Error::exceptions& e)
    {
        Error er{e};
        Log().write(er.error_message());
        er.print();
    }
    catch(...)
    {
        std::cout << "Unanticipated Error Occured!\n";
    }
    
    return 0;
}

