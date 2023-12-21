#include <catch2/catch_test_macros.hpp>
#include <catch2/matchers/catch_matchers_predicate.hpp>
#include <concepts>
#include <cstdio>
#include <day5/lib.hpp>
#include <functional>
#include <ranges>

using namespace Catch;
using namespace aoc::day5;

#include <iostream>
#include <string_view>

//TEST_CASE("Test output")
//{
//    REQUIRE(true == true);
//
//    // Check to see if they keys got ordered
//    std::map<int, int> e{{1, 100}, {2, 500}, {0, 12125}};
//
//    for (auto v : e)
//    {
//        std::cout << v.first << '\n';
//    }
//
//    test();
//
//    auto map_list = std::vector<std::function<int(int)>>{[](auto a) { return a + 1; }, [](auto a) { return a + 1; }};
//
//    auto t = std::vector<int>{1, 2, 3, 4, 5} | std::views::transform(map_list[0]) | std::ranges::to<std::vector>();
//
//    for (const auto &map : map_list)
//    {
//        t = t | std::views::transform(map) | std::ranges::to<std::vector>();
//    }
//}

TEST_CASE("get_seeds", "[day5]")
{
    SECTION("With four numbers, parses and returns those four.")
    {
        std::string input = "seeds: 10 1000 100000 1241248";

        auto seeds = get_seeds(input);

        REQUIRE(seeds.size() == 4);
        REQUIRE(seeds[0] == 10);
        REQUIRE(seeds[1] == 1000);
        REQUIRE(seeds[2] == 100000);
        REQUIRE(seeds[3] == 1241248);
    }
}