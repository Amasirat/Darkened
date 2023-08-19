#include "random.h"
#include "global.h"
#include <random>
#include <chrono>
//default constructor
Random::Random() :
m_lower_limit{game::random_lower_limit},
m_upper_limit{game::random_upper_limit}
{
    initialize();
}
//default value constructor
Random::Random(int lower, int upper) : 
m_lower_limit{lower},
m_upper_limit{upper}
{
    initialize();
}
//initializer
void Random::initialize()
{
    m_seed = (unsigned long)std::chrono::steady_clock::now().
    time_since_epoch().count();
}
//generate random number and return that number
int Random::generate() const
{
    std::mt19937 mt(m_seed);
    std::uniform_int_distribution die{m_lower_limit, m_upper_limit};
    return die(mt);
}