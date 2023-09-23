#include "log.h"
#include "error.h"

#include <filesystem>
#include <fstream>
#include <iostream>
#include <string>
//for getting unique names for log files and entries using ctime function
#include <ctime>
namespace fs = std::filesystem;
//static boolean to know if it's the first time log constructor was called in program session
bool Log::s_first_time{true};
//static file diretory left empty
std::string Log::m_log_directory{""};
//default constructor
Log::Log(const std::string& log_directory)
{
    if(s_first_time)
    {
//current time
        time_t now{time(0)};
        std::string date{ctime(&now)};
        date.erase(date.find('\n', 0), 1);
//create full directory if it does not exist
        if(!fs::is_directory(log_directory))
            fs::create_directory(log_directory);
        
        m_log_directory = log_directory + date + ".log";
//opening log file
        std::ofstream file(m_log_directory);
        file << date << " Created Log File";
        file.close(); 
        s_first_time = false;  
    }
}
//writing into log file
void Log::write(const std::string& message) const
{
//opening log file to append
    std::fstream file(m_log_directory, std::ios::app);

//generating string for current time
    time_t now(time(0));
    std::string time{ctime(&now)};
    time.erase(time.find('\n', 0), 1);

//writing to log file
    file << '\n' << time << ' ' << message;
    file.close();
}