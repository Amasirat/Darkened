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
#include "log.h"
#include "stat.h"
int main()
{
    try
    {
        
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
