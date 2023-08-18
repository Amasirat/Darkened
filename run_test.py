import sys
import os
"""
This automatic scripts takes in only one argument for the directory of the .cpp file of the intended
class function to test

python run_test.py src/stat.cpp

"""
def main():
    if len(sys.argv) > 2:
        print("Too many arguments")
        return
    
    test_module = sys.argv[1]
    print(test_module)


if __name__ == "__main__":
    main()