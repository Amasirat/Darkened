#include "error.h"

#include <iostream>
//default value constructor
Error::Error(const std::string& error) :
m_error_message{error}
{}
//print error message on screen
void Error::print() const
{
    std::cerr << m_error_message << '\n';
}