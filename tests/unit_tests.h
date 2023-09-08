#include <iostream>
#include <vector>
#include <filesystem>
#include <string>
std::vector<int> test_case{-2, 1, 2, 5, 7, 
9, 7, 45, 78, -48, -5, -45, -12, -14, -100};
namespace fs = std::filesystem;
void general_test_env()
{
    std::string homedir{getenv("HOME")};
    std::cout << homedir << '\n';
    if(fs::create_directory(homedir + "/.local/share/darkened/")) 
    {
        std::cout << "File created\n";
    }
    else 
    {
        std::cout << "File not created\n";
    }
}