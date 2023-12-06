#include <map>
#include <string>
#include <vector>

namespace aoc::day2
{

void test();

struct RevealedCubeSet
{
    int red;
    int green;
    int blue;
};

std::vector<RevealedCubeSet> get_sets_from_game(const std::string &game);

RevealedCubeSet get_max_colors_in_game(const std::vector<RevealedCubeSet> &sets);

} // namespace aoc::day2
