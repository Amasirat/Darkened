#include "stat.h"
#include "global.h"
//default zero-value constructor
Stat::Stat(stat_name name) : 
m_name{name}, m_size{game::default_stat_size} 
{}
//default value constructor
Stat::Stat(stat_name name, int size) :
m_name{name}, m_size{size}
{}
//increase stat value
void Stat::increase(int increase_by)
{
    m_current_value += increase_by;
    if(m_current_value > m_size)
    {
        m_current_value = m_size;
    }
}
//decrease stat value
void Stat::decrease(int decrease_by)
{
    m_current_value -= decrease_by;
    if(m_current_value < 0)
    {
        m_current_value = 0;
    }
}
//increase stat size
void Stat::size_up(int increase_by)
{
    m_size += increase_by;
//potential error handling required 
//for exceeding limit
}
//decrease stat size
void Stat::size_down(int decrease_by)
{
    m_size -= decrease_by;
//potential error handling required 
//for exceeding limit 
}
//reset current_value to maximum size
void Stat::reset()
{
    m_current_value = m_size;
}