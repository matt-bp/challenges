add_executable(day2_app main.cpp)

target_link_libraries(day2_app PRIVATE aoc_file_lib)
target_link_libraries(day2_app PRIVATE day2_lib)

target_compile_features(day2_app PUBLIC cxx_std_23)