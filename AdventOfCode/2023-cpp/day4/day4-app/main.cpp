#include <aoc-file-lib\file.hpp>
#include <day4/lib.hpp>

#include <algorithm>
#include <concepts>
#include <functional>
#include <iostream>
#include <list>
#include <numeric>
#include <ranges>
#include <tuple>
#include <utility>
#include <vector>

using namespace aoc::day4;

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

    // For each line, get the numbers you have, and the winning numbers
    auto get_pairs = [](const std::string &s) { return std::make_pair(std::vector<int>(), std::vector<int>()); };

    auto get_points = [](const std::pair<std::vector<int>, std::vector<int>> pairs) { return 0; };

    // user view and translate to get all this to points

    // For each pair of numbers and winning numbers, find how many points you have

    // clang-format off
    auto points = lines
        | std::views::transform(get_pairs)
        | std::views::transform(get_points)
        | std::ranges::to<std::vector>();
    // clang-format on

    // Add up all those points together
    const auto answer = std::accumulate(points.begin(), points.end(), 0);

    std::cout << "Answer is: " << 0 << '\n';
    std::cout << '\n';
}

void part_two(const std::vector<std::string> &lines)
{
    std::cout << "Part Two" << '\n';
    std::cout << "==========================" << '\n';

    std::cout << "Answer is: " << 0 << '\n';
    std::cout << '\n';
}