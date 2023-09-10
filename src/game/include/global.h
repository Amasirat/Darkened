#ifndef GLOBAL_H
#define GLOBAL_H
#include <string>
#include <filesystem>
//namespace for game related global variables like default stat size
//or default player levels, etc...
namespace game
{
//default starting size for Stat classes
   inline constexpr int default_stat_size{5}; 
   inline constexpr int stat_limit{200};
//default values for random related parameters
   inline constexpr int random_upper_limit{20};
   inline constexpr int random_lower_limit{0};

   inline constexpr int level_limit{100};
};
//namespace for default system values like file
//directories, configs etc...
namespace sys
{
   inline constexpr std::string log_directory{"../logs/"};
   #ifdef __linux__
   inline const std::string homedir{getenv("HOME")};
   #endif
};

#endif