#include "stat.h"
#include "global.h"
#include "error.h"
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
//increase stat value
void Stat::increase(int increase_by)
{
    if(increase_by <= 0)
        throw Error("Invalid Value(number below zero)");
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
    if (decrease_by <= 0)
    {
        throw Error("Invalid Value");
    }
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
    if(increase_by <= 0)
        throw Error("Invalid Error(number below zero)");
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