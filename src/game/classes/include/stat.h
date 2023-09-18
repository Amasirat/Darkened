#ifndef STAT_H
#define STAT_H
#include <string>
/*
Class for All Stats in game. 
Stats have a ceiling value where they can't go higher than which is called their size and 
their current value.

A Stat contains the definition of an enum type stat_name. Only use the contents of that enum to 
name different objects of type Stat. 
member functions:
    void increase(int): increase value of a given stat by an int variable
    void decrease(int): decrease value of a given stat by an int variable
    void size_up(int):  increase size of the stat by an int variable
    void size_down(int): decrease size of the stat by an int variable
    stat_name enum_name() const: returns enum of m_name
    std::string name() cost: returns name of stat in string form for use by other parts of the program
    int size() const: returns total size of stat object
    int current() const: returns current stat value
*/
class Stat
{
public:
//list of all stat values for all player and enemy characters and also equipables listed as enum
    enum stat_name
    {
        hp,
        attack,
        defense,
        agility,
        luck,
    };
//default zero-value constructor
    Stat(stat_name name);
//default value constructor
    Stat(stat_name name, int size);
//default destructor
    ~Stat() = default;
//change stat value
    void change(int change_by);
//change stat size, pass in negative int to decrease and positive to increase stat size
    void change_size(int change_by);
//decrease stat size
    void size_down(int decrease_by);
//reset current_value to maximum size
    void reset();
//set stat size
    void set_size(int size);
//getters
//  name
    stat_name enum_name() const {return m_name;}
//  name of stat in std::string form
    std::string name() const;
//  current_value
    int current() const {return m_current_value;}
//  size
    int size() const {return m_size;}
private:
    stat_name m_name{};
    int m_current_value{};
    int m_size{};
};
#endif