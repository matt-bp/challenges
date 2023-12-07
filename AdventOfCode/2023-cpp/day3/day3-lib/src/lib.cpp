#include "day3/lib.hpp"

#include <cassert>
#include <iostream>
#include <ranges>
#include <regex>
#include <sstream>

namespace aoc::day3
{
void test()
{
    std::cout << "Test" << '\n';
}

std::vector<EngineToken> tokenize_engine_line(const std::string &engine_line)
{
    const auto tokenize = [](const auto c) -> EngineToken {
        if (std::isdigit(c))
        {
            return EngineToken{c - '0', TokenType::NUMBER};
        }
        else if (c == '.')
        {
            return EngineToken{0, TokenType::PERIOD};
        }
        else
        {
            return EngineToken{0, TokenType::SYMBOL};
        }
    };

    return engine_line | std::views::transform(tokenize) | std::ranges::to<std::vector>();
}

std::vector<EngineToken> get_numbers_by_symbols(const std::vector<std::vector<EngineToken>> &engine)
{
    return {};
}

} // namespace aoc::day3
