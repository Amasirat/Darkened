#include "../src/error.h"
#include "../src/stat.h"
#include "../src/player.h"
#include <iostream>
#include <vector>
std::vector<int> test_case{-2, 1, 2, 5, 7, 
9, 7, 45, 78, -48, -5, -45, -12, -14, -100};

void general_test_env()
{
    Stat Hitpoint(Stat::hp, 5);
    try
    {
        for (auto test : test_case)
        {
            Hitpoint.change_size(test);
            std::cout << "Size: " << Hitpoint.size() << "\ncurrent: " << Hitpoint.current() << '\n';
        }
    }
    catch(const Error& error)
    {
        error.print();
    }
    
    
}