add_executable(day4_app main.cpp)

target_link_libraries(day4_app PRIVATE aoc_file_lib)
target_link_libraries(day4_app PRIVATE day4_lib)

target_compile_features(day4_app PUBLIC cxx_std_23)

# Compiler Options for main program
if ("${CMAKE_CXX_COMPILER_ID}" STREQUAL "MSVC")
    # /W4            - nearly most strict warnings
    # /permissive-    - strict c++ standards compliance
    # /WX            - warnings as errors
    target_compile_options(day4_app PRIVATE /W4 /permissive- /WX /std:c++latest)
elseif ("${CMAKE_CXX_COMPILER_ID}" STREQUAL "GNU")
    # -Wall            - most of the warnings
    # -Wextra        - more warnings
    # -pedantic        - more warnings!
    # -Werror        - warnings as errors
    target_compile_options(day4_app PRIVATE -Wall -Wextra -pedantic -Werror -O3)
endif()