cmake_minimum_required(VERSION 3.27.0)

set (CMAKE_CXX_STANDARD 20)

set(CMAKE_CXX_FLAGS_RELEASE "-O2")

project(darkened VERSION 0.0.1)

set(HEADER_FILES 
    src/error_handling/include/error.h
    src/error_handling/include/log.h
    src/game/sys/include/save.h
    src/game/sys/include/database.h
    src/game/sys/include/input_output.h
    src/game/classes/include/stat.h
    src/game/sys/include/global.h
    src/game/classes/include/armor.h
    src/game/classes/include/player.h
    src/game/classes/include/random.h
    src/game/classes/include/enemy.h
    tests/unit_tests/player_testing.h
)

include_directories(
    src/game/classes/include
    src/game/modules/include 
    src/error_handling/include
    src/game/sys/include
    tests/unit_tests
)

add_executable(darkened
    src/error_handling/error.cpp
    src/error_handling/log.cpp
    src/game/sys/save.cpp
    src/game/sys/input_output.cpp
    src/game/sys/database.cpp
    src/game/classes/stat.cpp
    src/game/classes/random.cpp
    src/game/classes/battle.cpp
    src/game/classes/enemy.cpp
    src/game/classes/player.cpp
    src/main.cpp
)

project(testing)

add_executable(testing
    src/error_handling/error.cpp
    src/error_handling/log.cpp
    src/game/sys/save.cpp
    src/game/sys/input_output.cpp
    src/game/sys/database.cpp
    src/game/classes/stat.cpp
    src/game/classes/random.cpp
    src/game/classes/battle.cpp
    src/game/classes/enemy.cpp
    src/game/classes/player.cpp 
    tests/test_driver.cpp
)