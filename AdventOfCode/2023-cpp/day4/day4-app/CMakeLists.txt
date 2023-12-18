add_executable(day4_app main.cpp)

target_link_libraries(day4_app PRIVATE aoc_file_lib)
target_link_libraries(day4_app PRIVATE day4_lib)

target_compile_features(day4_app PUBLIC cxx_std_23)