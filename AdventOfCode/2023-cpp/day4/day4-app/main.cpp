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

    // clang-format off
    auto points = lines
        | std::views::transform(get_numbers_and_winning_numbers)
        | std::views::transform([](auto p){ return get_number_of_matches(p.first, p.second);})
        | std::views::filter([](auto num_winning){ return num_winning != 0;})
        | std::views::transform([](const auto &num_winning){ return num_winning == 0 ? 0 : (int)std::pow(2, num_winning - 1); })
        | std::ranges::to<std::vector>();
    // clang-format on

    // Add up all those points together
    const auto answer = std::accumulate(points.begin(), points.end(), 0);

    std::cout << "Answer is: " << answer << '\n';
    std::cout << '\n';
}

void part_two(const std::vector<std::string> &lines)
{
    std::cout << "Part Two" << '\n';
    std::cout << "==========================" << '\n';

    // clang-format off
    auto number_of_matches = lines
        | std::views::transform(get_numbers_and_winning_numbers)
        | std::views::transform([](auto p){ return get_number_of_matches(p.first, p.second);})
        | std::ranges::to<std::vector>();
    // clang-format on

    std::vector<int> counts(number_of_matches.size(), 1);

    for (auto const [index, match_count] : std::views::enumerate(number_of_matches))
    {
        for (auto j = index + 1; j <= index + match_count; j++)
        {
            counts[j] += counts[index];
        }
    }

    auto total_scratchcards = std::ranges::fold_left(counts, 0, std::plus());

    std::cout << "Answer is: " << total_scratchcards << '\n';
    std::cout << '\n';
}