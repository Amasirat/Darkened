#include "player.h"
#include <iostream>
Player player{};

void test_attack()
{
    std::cout << player.attack() << '\n';
}

void test_change_stats()
{
    
}

void stat_size_change()
{

}

void test_level_up()
{

}

void test_take_hit()
{
    Player* player{new Player()};
    std::cout << "HP: " <<  player->hp() << '\n';
    player->take_hit(4);
    std::cout << "HP: " <<  player->hp() << '\n';
    player->take_hit(4);
    std::cout << "HP: " <<  player->hp() << '\n';
}