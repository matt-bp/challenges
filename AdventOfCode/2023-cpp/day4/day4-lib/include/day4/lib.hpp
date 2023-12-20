#include <map>
#include <string>
#include <tuple>
#include <vector>

namespace aoc::day4
{

void test();

std::pair<std::vector<int>, std::vector<int>> get_numbers_and_winning_numbers(const std::string &s);

int get_number_of_matches(std::vector<int> numbers, std::vector<int> winning_numbers);

} // namespace aoc::day4
