#ifndef STAT_H
#define STAT_H

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
//getters
//  name
    stat_name name() const {return m_name;}
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