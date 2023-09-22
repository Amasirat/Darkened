#include "terminalIO.h"
#include <iostream>
#include "error.h"
#include "log.h"
//clears terminal screen
void clrscreen()
{
Log().write("cleared screen");
    #ifdef __linux__
        system("clear");
    #else if __windows__
        system("cls")
    #endif
}
//get user_integers from player
int int_input(std::string_view prompt)
{
Log().write("int_input called");
    std::cout << prompt << '\n';
    int usr_input{};
    if(std::cin >> usr_input && std::cin.fail() || usr_input < 0)
    {
        std::cin.ignore();
        std::cin.clear();
        std::string error_message{"int_input::ERROR:Input is invalid. "
        "Expected an Integer of non_negative value"};
        Log().write(error_message);
        throw Error(error_message);

    }
    return usr_input;
}