#include "unit_tests.h"
#include "test_case.h"
#include "../src/error.h"
#include <iostream>

int main()
{
    for(int i{0}; i < 10; ++i)
    {
        std::cout << random_generate_test() << '\n';
    }
    return 0;
}