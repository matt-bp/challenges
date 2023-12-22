#include <aoc-file-lib/file.hpp>
#include <day5/lib.hpp>

#include <algorithm>
#include <concepts>
#include <functional>
#include <iostream>
#include <iterator>
#include <list>
#include <numeric>
#include <ranges>
#include <tuple>
#include <utility>
#include <vector>

using namespace aoc::day5;

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

    // From input, get seeds, create functions that contain sets of ranges to check
    auto seeds = get_seeds(lines.front());

    std::copy(seeds.begin(), seeds.end(), std::ostream_iterator<long>(std::cout, " "));
    std::cout << '\n';

    // Functions that are created first need to be applied first to the seeds.
    auto mappings = get_mappings(lines | std::views::drop(2) | std::ranges::to<std::vector>());

    auto temp = seeds;

    for (const auto &map : mappings)
    {
        temp = temp | std::views::transform(map) | std::ranges::to<std::vector>();
    }

    auto answer = std::ranges::max(temp);

    std::cout << "Answer is: " << answer << '\n';
    std::cout << '\n';
}

void part_two(const std::vector<std::string> &lines)
{
    std::cout << "Part Two" << '\n';
    std::cout << "==========================" << '\n';

    const auto answer = lines.size();

    std::cout << "Answer is: " << answer << '\n';
    std::cout << '\n';
}