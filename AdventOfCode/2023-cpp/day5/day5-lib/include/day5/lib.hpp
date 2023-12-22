#include <functional>
#include <map>
#include <string>
#include <tuple>
#include <vector>

namespace aoc::day5
{

void test();

std::vector<int> get_seeds(const std::string &line);

std::vector<std::function<int(int)>> get_mappings(const std::vector<std::string> &mapping_lines);

struct Mapping
{
    int source_start;
    int dest_start;
    int length;
};

} // namespace aoc::day5
