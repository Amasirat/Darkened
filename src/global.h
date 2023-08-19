#ifndef GLOBAL_H
#define GLOBAL_H
//namespace for game related global variables like default stat size
//or default player levels, etc...
namespace game
{
//default starting size for Stat classes
   inline const int default_stat_size{5}; 
   inline const int stat_limit{200};
   inline const int random_upper_limit{50};
   inline const int random_lower_limit{1};
   inline const int level_limit{100};
};
//namespace for default system values like file
//directories, configs etc...
namespace sys
{

};

#endif