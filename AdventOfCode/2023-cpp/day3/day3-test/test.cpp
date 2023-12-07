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

TEST_CASE("tokenize_engine_line, with number, returns number token")
{
    auto engine_line = "7";

    auto result = tokenize_engine_line(engine_line);

    REQUIRE(result[0].type & TokenType::NUMBER);
    REQUIRE(result[0].value == 7);
}

TEST_CASE("tokenize_engine_line, with a period, returns period token")
{
    auto engine_line = ".";

    auto result = tokenize_engine_line(engine_line);

    REQUIRE(result[0].type & TokenType::PERIOD);
}

TEST_CASE("tokenize_engine_line, with not a period or number, returns symbol token")
{
    auto engine_line = "*";

    auto result = tokenize_engine_line(engine_line);

    REQUIRE(result[0].type & TokenType::SYMBOL);
}

TEST_CASE("get_numbers_by_symbols, no numbers by symbols, returns empty list")
{
    auto engine_line = "";

    auto result = tokenize_engine_line(engine_line);

    REQUIRE(result.empty());
}

TEST_CASE("get_numbers_by_symbols, one number left of symbol, returns that token")
{
    auto engine_line = "7*";

    auto result = tokenize_engine_line(engine_line);

    REQUIRE(result[0].value == 7);
}