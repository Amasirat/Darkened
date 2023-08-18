#include "unit_tests.h"
#include "test_case.h"
#include "../src/error.h"

int main()
{
    try
    {
        for(auto test_case : Stat_test::test_case)
        {
            stat_size_up_test(test_case);
        }
    }
    catch(const Error& e)
    {
        e.print();
    }
    
    return 0;
}