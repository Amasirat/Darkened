#include "error.h"
#include "global.h"
#include "log.h"
#include "stat.h"
//system libs
#include <string>
#include <string_view>
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
    Log().write("ERROR:Stat::Value Limit Reached");
        throw Error("Value Limit Reached");
    }
    else if (m_current_value < 0)
    {
        m_current_value = 0;
    Log().write("ERROR:Stat::Invalid value reached");
        throw Error("Value Limit Reached");   
    }
}
//change stat size, pass in negative int to decrease and positive to increase stat size
void Stat::change_size(int change_by)
{
Log().write("changing a stat's size...");
    //temperory implementation, needs fixing
        m_size += change_by;
        m_current_value = m_size;
    
//additional error checking for when size reaches the higher limit defined in global.h and 0
    if(m_size > game::stat_limit)
    {
        m_size = game::stat_limit;
        Log().write("ERROR: Stat::change_size::m_size reached higher limit");
        throw Error("Value Limit Reached(inside Stat class)");
    }
    else if(m_size < 0)
    {
        m_size = 0;
        Log().write("ERROR: Stat::change_size::m_size reached lower limit");
        throw Error("Value Limit Reached(inside Stat class)");
    }
}
//decrease stat size
void Stat::size_down(int decrease_by)
{
    if(decrease_by <= 0)
    {
        Log().write("ERROR:Stat::size_down() recieved negative int as input");
        throw Error("Invalid Value");
    }
    m_size -= decrease_by;
//we can't size down a Stat to below zero
    if(m_size < 0)
    {
        m_size = 0;
Log().write("Stat::size_down::m_size was 0 while attempting size down");
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
Log().write("Stat::stat values reset");
}
//set stat size
void Stat::set_size(int size)
{
    if(size <= 0)
    {
        Log().write("Stat::set_size()::Invalid Value");
        throw Error("Invalid Value");
    }
    
    m_size = size;
    m_current_value = m_size;
Log().write("Stat::set_size()::Stat size has been newly set");
}
//name of stat in std::string form
std::string_view Stat::name() const
{
    switch(m_name)
    {
        case hp:
            return "hp";
            break;
        case attack:
            return "attack";
            break;
        case agility:
            return "agility";
            break;
        case defense:
            return "defense";
            break;
        case luck:
            return "luck";
            break;
        default:
            Log().write("WARNING:Stat::undefined stat detected");
            return "undefined stat";
    }
}