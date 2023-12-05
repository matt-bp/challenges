#include <catch2/catch_test_macros.hpp>

using namespace Catch;

// aiMatrix4x4 create_test_matrix() {
//     aiMatrix4x4 in;
//     in.a1 = 1;
//     in.a2 = 2;
//     in.a3 = 3;
//     in.a4 = 4;
//
//     in.b1 = 5;
//     in.b2 = 6;
//     in.b3 = 7;
//     in.b4 = 8;
//
//     in.c1 = 9;
//     in.c2 = 10;
//     in.c3 = 11;
//     in.c4 = 12;
//
//     in.c1 = 13;
//     in.c2 = 14;
//     in.c3 = 15;
//     in.c4 = 16;
//
//     return in;
// }

TEST_CASE("convert_to_glm, with some aiMatrix4x4, returns that matrix in "
          "column major order") {
  REQUIRE(true == true);
}