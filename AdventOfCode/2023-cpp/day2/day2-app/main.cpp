#include <aoc-file-lib\file.hpp>
#include <day2/lib.hpp>

#include <algorithm>
#include <concepts>
#include <iostream>
#include <list>
#include <numeric>
#include <ranges>
#include <tuple>
#include <vector>

void part_one(const std::vector<std::string> &lines);
void part_two(const std::vector<std::string> &lines);

int main(int argc, char **argv)
{
    std::cout << "Hello world!" << std::endl;

    // We pass in our pointer, and how many elements are in it.
    // We're skipping the first, which is the path to this executable.
    std::vector<std::string> arguments(argv + 1, argv + argc);

    // Check if there are any arguments
    if (arguments.size() != 2)
    {
        std::cout << "Usage: " << argv[0] << " <part> <input filename>" << std::endl;
        return 1;
    }

    const auto part = std::stoi(arguments[0]);

    const auto &filename = arguments[1];
    const auto lines = aoc::file::getAllLinesFromFile(filename);

    if (part == 1)
    {
        part_one(lines);
    }
    else if (part == 2)
    {
        part_two(lines);
    }

    return 0; // Exit successfully
}

void part_one(const std::vector<std::string> &lines)
{
    std::cout << "Part One" << '\n';
    std::cout << "==========================" << '\n';

    aoc::day2::RevealedCubeSet limit{12, 13, 14};

    auto none_above_limit = [limit](const auto r) {
        return r.red <= limit.red && r.green <= limit.green && r.blue <= limit.blue;
    };

    auto is_possible = [&](const auto pairs) {
        return std::all_of(pairs.second.begin(), pairs.second.end(), none_above_limit);
    };

    auto get_game_id = [](const auto pair) { return pair.first; };

    // clang-format off
    auto not_possibles = lines 
        | std::views::transform(aoc::day2::get_sets_from_game) 
        | std::views::filter(is_possible)
        | std::views::transform(get_game_id)
        | std::ranges::to<std::vector>();
    // clang-format on

    auto sum = std::accumulate(not_possibles.begin(), not_possibles.end(), 0);

    std::cout << "Sum of game id is: " << sum << std::endl;
}

void part_two(const std::vector<std::string> &lines)
{
    std::cout << "Part Two" << '\n';
    std::cout << "==========================" << '\n';

    auto get_upper_bound_on_game_color = [&](const auto pairs) {
        int max_red = std::numeric_limits<int>::min();
        int max_green = std::numeric_limits<int>::min();
        int max_blue = std::numeric_limits<int>::min();

        for (const auto &set : pairs.second)
        {
            max_red = std::max(set.red, max_red);
            max_green = std::max(set.green, max_green);
            max_blue = std::max(set.blue, max_blue);
        }

        return std::make_tuple(max_red, max_green, max_blue);
    };

    auto get_power_of_set = [](const auto maxes) {
        return std::get<0>(maxes) * std::get<1>(maxes) * std::get<2>(maxes);
    };

    // clang-format off
    auto power_sets = lines 
        | std::views::transform(aoc::day2::get_sets_from_game) 
        | std::views::transform(get_upper_bound_on_game_color)
        | std::views::transform(get_power_of_set)
        | std::ranges::to<std::vector>();
    // clang-format on

    auto sum = std::accumulate(power_sets.begin(), power_sets.end(), 0);

    std::cout << "Sum of power of sets is: " << sum << std::endl;
}