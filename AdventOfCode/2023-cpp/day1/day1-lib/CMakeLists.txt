
add_library(day1_lib "src/lib.cpp")

target_include_directories(day1_lib PUBLIC ${CMAKE_CURRENT_SOURCE_DIR}/include)

target_compile_features(day1_lib PUBLIC cxx_std_17)
