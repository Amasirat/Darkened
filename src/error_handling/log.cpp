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
    std::string date{ctime(&now)};
    date.erase(date.find('\n', 0), 1);

    m_log_directory = log_directory + date;

    if(!fs::is_directory(m_log_directory))
    {
        fs::create_directory(log_directory);
    }
    //opening log file
    std::ofstream file(m_log_directory);
    file << date << " Created Log File";   
}
//writing into log file
void Log::write(const std::string& message) const
{
    std::fstream file(m_log_directory, std::ios::app);
    time_t now(time(0));
    std::string time{ctime(&now)};
    time.erase(time.find('\n', 0), 1);

    file << '\n' << time << ' ' << message;
    file.close();
}