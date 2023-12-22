#include "aoc-file-lib\string_helpers.hpp"

#include <ranges>

namespace aoc::string_helpers
{

std::vector<int> get_ints_from_string(const std::string &line)
{
    using namespace std::views;

    std::string_view delim = " ";
    const auto to_string = [](const auto &sv) { return std::string(sv.begin(), sv.end()); };
    const auto not_empty = [](const auto &str) { return !str.empty(); };
    const auto to_int = [](const auto &str) { return std::stoi(str); };

    // clang-format off
    return line 
        | split(delim)
        | transform(to_string)
        | filter(not_empty)
        | transform(to_int)
        | std::ranges::to<std::vector>();
}

}; // namespace aoc::string_helpers