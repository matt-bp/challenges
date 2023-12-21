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

namespace aoc::day5
{
void test()
{
    std::cout << "Test day5" << '\n';
}

std::vector<int> get_seeds(const std::string& line)
{
    using namespace std::views;

    std::string_view delim = " ";
    const auto to_string = [](const auto &sv) { return std::string(sv.begin(), sv.end()); };
    const auto not_empty = [](const auto &str) { return str != ""; };
    const auto to_int = [](const auto &str) { return std::stoi(str); };

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

} // namespace aoc::day5
