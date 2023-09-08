cmake_minimum_required(VERSION 3.27.0)

set (CMAKE_CXX_STANDARD 20)

set(CMAKE_CXX_FLAGS_RELEASE "-O2")

project(darkened VERSION 0.0.1)


set(HEADER_FILES 
    src/error_handling/include/error.h
    src/error_handling/include/log.h
    src/game/include/stat.h
    src/game/include/global.h
    src/game/include/armor.h
    src/game/include/player.h
    src/game/include/random.h
    src/game/include/enemy.h
)

include_directories(src/game/include src/error_handling/include)

add_executable(darkened
    src/error_handling/error.cpp
    src/game/stat.cpp
    src/game/random.cpp
    src/game/enemy.cpp
    src/game/player.cpp
    src/main.cpp
)