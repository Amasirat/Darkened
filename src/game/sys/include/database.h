#ifndef DATABASE_H
#define DATABASE_H
#include <vector>
#include <filesystem>
#include <string>
namespace fs = std::filesystem;
//reads corresponding row in database, parses it, and returns it as a string vector, 
std::vector<std::string> get_database_row(const fs::path& db_path, int id);
#endif