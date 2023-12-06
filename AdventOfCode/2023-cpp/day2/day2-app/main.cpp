#include <aoc-file-lib\file.hpp>
#include <day2/lib.hpp>

#include <algorithm>
#include <concepts>
#include <iostream>
#include <list>
#include <numeric>
#include <ranges>
#include <vector>

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

    std::cout << "Got " << lines.size() << " lines." << '\n';

    aoc::day2::RevealedCubeSet limit{12, 13, 14};

    auto none_above_limit = [limit](const auto r) {
        return r.red < limit.red && r.green < limit.green && r.blue < limit.blue;
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

    auto count = std::accumulate(not_possibles.begin(), not_possibles.end(), 0);

    std::cout << "Sum of game id is: " << count << std::endl;

    return 0; // Exit successfully
}
