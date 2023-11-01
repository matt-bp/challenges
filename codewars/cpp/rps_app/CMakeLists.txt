add_executable(rps_app app.cpp)
target_compile_features(rps_app PRIVATE cxx_std_17)

target_link_libraries(rps_app PRIVATE fmt::fmt rps_lib)
