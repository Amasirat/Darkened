#ifndef LOG_H
#define LOG_H
#include "error.h"
#include "global.h"

#include <string>
#include <filesystem>
/*
A loging class for handling game logs
it is designed to be created and used anonymously anywhere in the program
the s_first_time static bool variable dictates if the constructor can skip file creation
m_log_directory default value is listed in global.h
    methods:
        write(const std::string&) const   writes a message to log file

IMPORTANT: A Log class is not allowed to be copy constructed
*/
class Log
{
public:
//default constructor
    Log(const std::string& log_directory = sys::log_directory);
//default destructor
    ~Log() = default;
//copy constructor disabled
    Log(const Log& log) = delete;
//writing into log file
    void write(const std::string& message) const;
private:
    static std::string m_log_directory;
    static bool s_first_time;
};
#endif