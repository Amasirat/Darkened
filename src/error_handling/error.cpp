#include "error.h"

#include <iostream>
//default constructor
Error::Error(const exceptions& error_type) :
m_error_type{error_type}
{
    switch(error_type)
    {
        case FileNotFound:
            m_error_message = "ERROR: File not found ";
            break;
        case FileExists:
            m_error_message = "ERROR: File already exists";
            break;
        case InvalidInput:
            m_error_message = "ERROR: Invalid input";
            break;
        case DatabaseEntryNotFound:
            m_error_message = "ERROR: Did not find database entry";
            break;
        default:
            m_error_message = "ERROR: Unknown error occured";
    }
}
//default value constructor
Error::Error(const std::string& error) :
m_error_message{error}
{}
//print error message on screen
void Error::print() const
{
    std::cerr << m_error_message << '\n';
}