#include <catch2/catch_test_macros.hpp>
#include <catch2/matchers/catch_matchers_predicate.hpp>
#include <concepts>
#include <cstdio>
#include <day4/lib.hpp>
#include <ranges>

using namespace Catch;
using namespace aoc::day4;

#include <iostream>
#include <string_view>

// TEST_CASE("Test output")
//{
//     REQUIRE(true == true);
//
//     // Check to see if they keys got ordered
//     std::map<int, int> e{{1, 100}, {2, 500}, {0, 12125}};
//
//     for (auto v : e)
//     {
//         std::cout << v.first << '\n';
//     }
//
//     test();
// }

TEST_CASE("get_number_winning_numbers", "[day4]")
{
    std::vector<int> numbers = {1, 2, 3, 4, 5};

    SECTION("No winning numbers returns 0")
    {
        std::vector<int> winning_numbers = {};

        auto result = get_number_winning_numbers(numbers, winning_numbers);

        REQUIRE(result == 0);
    }

    SECTION("One winning number returns 1")
    {
        std::vector<int> winning_numbers = {numbers[0]};

        auto result = get_number_winning_numbers(numbers, winning_numbers);

        REQUIRE(result == 1);
    }

    SECTION("Two winning number returns 2")
    {
        std::vector<int> winning_numbers = {numbers[1], numbers[0]};

        auto result = get_number_winning_numbers(numbers, winning_numbers);

        REQUIRE(result == 2);
    }

    SECTION("Four winning number returns 4")
    {
        std::vector<int> winning_numbers = {numbers[1], numbers[0], numbers[2], numbers[3]};

        auto result = get_number_winning_numbers(numbers, winning_numbers);

        REQUIRE(result == 4);
    }
}

TEST_CASE("get_numbers_and_winning_numbers", "[day4]")
{
    SECTION("Example from input, returns the two lists")
    {
        auto in = "Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11";

        auto result = get_numbers_and_winning_numbers(in);

        REQUIRE(result.first.size() == 8);
        REQUIRE(result.second.size() == 5);
    }
}
