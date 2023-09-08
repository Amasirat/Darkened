#include "log.h"
#include "error.h"
#include <filesystem>
#include <fstream>
#include <string>
namespace fs = std::filesystem;
//static id to identify log of each unique session
int s_id{0};
//default constructor
Log::Log(const std::string& log_directory, const std::string& log_file) :
m_log_directory{log_directory}, 
m_log_file{log_file}
{
    if (fs::create_directory(log_directory))
    {
        std::string full_directory{log_directory + 
        log_file + 
        std::to_string(s_id)};

        std::ofstream log_file(full_directory);
    }
    else
        throw Error("Failed to create log directory");
}