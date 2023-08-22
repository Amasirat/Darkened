#include "../src/error.h"
#include "../src/stat.h"
#include "../src/player.h"
#include <iostream>
#include <vector>
std::vector<int> test_case{1, 2, 5, 7, 
9, 7, 45, 78};
void general_test_env()
{
    Player player{"User", 1};
    try
    {
        std::cout << player.name() << "\nlevel: " << player.level() << '\n';
    }
    catch(const Error& error)
    {
        error.print();
    }
    
    
}