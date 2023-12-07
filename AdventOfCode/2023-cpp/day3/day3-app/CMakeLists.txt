add_executable(day3_app main.cpp)

target_link_libraries(day3_app PRIVATE aoc_file_lib)
target_link_libraries(day3_app PRIVATE day3_lib)

target_compile_features(day3_app PUBLIC cxx_std_23)