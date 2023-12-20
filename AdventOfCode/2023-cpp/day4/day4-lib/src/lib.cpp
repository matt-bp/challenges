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
    std::regex numbers_group(R"(Card\s+\d*:\s+((?:\d+\s+)*)\|((?:\s+\d+)*))");

    auto next = std::sregex_iterator(s.begin(), s.end(), numbers_group);
    const auto end = std::sregex_iterator();
    std::string_view delim = " ";

    const auto to_string = [](const auto &sv) { return std::string(sv.begin(), sv.end()); };
    const auto not_empty = [](const auto &str) { return str != ""; };
    const auto to_int = [](const auto &str) { return std::stoi(str); };

    const auto get_nums_from_string = [&](const std::string &in_str) {
        // clang-format off
        return std::views::split(in_str, delim) 
            | std::views::transform(to_string)
            | std::views::filter(not_empty)
            | std::views::transform(to_int)
            | std::ranges::to<std::vector>();
        // clang-format on
    };

    if (next == end)
    {
        return {};
    }

    const std::smatch &matches = *next;

    assert(matches.size() == 3);

    auto winning_nums = get_nums_from_string(matches[1].str());
    auto nums = get_nums_from_string(matches[2].str());

    return std::make_pair(nums, winning_nums);
}

int get_number_of_matches(std::vector<int> numbers, std::vector<int> winning_numbers)
{
    std::ranges::sort(numbers);
    std::ranges::sort(winning_numbers);

    std::vector<int> out;

    std::ranges::set_intersection(numbers, winning_numbers, std::back_inserter(out));

    return out.size();
}

} // namespace aoc::day4
