#ifndef RANDOM_H
#define RANDOM_H
#include <iostream>
#include <random>

/*
Random class that wraps around the mersenne twister psuedo-random number generator algorithm


find function implementations in .cpp file of the same name in src directory
*/
class Random
{
public:
//default constructor
    Random();
//default destructor
    ~Random();
//generate random number and return that number
    int generate() const;
private:

};
#endif