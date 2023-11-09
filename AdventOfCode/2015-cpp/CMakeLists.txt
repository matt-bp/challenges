# Works with 3.14 and tested through 3.27
cmake_minimum_required(VERSION 3.14...3.27)

# Project name and a few useful settings. Other commands can pick up the results
project(
  AdventOfCode2015
  VERSION 0.1
  DESCRIPTION "Working through Advent of Code 2015 in C++."
  LANGUAGES CXX
)

add_subdirectory(day1)
