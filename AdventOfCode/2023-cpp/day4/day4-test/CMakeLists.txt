# Tests need to be added as executables first
add_executable(day4_lib_tests test.cpp)

target_compile_features(day4_lib_tests PRIVATE cxx_std_23)

# =====================================================================
# Adding Dependencies
# =====================================================================

find_package(Catch2 CONFIG REQUIRED)
target_link_libraries(day4_lib_tests PRIVATE Catch2::Catch2 Catch2::Catch2WithMain)

target_link_libraries(day4_lib_tests PRIVATE day4_lib)

# =====================================================================
# Test Configuration
# =====================================================================

# If you register a test, then ctest and make hit will run it.
# You can also run examples and check the output, as well.
add_test(NAME run_day4_lib_tests COMMAND day4_lib_tests) # Command can be a target
