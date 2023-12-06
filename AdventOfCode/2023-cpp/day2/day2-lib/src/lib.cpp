#include "day2/lib.hpp"

#include <cassert>
#include <iostream>
#include <regex>
#include <sstream>

namespace aoc::day2
{
void test()
{
    std::cout << "Test" << '\n';
}

std::vector<RevealedCubeSet> get_sets_from_game(const std::string &game)
{
    std::vector<RevealedCubeSet> result;

    std::string beginning = ":";

    std::string sets = game.substr(game.find(beginning) + 1, game.size() - 1);

    std::stringstream ss(sets);
    std::string temp;

    while (std::getline(ss, temp, ';'))
    {
        std::regex count_and_color_regex("([0-9]+) (red|green|blue)");

        auto begin = std::sregex_iterator(temp.begin(), temp.end(), count_and_color_regex);
        auto end = std::sregex_iterator();

        auto new_result = RevealedCubeSet();

        for (auto &it = begin; it != end; ++it)
        {

            const std::smatch &matches = *it;

            assert(matches.size() == 3);

            const auto value = std::stoi(matches[1]);

            if (matches[2] == "red")
            {
                new_result.red += value;
            }
            else if (matches[2] == "green")
            {
                new_result.green += value;
            }
            else if (matches[2] == "blue")
            {
                new_result.blue += value;
            }
            else
            {
                throw std::runtime_error("Not a valid color");
            }
        }

        result.push_back(new_result);
    }

    return result;
}

RevealedCubeSet get_max_colors_in_game(const std::vector<RevealedCubeSet> &sets)
{
    RevealedCubeSet max{std::numeric_limits<int>::min(), std::numeric_limits<int>::min(),
                        std::numeric_limits<int>::min()};

    for (const auto &set : sets)
    {
        max.red = std::max(set.red, max.red);
        max.green = std::max(set.green, max.green);
        max.blue = std::max(set.blue, max.blue);
    }

    return max;
}

} // namespace aoc::day2
