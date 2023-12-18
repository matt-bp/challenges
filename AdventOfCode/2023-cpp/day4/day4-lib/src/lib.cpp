#include "day4/lib.hpp"

#include <cassert>
#include <iostream>
#include <map>
#include <ranges>
#include <regex>
#include <set>
#include <sstream>
#include <utility>

namespace aoc::day4
{
void test()
{
    std::cout << "Test 4" << '\n';
}

std::pair<std::vector<int>, std::vector<int>> get_numbers_and_winning_numbers(const std::string &s)
{
    return std::make_pair(std::vector<int>(), std::vector<int>());
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
