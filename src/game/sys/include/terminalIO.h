#ifndef TERMINALIO_H
#define TERMINALIO_H
#include <string>
#include <string_view>
//clears terminal screen
void clrscreen();
//get user_integers from player
int int_input(std::string_view prompt);
//get generic string from user
std::string_view string_input(std::string_view prompt);

#endif