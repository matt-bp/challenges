#include "day5/lib.hpp"

#include <cassert>
#include <iomanip>
#include <iostream>
#include <map>
#include <ranges>
#include <regex>
#include <set>
#include <sstream>
#include <string_view>
#include <utility>
#include <aoc-file-lib\string_helpers.hpp>

namespace aoc::day5
{
void test()
{
    std::cout << "Test day5" << '\n';
}

std::vector<int> get_seeds(const std::string &line)
{
    using namespace std::views;

    std::string_view delim = " ";
    const auto to_string = [](const auto &sv) { return std::string(sv.begin(), sv.end()); };
    const auto not_empty = [](const auto &str) { return !str.empty(); };
    const auto to_int = [](const auto &str) { return std::stoi(str); };

    //return aoc::string_helpers::get_ints_from_string(line.substr())

    // clang-format off
    return line 
        | drop(6)
        | split(delim)
        | transform(to_string)
        | filter(not_empty)
        | transform(to_int)
        | std::ranges::to<std::vector>();
    // clang-format on
}

std::vector<std::function<int(int)>> get_mappings(const std::vector<std::string> &mapping_lines)
{
    std::vector<std::function<int(int)>> maps{};
    std::vector<Mapping> mappings{};

    for (const auto &line : mapping_lines)
    {
        if (line.empty())
        {
            continue;
        }

        if (std::isalpha(line[0]))
        {
            maps.push_back([=](auto i) { return mappings.size(); });

            mappings = {};
            continue;
        }
    }

    return maps;
}

} // namespace aoc::day5
