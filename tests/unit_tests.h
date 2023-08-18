#include "../src/stat.h"
#include "../src/error.h"
#include <iostream>
void stat_size_up_test(int parameter)
{
    Stat hitpoint{Stat::hp, 8};
    hitpoint.size_up(parameter);
    std::cout << hitpoint.size() << '\n';
}