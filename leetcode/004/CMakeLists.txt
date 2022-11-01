add_executable(test004 lib.hpp test.cpp test_main.cpp lib.cpp)

target_link_libraries(test004 PRIVATE Catch2::Catch2)

add_test(NAME testing004 COMMAND test004)