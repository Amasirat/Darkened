#ifndef LOG_H
#define LOG_H
#include "error.h"
#include "global.h"

#include <string>
#include <filesystem>
/*
A loging class for handling game logs

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
//clear all log files
    void clear() const;
//writing into log file
    void write(const std::string& message) const;
private:
    std::string m_log_directory{};
};
#endif