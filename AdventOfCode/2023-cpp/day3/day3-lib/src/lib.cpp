#include "day3/lib.hpp"

#include <cassert>
#include <iostream>
#include <map>
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

    auto row_col_taken = [&already_used_cells](int row, int col) {
        auto search = already_used_cells.find({row, col});
        return search != already_used_cells.end();
    };

    auto is_valid_available_and_a_number = [&](int row, int col) -> bool {
        if (col < 0 || col >= engine[0].size())
            return false;

        if (row < 0 || row >= engine.size())
            return false;

        if (row_col_taken(row, col))
            return false;

        already_used_cells.insert({row, col});

        return engine[row][col].type & TokenType::NUMBER;
    };

    auto create_cells_to_check = [](int row, int col) {
        std::vector<std::pair<int, int>> cells;

        // Top
        cells.push_back({row + 1, col - 1});
        cells.push_back({row + 1, col});
        cells.push_back({row + 1, col + 1});

        // Middle
        cells.push_back({row, col - 1});
        cells.push_back({row, col + 1});

        // Bottom
        cells.push_back({row - 1, col - 1});
        cells.push_back({row - 1, col});
        cells.push_back({row - 1, col + 1});

        return cells;
    };

    auto construct_number_from_found_token = [&](int row, int col) {
        // first, find all the numbers that are connected together
        std::map<int, int> connected_numbers{};

        connected_numbers.insert({col, engine[row][col].value});

        // first go left
        for (auto temp_col = col - 1; is_valid_available_and_a_number(row, temp_col); temp_col--)
        {
            connected_numbers.insert({temp_col, engine[row][temp_col].value});
        }

        // then right
        for (auto temp_col = col + 1; is_valid_available_and_a_number(row, temp_col); temp_col++)
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
                for (const auto &cell : create_cells_to_check(row, col))
                {
                    if (!is_valid_available_and_a_number(cell.first, cell.second))
                        continue;

                    numbers_found.push_back(construct_number_from_found_token(cell.first, cell.second));
                }
            }
        }
    }

    return numbers_found;
}

} // namespace aoc::day3
