cmake_minimum_required(VERSION 3.27.0)

set (CMAKE_CXX_STANDARD 20)

set(CMAKE_CXX_FLAGS_RELEASE "-O2")

project(darkened VERSION 0.0.1)

add_executable(darkened
    src/error.cpp
    src/stat.cpp
    src/random.cpp
    src/main.cpp
)