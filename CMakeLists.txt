cmake_minimum_required(VERSION 3.27.0)

set (CMAKE_CXX_STANDARD 20)

set(CMAKE_CXX_FLAGS_RELEASE "-O2")

project(darkened VERSION 0.0.1)

set(HEADER_FILES 
    src/error_handling/include/error.h
    src/error_handling/include/log.h
    src/sys/include/save.h
    src/game/include/classes/stat.h
    src/game/include/classes/global.h
    src/game/include/classes/armor.h
    src/game/include/classes/player.h
    src/game/include/classes/random.h
    src/game/include/classes/enemy.h
)

include_directories(
    src/game/classes/include 
    src/error_handling/include
    src/sys/include    
)

add_executable(darkened
    src/error_handling/error.cpp
    src/sys/save.cpp
    src/game/classes/stat.cpp
    src/game/classes/random.cpp
    src/game/classes/enemy.cpp
    src/error_handling/log.cpp
    src/game/classes/player.cpp
    src/main.cpp
)