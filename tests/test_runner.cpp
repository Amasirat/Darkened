#include "unit_tests.h"
#include <iostream>
#include <filesystem>
#include <fstream>
#include <ctime>

int main()
{
    time_t now = time(0);

    char* date_time = ctime(&now);
    std::ofstream file(date_time);
    return 0;
}