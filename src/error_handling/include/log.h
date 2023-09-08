#ifndef LOG_H
#define LOG_H
#include "error.h"
#include "global.h"

#include <string>
/*
A loging class for handling game logs

*/
class Log
{
public:
//default constructor
    Log(const std::string& log_directory = sys::log_directory, 
    const std::string& log_file = "log");
//default destructor
    ~Log() = default;
//copy constructor disabled
    Log(const Log& log) = delete;
//catch an Error class's error message and print it in log
    void catch_error(const Error& error) const;
//clear all log files
    void clear() const;
private:
    static int s_id;
    std::string m_log_directory{};
    std::string m_log_file{};
};
#endif