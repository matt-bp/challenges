#include "day3/lib.hpp"

#include <cassert>
#include <iostream>
#include <ranges>
#include <regex>
#include <set>
#include <sstream>
#include <utility>

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

std::vector<int> get_numbers_by_symbols(const std::vector<std::vector<EngineToken>> &engine)
{
    std::set<std::pair<int, int>> already_used_cells;

    auto construct_number_from_found_token = [&](int row, int col) {
        already_used_cells.insert(std::make_pair(row, col));
        return engine[row][col].value;
    };

    auto row_col_already_used = [&already_used_cells](int row, int col) {
        auto search = already_used_cells.find(std::make_pair(row, col));
        return search != already_used_cells.end();
    };

    std::vector<int> numbers_found;

    for (std::size_t row = 0; row < engine.size(); row++)
    {
        for (std::size_t col = 0; col < engine[0].size(); col++)
        {
            if (engine[row][col].type & TokenType::SYMBOL)
            {
                // Check left side
                if (col >= 1 && !row_col_already_used(row, col - 1) && engine[row][col - 1].type & TokenType::NUMBER)
                {
                    numbers_found.push_back(construct_number_from_found_token(row, col - 1));
                }
            }
        }
    }

    return numbers_found;
}

} // namespace aoc::day3
