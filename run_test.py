import sys
import os
import subprocess
"""
This script automatically runs test on one class and takes in only one argument for the directory of the .cpp file of the intended
class of the function intended to be tested

example: python run_test.py src/stat.cpp
"""
# Compiles and runs test program taking the directory to the appropiate .cpp directory of the class
# intending to be tested
TEST_EXEC_CPP = "test_runner.cpp"
ERROR_CPP = "../src/error.cpp"
TEST_EXEC = "test"
def run_test(test_directory):
    clang_command = f"clang++ -std=c++17 {ERROR_CPP} {TEST_EXEC_CPP} {test_directory} -o {TEST_EXEC}"
    os.chdir("tests")
    result = os.system(clang_command)
    if result == 0:
        os.system(f"./{TEST_EXEC}")
    else:
        return

# main function
def main():
    if len(sys.argv) > 2:
        print("Too many arguments")
        return
    elif len(sys.argv) <= 1:
        print("No command arguments detected")
        return
    
    test_module = sys.argv[1]

    run_test(test_module)

if __name__ == "__main__":
    main()