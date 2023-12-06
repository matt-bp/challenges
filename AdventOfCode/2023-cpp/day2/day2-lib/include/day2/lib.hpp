#include <map>
#include <string>
#include <vector>
#include <utility>

namespace aoc::day2
{

void test();

struct RevealedCubeSet
{
    int red;
    int green;
    int blue;
};

std::pair<int, std::vector<RevealedCubeSet>> get_sets_from_game(const std::string &game);

} // namespace aoc::day2
