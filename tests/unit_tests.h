#include "../src/random.h"
#include "../src/error.h"
#include <iostream>
int random_generate_test()
{
    Random dice{};
    return dice.generate();
}