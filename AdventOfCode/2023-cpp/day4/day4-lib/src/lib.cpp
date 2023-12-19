#include "day4/lib.hpp"

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

namespace aoc::day4
{
void test()
{
    std::cout << "Test 4" << '\n';
}

std::pair<std::vector<int>, std::vector<int>> get_numbers_and_winning_numbers(const std::string &s)
{
    std::regex numbers_group("Card \\d*: ((?:\\d+ )*)\\|((?: \\d+)*)");

    auto next = std::sregex_iterator(s.begin(), s.end(), numbers_group);
    const auto end = std::sregex_iterator();
    std::string_view delim = " ";

    const auto to_string = [](const auto &sv) { return std::string(sv.begin(), sv.end()); };

    const auto get_nums_from_string = [&](const std::string &in_str) {
        // clang-format off
        return std::views::split(in_str, delim) 
            | std::views::transform(to_string)
            | std::views::filter([](const auto &num_str){ return num_str != "";})
            | std::views::transform([](const auto &num_str){ return std::stoi(num_str);})
            | std::ranges::to<std::vector>();
        // clang-format on
    };

    if (next == end)
    {
        return {};
    }

    const std::smatch &matches = *next;

    assert(matches.size() == 3);

    auto nums = get_nums_from_string(matches[1].str());
    auto winning_nums = get_nums_from_string(matches[2].str());

    return std::make_pair(nums, winning_nums);
}

int get_points(std::vector<int> numbers, std::vector<int> winning_numbers)
{
    std::ranges::sort(numbers);
    std::ranges::sort(winning_numbers);

    std::vector<int> out;

    std::ranges::set_intersection(numbers, winning_numbers, std::back_inserter(out));

    if (out.size() == 0)
        return 0;

    return std::pow(2, out.size() - 1);
}

} // namespace aoc::day4
