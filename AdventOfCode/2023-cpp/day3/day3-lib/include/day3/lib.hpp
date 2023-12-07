#include <map>
#include <string>
#include <vector>

namespace aoc::day3
{

void test();

enum TokenType
{
    PERIOD = 0b0001,
    SYMBOL = 0b0010,
    NUMBER = 0b0100
};

struct EngineToken
{
    int value;
    TokenType type;
};

std::vector<EngineToken> tokenize_engine_line(const std::string &engine_line);

std::vector<int> get_numbers_by_symbols(const std::vector<std::vector<EngineToken>> &engine);

} // namespace aoc::day3
