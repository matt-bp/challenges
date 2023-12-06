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

std::pair<int, std::vector<RevealedCubeSet>> get_sets_from_game(const std::string &game)
{
    std::vector<RevealedCubeSet> result;

    std::regex game_number_regex("Game (\\d+):");
    std::smatch ms;

    assert(std::regex_search(game, ms, game_number_regex));
    
    int game_number = std::stoi(ms[1]);

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

    return std::make_pair(game_number, result);
}

} // namespace aoc::day2
