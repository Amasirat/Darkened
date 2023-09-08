import sys
import os
"""
This script automatically runs test on one class and takes in only one argument for the directory of the .cpp file of the intended
class of the function intended to be tested

example: python run_test.py src/stat.cpp
"""
# Global Variables
TEST_CPP_DIR = "tests/test_runner.cpp"
ERROR_CPP = "src/error_handling/error.cpp"
TEST_EXEC = "tests/test_run"
# Compiles and runs test program taking the directory to the appropiate .cpp directory of the class
# intending to be tested
def run_test(test_directory):
    command = f"clang++ -std=c++17  -o {TEST_EXEC} {ERROR_CPP} {TEST_CPP_DIR} "
    for test in test_directory:
        command += f"{test} "
    result = os.system(command)
    if result == 0:
        os.system(f"./{TEST_EXEC}")

def run_test_noargs():
    command = f"clang++ -std=c++17  -o {TEST_EXEC} {ERROR_CPP} {TEST_CPP_DIR}"
    result = os.system(command)
    if result == 0:
        os.system(f"./{TEST_EXEC}")
    

# main function
def main():
# condition checks to make sure user puts in only one argument
    if len(sys.argv) > 10:
        print("Too many arguments")
        return
    elif len(sys.argv) <= 1:
        run_test_noargs()
    
    test_module = sys.argv[1:]
    run_test(test_module)

if __name__ == "__main__":
    main()