#ifndef STAT_H
#define STAT_H
#include "elements.h"
class Stat
{
public:
//default zero-value constructor
    Stat(stat_name name);
//default value constructor
    Stat(stat_name name, int size);
//default destructor
    ~Stat();
//increase stat
    void increase(int increase_by);
//decrease stat
    void decrease(int decrease_by);
//reset current_value to maximum size
    void reset();
private:
    stat_name m_name{};
    int current_value{};
    int m_size{};
};
#endif