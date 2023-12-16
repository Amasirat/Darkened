#include "player.h"
#include <iostream>

void test_attack()
{
    Player player{};
    std::cout << player.attack() << '\n';
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

void test_change_stats();