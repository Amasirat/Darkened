#ifndef RANDOM_H
#define RANDOM_H
#include <iostream>
#include <random>
/*
Random class that wraps around the mersenne twister PRNG number generator algorithm

find function implementations in .cpp file of the same name in src directory
*/
class Random
{
public:
//default constructor
    Random();
//default value constructor
    Random(int lower, int upper);
//default destructor
    ~Random() = default;
//generate random number and return that number
    int generate() const;
private:
    unsigned long m_seed{};
    int m_lower_limit{};
    int m_upper_limit{};
//initializer
    void initialize();
};
#endif