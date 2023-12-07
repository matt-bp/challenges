#include "day3/lib.hpp"

#include <cassert>
#include <iostream>
#include <ranges>
#include <regex>
#include <set>
#include <sstream>
#include <utility>
#include <map>

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
    // std::set<std::pair<int, int>> already_used_cells;

    auto is_valid_and_a_number = [&engine](int row, int col) -> bool {
        if (col < 0 || col >= engine[0].size())
            return false;

        return engine[row][col].type & TokenType::NUMBER;
    };

    // auto row_col_available = [&already_used_cells](int row, int col) {
    //     auto search = already_used_cells.find(std::make_pair(row, col));
    //     return search != already_used_cells.end();
    // };

    auto construct_number_from_found_token = [&](int row, int col) {


        // first, find all the numbers that are connected together
        std::map<int, int> connected_numbers{};

        // first go left
        for (auto temp_col = col; is_valid_and_a_number(row, temp_col); temp_col--)
        {
            connected_numbers.insert({temp_col, engine[row][temp_col].value});
        }

        // then right
        for (auto temp_col = col + 1; is_valid_and_a_number(row, temp_col); temp_col++)
        {
            connected_numbers.insert({temp_col, engine[row][temp_col].value});
        }

        // then, combine them into one number using the method below
        int multiplier = 1;
        int sum = 0;

        for (auto v : connected_numbers | std::views::reverse)
        {
            sum += v.second * multiplier;

            multiplier *= 10;
        }

        return sum;
    };

    std::vector<int> numbers_found;

    for (std::size_t row = 0; row < engine.size(); row++)
    {
        for (std::size_t col = 0; col < engine[0].size(); col++)
        {
            if (engine[row][col].type & TokenType::SYMBOL)
            {
                // Check left side
                if (is_valid_and_a_number(row, col - 1))
                {
                    numbers_found.push_back(construct_number_from_found_token(row, col - 1));
                }

                // Check right side
                if (is_valid_and_a_number(row, col + 1))
                {
                    numbers_found.push_back(construct_number_from_found_token(row, col + 1));
                }
            }
        }
    }

    return numbers_found;
}

} // namespace aoc::day3
