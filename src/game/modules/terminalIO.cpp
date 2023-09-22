#include "terminalIO.h"
#include <iostream>
//clears terminal screen
void clrscreen()
{
    #ifdef __linux__
        system("clear");
    #else if __windows__
        system("cls")
    #endif
}