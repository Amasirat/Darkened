#include "stat.h"
#include "global.h"
#include "error.h"
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
        throw Error("Reached Value Limit");
    }
}
//decrease stat value
void Stat::decrease(int decrease_by)
{
    m_current_value -= decrease_by;
    if(m_current_value < 0)
    {
        m_current_value = 0;
        throw Error("Reached Value Limit");
    }
}
//increase stat size
void Stat::size_up(int increase_by)
{
    m_size += increase_by;
    if(m_size > game::stat_limit)
    {
        m_size = game::stat_limit;
        throw Error("Value Limit Reached");
    }
}
//decrease stat size
void Stat::size_down(int decrease_by)
{
    m_size -= decrease_by;
//we can't size down a Stat to below zero
    if(m_size < 0)
    {
        m_size = 0;
        throw Error("Value Limit Reached");
    }

    if(m_current_value > m_size)
    {
        m_current_value = m_size;
    }
}
//reset current_value to maximum size
void Stat::reset()
{
    m_current_value = m_size;
}
//set stat size
void Stat::set_size(int size)
{
    m_size = size;
    if(m_current_value > m_size)
    {
        m_current_value = m_size;
    }
}