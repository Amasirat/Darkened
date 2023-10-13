#include "enemy.h"
#include "random.h"
#include "log.h"
#include "error.h"

#include <iostream>
#include <filesystem>
#include <fstream>
namespace fs = std::filesystem;
//default constructor
Enemy::Enemy(const std::string& name, std::vector<int> stat_num) :
m_name{name}
{
    const int needed_size{(int)m_stats.size()};
    if(needed_size != (int)stat_num.size())
    {
        std::string message{"WARNING: vector size was either greater or smaller(enemy class constructor)"};
        Log().write(message);
        stat_num.resize(needed_size);
    }

    int stat_index{0};
    for(auto num : stat_num)
    {
        m_stats.at(stat_index).set_size(num);
        ++stat_index;
    }
}
//database reading constructor
Enemy::Enemy(const fs::path& database_dir, int enemy_id)
{
Log().write("Reading enemy Database...");

    if(!fs::is_directory(database_dir))
    {
        std::string error_message{"ERROR:database directory does not exist"};
        Log().write(error_message);
        throw Error(error_message);
    }
    std::fstream database{database_dir, std::ios::in};

}
//attacking player
bool Enemy::attack(Player* player) const
{
    Random rng{};
    int hit_value{rng.generate() * m_stats.at(translate_stat_name(Stat::attack)).current()};
    bool player_is_alive{player->take_hit(hit_value)};
    return true;
}