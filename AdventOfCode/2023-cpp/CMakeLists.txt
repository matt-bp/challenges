# Works with 3.14 and tested through 3.27
cmake_minimum_required(VERSION 3.14...3.27)

# Project name and a few useful settings. Other commands can pick up the results
project(
  AdventOfCode2023
  VERSION 0.1
  DESCRIPTION "Working through Advent of Code 2023 in C++."
  LANGUAGES CXX
)

message("Toolchain file: ${CMAKE_TOOLCHAIN_FILE}")

# Only do these if this is the main project, and not if it is included through add_subdirectory
if(CMAKE_PROJECT_NAME STREQUAL PROJECT_NAME)

include(./vcpkg/scripts/buildsystems/vcpkg.cmake)

endif()

add_subdirectory(day1)
add_subdirectory(day2)
add_subdirectory(day3)
add_subdirectory(day4)
add_subdirectory(shared)