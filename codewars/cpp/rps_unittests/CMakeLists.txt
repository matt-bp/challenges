# Testing library
FetchContent_Declare(
  catch
  GIT_REPOSITORY https://github.com/catchorg/Catch2.git
  GIT_TAG v3.4.0)
FetchContent_MakeAvailable(catch)
# Adds Catch2::Catch2

# Tests need to be added as executables first
add_executable(rps_unittests testlib.cpp)

# I'm using C++17 in the test
target_compile_features(rps_unittests PRIVATE cxx_std_17)

target_link_libraries(rps_unittests PRIVATE rps_lib Catch2::Catch2 Catch2::Catch2WithMain)

# If you register a test, then ctest and make test will run it.
# You can also run examples and check the output, as well.
add_test(NAME rps_unitteststest COMMAND rps_unittests) # Command can be a target
