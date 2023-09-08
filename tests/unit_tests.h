#include <iostream>
#include <vector>
#include <fstream>
std::vector<int> test_case{-2, 1, 2, 5, 7, 
9, 7, 45, 78, -48, -5, -45, -12, -14, -100};

void general_test_env()
{
    std::ofstream save_file("~/.local/share/darkened/player.csv");
    if(save_file.is_open()) 
    {
        std::cout << "File opened\n";
    }
    else 
    {
        std::cout << "File not opened\n";
    }
}