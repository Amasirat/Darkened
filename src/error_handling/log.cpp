#include "log.h"
#include "error.h"
#include <filesystem>
#include <fstream>
#include <iostream>
#include <string>
#include <ctime>//for getting unique names for log files using ctime method
namespace fs = std::filesystem;
//default constructor
Log::Log(const std::string& log_directory)
{
    //current time
    time_t now{time(0)};
    char* date{ctime(&now)};
    m_log_directory = log_directory + date;
    std::cout << m_log_directory << '\n';

    if(!fs::is_directory(m_log_directory))
    {
        fs::create_directory(log_directory);
    }
    //opening log file
    std::ofstream file(m_log_directory);
    file << date << " Created Log File";   
}
//clear all log files
void Log::clear() const
{
    fs::remove_all(m_log_directory);
}
//writing into log file
void Log::write_log(const std::string& message) const
{
    
}