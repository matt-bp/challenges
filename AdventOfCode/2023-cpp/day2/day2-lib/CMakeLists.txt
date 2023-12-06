
add_library(day2_lib "src/lib.cpp")

target_include_directories(day2_lib PUBLIC ${CMAKE_CURRENT_SOURCE_DIR}/include)

target_compile_features(day2_lib PUBLIC cxx_std_20)
