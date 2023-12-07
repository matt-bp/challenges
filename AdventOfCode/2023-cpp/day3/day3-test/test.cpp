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

    // Check to see if they keys got ordered
    std::map<int, int> e{{1, 100}, {2, 500}, {0, 12125}};

    for (auto v : e)
    {
        std::cout << v.first << '\n';
    }
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

TEST_CASE("tokenize_engine_line, one number left of symbol, returns that token")
{
    auto engine_line = "7*";

    auto result = tokenize_engine_line(engine_line);

    REQUIRE(result[0].value == 7);
}

TEST_CASE("get_numbers_by_symbols, two numbers left of symbol, returns sum of those numbers")
{
    std::vector<std::vector<EngineToken>> engine;

    std::vector<EngineToken> first_row;
    first_row.push_back(EngineToken{3, TokenType::NUMBER});
    first_row.push_back(EngineToken{7, TokenType::NUMBER});
    first_row.push_back(EngineToken{0, TokenType::SYMBOL});

    engine.push_back(first_row);

    auto result = get_numbers_by_symbols(engine);

    REQUIRE(result[0] == 37);
}

TEST_CASE("get_numbers_by_symbols, two numbers right of symbol, returns sum of those numbers")
{
    std::vector<std::vector<EngineToken>> engine;

    std::vector<EngineToken> first_row;
    first_row.push_back(EngineToken{0, TokenType::SYMBOL});
    first_row.push_back(EngineToken{8, TokenType::NUMBER});
    first_row.push_back(EngineToken{5, TokenType::NUMBER});
    
    engine.push_back(first_row);

    auto result = get_numbers_by_symbols(engine);

    REQUIRE(result[0] == 85);
}
