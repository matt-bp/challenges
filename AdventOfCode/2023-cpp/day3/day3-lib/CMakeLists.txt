
add_library(day3_lib "src/lib.cpp")

target_include_directories(day3_lib PUBLIC ${CMAKE_CURRENT_SOURCE_DIR}/include)

target_compile_features(day3_lib PUBLIC cxx_std_23)
