#include "../src/error.h"
#include "../src/stat.h"
#include <iostream>
#include <vector>
std::vector<int> test_case{1, 2, 5, 7, 
9, 7, 45, 78};
void general_test_env()
{
    Stat hp{Stat::defense, 10};
    try
    {
        for (auto test : test_case)
        {
            std::cout << "test case: " << test
            << "\n";
            hp.size_up(test);
            std::cout << hp.name() << "\nSize: " << 
            hp.size() << "\nvalue: " << 
            hp.current() << "\n\n";
        }
        hp.reset();
        std::cout << hp.name() << "\nSize: " << 
        hp.size() << "\nvalue: " << 
        hp.current() << "\n";

    }
    catch(const Error& error)
    {
        error.print();
    }
    
    
}