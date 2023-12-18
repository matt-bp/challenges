
add_library(day4_lib "src/lib.cpp")

target_include_directories(day4_lib PUBLIC ${CMAKE_CURRENT_SOURCE_DIR}/include)

target_compile_features(day4_lib PUBLIC cxx_std_23)
