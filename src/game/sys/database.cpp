#include "database.h"
#include "input_output.h"
#include "error.h"
#include "log.h"
#include "global.h"
#include <string>
#include <fstream>
#include <filesystem>
#include <vector>
//read stats from csv database and return parsed vector of elements
std::vector<std::string> get_database_row(const fs::path& db_path, int id)
{
Log().write("reading database...");
    std::ifstream database{db_path};
    if (!database) throw Error::FileNotFound;

//position for delimiter in order to get substring
    size_t position{0};
//database row reading var
    std::string row{};
//the id substring of each row
    std::string id_token{};
//bool to evaluate if while loop found desired row
    bool row_found{false};
//dummy database read to get rid of first line
    std::getline(database, row);

    while(database)
    {
        position = row.find(sys::delimiter);
        std::getline(database, row);
        id_token = row.substr(0, position);

        if (std::stoi(id_token) == id)
        {
            row_found = true;
            break;
        }
    }

    if(!row_found)
    {
        throw Error::DatabaseEntryNotFound;
    }
Log().write("parsing database row...");
    size_t delim_size{sys::delimiter.length()};
    std::vector<std::string> row_details{};
    while((position = row.find(sys::delimiter)) != std::string::npos)
    {
        std::string substring{};
        position = row.find(sys::delimiter);
        substring = row.substr(0, position);
        row_details.push_back(substring);
        row.erase(0, position + delim_size);
    }
    return row_details;  
}