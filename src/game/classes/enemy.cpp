#include "enemy.h"
#include "random.h"
#include "log.h"
#include "error.h"
#include "database.h"

#include <iostream>
#include <filesystem>
#include <string>
#include <fstream>
namespace fs = std::filesystem;
//default constructor
Enemy::Enemy(const std::string& name, std::vector<int> stat_num) :
m_name{name}
{
    const int needed_size{(int)m_stats.size()};
    if(needed_size != (int)stat_num.size())
    {
        Log().write("WARNING: vector size was either greater or smaller(enemy class constructor)");
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
Log().write("Constructing enemy...");
    std::vector<std::string> db_findings{get_database_row(database_dir, enemy_id)};
//if vector was greater than decided database length
    if(db_findings.size() != sys::db_item_count)
    {
        Log().write("WARNING: database inquiry returned an greater sized vector than expected");
        db_findings.resize(sys::db_item_count);
    }

    m_name = db_findings[1];
    for(int i{0}; i < m_stats.size(); ++i)
    {
        m_stats.at(i).set_size(std::stoi(db_findings[i + 2]));
    }
}
//attacking player
bool Enemy::attack(Player* player) const
{
    Random rng{};
    int hit_value{rng.generate() * m_stats.at(translate_stat_name(Stat::attack)).current()};
    bool player_is_alive{player->take_hit(hit_value)};
    return true;
}