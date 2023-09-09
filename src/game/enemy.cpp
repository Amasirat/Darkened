#include "enemy.h"
#include "random.h"
#include <iostream>
//default constructor
Enemy::Enemy(enemy_name name, std::vector<int> stat_num) :
m_name{name}
{
    const int needed_size{(int)m_stats.size()};
    if(needed_size != 4)
    {
        std::cerr << "WARNING: vector size was not " << needed_size << '\n';
        stat_num.resize(needed_size);
    }

    int stat_index{0};
    for(auto num : stat_num)
    {
        m_stats.at(stat_index).set_size(num);
        ++stat_index;
    }
}
//attacking player


