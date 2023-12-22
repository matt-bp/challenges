add_library(aoc_file_lib "src/file.cpp" "src/string_helpers.cpp")

target_include_directories(aoc_file_lib PUBLIC ${CMAKE_CURRENT_SOURCE_DIR}/include)

target_compile_features(aoc_file_lib PUBLIC cxx_std_23)