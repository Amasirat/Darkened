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
        Log() Default constructor
        clear() const   clears all files in log directory and starts from scratch
        write(const std::string&)   writes a message to log file

IMPORTANT: A Log class is not allowed to be copy constructed
WARNING: m_log_directory is also a static variable and will be unchanging as long as the session continues
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
//clear all log files
    void clear() const;
private:
    static std::string m_log_directory;
    static bool s_first_time;
};
#endif