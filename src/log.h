#ifndef LOG_H
#define LOG_H
#include "global.h"
#include "error.h"

#include <string>
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
//catch an Error class's error message and print it in log
    void catch_error(const Error& error);
private:
    static int s_id;
    std::string m_log_directory{};
};
#endif