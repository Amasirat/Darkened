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
    ~Stat() = default;
//increase stat value
    void increase(int increase_by);
//decrease stat value
    void decrease(int decrease_by);
//increase stat size
    void size_up(int increase_by);
//decrease stat size
    void size_down(int decrease_by);
//reset current_value to maximum size
    void reset();
private:
    stat_name m_name{};
    int m_current_value{};
    int m_size{};
};
#endif