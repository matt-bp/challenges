
add_library(day5_lib "src/lib.cpp")

target_include_directories(day5_lib PUBLIC ${CMAKE_CURRENT_SOURCE_DIR}/include)

target_link_libraries(day5_lib PRIVATE aoc_file_lib)

target_compile_features(day5_lib PUBLIC cxx_std_23)
