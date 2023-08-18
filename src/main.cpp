#include <iostream>
#include "../tests/unit_tests.h"

int main()
{
    try
    {
        stat_size_up_test(5);
    }
    catch(const Error& e)
    {
        e.print();
    }
      

    return 0;
}