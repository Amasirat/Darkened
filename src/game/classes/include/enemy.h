#ifndef ENEMY_H
#define ENEMY_H
#include "stat.h"
#include "player.h"
#include "error.h"

#include <filesystem>
#include <vector>
#include <string>
namespace fs = std::filesystem;

class Player;
class Enemy
{
public:
//default constructor
    Enemy(const std::string& name, std::vector<int> stat_num);
//database reading constructor
    Enemy(const fs::path& database_dir = "../database/enemy.csv", int enemy_id = 1);
//default destructor
    ~Enemy() = default;
//attacking player
    bool attack(Player* player) const;

private:
//enemy name
    std::string m_name{};
//A series of stats that enemies possess
    std::vector<Stat> m_stats{
        Stat(Stat::hp),
        Stat(Stat::attack),
        Stat(Stat::defense),
        Stat(Stat::agility),
        Stat(Stat::luck)
    };
//translating stat to its corresponding vector index
    int translate_stat_name(Stat::stat_name stat) const
    {
        int stat_index{};
        switch(stat)
        {
            case Stat::hp:
                stat_index = 0;
                break;
            case Stat::attack:
                stat_index = 1;
                break;
            case Stat::defense:
                stat_index = 2;
                break;
            case Stat::agility:
                stat_index = 3;
                break;
            case Stat::luck:
                stat_index = 4;
                break;
            default:
                throw Error("undefined index recieved");
        }
        return stat_index;
    }
};
#endif