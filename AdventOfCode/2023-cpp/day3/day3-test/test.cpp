#include <catch2/catch_test_macros.hpp>
#include <catch2/matchers/catch_matchers_predicate.hpp>
#include <concepts>
#include <cstdio>
#include <day3/lib.hpp>
#include <ranges>

using namespace Catch;
using namespace aoc::day3;

#include <iostream>
#include <string_view>


TEST_CASE("Test output")
{
    REQUIRE(true == true);
}

TEST_CASE("tokenize_engine_line, with number, returns correct token")
{
    auto engine_line = "7";

    auto result = tokenize_engine_line(engine_line);

    REQUIRE(result[0].type == TokenType::NUMBER);
    REQUIRE(result[0].value == 7);
}

TEST_CASE("tokenize_engine_line, with a period, returns correct token")
{
    auto engine_line = ".";

    auto result = tokenize_engine_line(engine_line);

    REQUIRE(result[0].type == TokenType::PERIOD);
}
