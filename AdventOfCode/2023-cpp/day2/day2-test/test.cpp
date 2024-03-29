#include <catch2/catch_test_macros.hpp>
#include <catch2/matchers/catch_matchers_predicate.hpp>
#include <day2/lib.hpp>
#include <ranges>
#include <concepts>
#include <cstdio>

using namespace Catch;
using namespace aoc::day2;

TEST_CASE("Test output")
{
    REQUIRE(true == true);
}

TEST_CASE("get_sets_from_game_with_one_set_returns_that_set")
{
    auto game = "Game 1: 3 blue, 4 red";
    RevealedCubeSet expected{4, 0, 3};

    auto result = get_sets_from_game(game).second;

    REQUIRE_THAT(result[0], Matchers::Predicate<RevealedCubeSet>([expected](RevealedCubeSet v) {
                     return v.red == expected.red && v.green == expected.green && v.blue == expected.blue;
                 }));
}

TEST_CASE("get_sets_from_game_with_two_sets_returns_both")
{
    auto game = "Game 10: 3 blue, 4 red; 5 green, 1 blue, 2 red";
    RevealedCubeSet expected{2, 5, 1};

    auto result = get_sets_from_game(game);

    REQUIRE(result.first == 10);

    REQUIRE_THAT(result.second[1], Matchers::Predicate<RevealedCubeSet>([expected](RevealedCubeSet v) {
                     return v.red == expected.red && v.green == expected.green && v.blue == expected.blue;
                 }));
}

// For fun :)
TEST_CASE("String reversal C++23?")
{
    std::string input = "Hello world!";

    std::puts(input.c_str());

    auto reversed = input | std::views::reverse | std::ranges::to<std::string>();

    std::puts(reversed.c_str());

    REQUIRE(true == true);
}