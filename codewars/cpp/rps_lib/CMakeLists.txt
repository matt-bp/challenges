# Note that headers are optional, and do not affect add_library, but they will not
# show up in IDEs unless they are listed in add_library.

# Optionally glob, but only for CMake 3.12 or later:
# file(GLOB HEADER_LIST CONFIGURE_DEPENDS "${ModernCMakeExample_SOURCE_DIR}/include/modern/*.hpp")
set(HEADER_LIST "${CMAKE_CURRENT_SOURCE_DIR}/include/rps_lib/lib.hpp")

# Make an automatic library - will be static or dynamic based on user setting
add_library(rps_lib src/lib.cpp ${HEADER_LIST})

# We need this directory, and users of our library will need it too
target_include_directories(rps_lib PUBLIC ./include)

# All users of this library will need at least C++11
target_compile_features(rps_lib PUBLIC cxx_std_11)
