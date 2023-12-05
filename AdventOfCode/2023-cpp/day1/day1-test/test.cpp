#include <catch2/catch_test_macros.hpp>
#include <day1/lib.hpp>

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

TEST_CASE("Simple string part 1, numbers on end, returns those two") {
  const auto input = "1abc2";
  const auto result = aoc::day1::get_two_digit_p1(input);

  REQUIRE(result == "12");
}

TEST_CASE("Simple string part 2, numbers spelled out on end, returns those two") {
  const auto input = "two1nine";
  const auto result = aoc::day1::get_two_digit_p2(input);

  REQUIRE(result == "29");
}

TEST_CASE("Simple string part 2, overlapped numbers, returns those two") {
  const auto input = "eightwo";
  const auto result = aoc::day1::get_two_digit_p2(input);

  REQUIRE(result == "82");
}

//TEST_CASE("Test output") {
//  aoc::day1::print_all_digit_matches("eightwo");
//
//  REQUIRE(true == true);
//}