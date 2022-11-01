cmake_minimum_required(VERSION 3.14..3.22) 

project(leetcode LANGUAGES CXX)

include(FetchContent)
FetchContent_Declare(
  catch
  GIT_REPOSITORY https://github.com/catchorg/Catch2.git
  GIT_TAG v2.13.6)
FetchContent_MakeAvailable(catch)

enable_testing()
add_subdirectory("001")
add_subdirectory("004")


