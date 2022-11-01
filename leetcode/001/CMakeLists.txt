add_executable(test001 lib.hpp test.cpp test_main.cpp)

target_link_libraries(test001 PRIVATE Catch2::Catch2)

add_test(NAME testing001 COMMAND test001)