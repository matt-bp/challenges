#include <aoc-file-lib\file.hpp>
#include <day3/lib.hpp>

#include <algorithm>
#include <concepts>
#include <functional>
#include <iostream>
#include <list>
#include <numeric>
#include <ranges>
#include <tuple>
#include <vector>

using namespace aoc::day3;

void part_one(const std::vector<std::string> &lines);
void part_two(const std::vector<std::string> &lines);

int main(int argc, char **argv)
{
    // We pass in our pointer, and how many elements are in it.
    // We're skipping the first, which is the path to this executable.
    std::vector<std::string> arguments(argv + 1, argv + argc);

    // Check if there are any arguments
    if (arguments.size() != 1)
    {
        std::cout << "Usage: " << argv[0] << " <input filename>" << std::endl;
        return 1;
    }

    const auto &filename = arguments[0];
    const auto lines = aoc::file::getAllLinesFromFile(filename);

    part_one(lines);
    part_two(lines);

    return 0; // Exit successfully
}

void part_one(const std::vector<std::string> &lines)
{
    std::cout << "Part One" << '\n';
    std::cout << "==========================" << '\n';

    // clang-format off
    auto engine = lines 
        | std::views::transform(tokenize_engine_line) 
        | std::ranges::to<std::vector>();
    // clang-format on

    auto sum = std::ranges::fold_left(get_numbers_by_symbols(engine), 0, std::plus());

    std::cout << "Sum of game id is: " << sum << '\n';
    std::cout << '\n';
}

void part_two(const std::vector<std::string> &lines)
{
    std::cout << "Part Two" << '\n';
    std::cout << "==========================" << '\n';

    std::cout << '\n';
}