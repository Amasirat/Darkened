#include "error.h"
#include "global.h"
#include "stat.h"
//system libs
#include <string>
//default zero-value constructor
Stat::Stat(stat_name name) : 
m_name{name}, m_size{game::default_stat_size},
m_current_value{game::default_stat_size}
{}
//default value constructor
Stat::Stat(stat_name name, int size) :
m_name{name}, m_size{size}, m_current_value{size}
{}

//change stat value. use negative numbers to decrease and positive numbers to increase
void Stat::change(int change_by)
{
    m_current_value += change_by;
    if(m_current_value > m_size)
    {
        m_current_value = m_size;
        throw Error("Value Limit Reached");
    }
    else if (m_current_value < 0)
    {
        m_current_value = 0;
        throw Error("Value Limit Reached");   
    }
}
//change stat size, pass in negative int to decrease and positive to increase stat size
void Stat::change_size(int change_by)
{
    //temperory implementation, needs fixing
        m_size += change_by;
        m_current_value = m_size;
    
//additional error checking for when size reaches the higher limit defined in global.h and 0
    if(m_size > game::stat_limit)
    {
        m_size = game::stat_limit;
        throw Error("Value Limit Reached(inside Stat class)");
    }
    else if(m_size < 0)
    {
        m_size = 0;
        throw Error("Value Limit Reached(inside Stat class)");
    }
}
//decrease stat size
void Stat::size_down(int decrease_by)
{
    if(decrease_by <= 0)
        throw Error("Invalid Value");
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
    if(size <= 0)
        throw Error("Invalid Value");
    m_size = size;
    m_current_value = m_size;

}
//name of stat in std::string form
std::string Stat::name() const
{
    switch(m_name)
    {
        case hp:
            return "hp";
        case attack:
            return "attack";
        case agility:
            return "agility";
        case defense:
            return "defense";
        case luck:
            return "luck";
        default:
            return "undefined stat";
    }
}