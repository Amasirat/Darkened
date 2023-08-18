import sys
import os
"""
This script automatically runs test on one class and takes in only one argument for the directory of the .cpp file of the intended
class of the function intended to be tested

example: python run_test.py src/stat.cpp
"""
def main():
    if len(sys.argv) > 2:
        print("Too many arguments")
        return
    
    test_module = sys.argv[1]


if __name__ == "__main__":
    main()