#include "lib.hpp"
#include <catch2/catch.hpp>

TEST_CASE("Example 1 from site", "[004]") {
    std::vector<int> nums1 = {1, 3};
    std::vector<int> nums2 = {2};

    auto result = Solution::findMedianSortedArrays(nums1, nums2);
    REQUIRE(2 == Approx(result));
}

TEST_CASE("Example 2 from site", "[004]") {
    std::vector<int> nums1 = {1, 2};
    std::vector<int> nums2 = {3, 4};

    auto result = Solution::findMedianSortedArrays(nums1, nums2);
    REQUIRE(2.5 == Approx(result));
}
