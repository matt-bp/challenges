#include "lib.hpp"

#include <catch2/catch.hpp>

TEST_CASE("Small input", "[001]") {
    auto result = Solution::lengthOfLongestSubstring("a");
    REQUIRE(1 == result);

    result = Solution::lengthOfLongestSubstring("ab");
    REQUIRE(2 == result);

    result = Solution::lengthOfLongestSubstring("aba");
    REQUIRE(2 == result);

    result = Solution::lengthOfLongestSubstring("abc");
    REQUIRE(3 == result);

    result = Solution::lengthOfLongestSubstring("abca");
    REQUIRE(3 == result);
}

TEST_CASE("Sub-patterns", "[001]") {
    auto result = Solution::lengthOfLongestSubstring("abacde");
    REQUIRE(5 == result);
}

TEST_CASE("Given test cases", "[001]") {
    auto result = Solution::lengthOfLongestSubstring("tmmzuxt");
    REQUIRE(5 == result);
}