cmake_minimum_required(VERSION 3.27.0)

set (CMAKE_CXX_STANDARD 17)

project(darkened VERSION 0.0.1)

add_executable(darkened 
    src/stat.cpp
    src/main.cpp
)