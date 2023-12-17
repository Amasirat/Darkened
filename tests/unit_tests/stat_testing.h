#ifndef STAT_TEST_H
#define STAT_TEST_H
#include "stat.h"
#include <iostream>
Stat stat{Stat::hp};

void stat_print_status()
{
    std::cout << "size: " << stat.size() << 
    "\ncurrent: " << stat.current() << "\n\n";
}

void test_change()
{
    std::cout << "change value: \n";
    stat_print_status();
    stat.change(-5);
    stat_print_status();
}

void test_change_size()
{
    std::cout << "change size: \n";
    stat_print_status();
    stat.change_size(10);
    stat_print_status();
}

void test_reset() 
{
    std::cout << "reset: \n";
    stat_print_status();
    stat.reset();
    stat_print_status();
}

void test_set_size()
{
    std::cout << "setting size: \n";
    stat_print_status();
    stat.set_size(14);
    stat_print_status();
}

#endif