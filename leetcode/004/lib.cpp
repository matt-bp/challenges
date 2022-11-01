//
// Created by MattBishop on 4/14/2022.
//

#include "lib.hpp"
#include <algorithm>

double Solution::findMedianSortedArrays(std::vector<int> &nums1, std::vector<int> &nums2) {
    std::vector<int> dest;
    std::merge(nums1.begin(), nums1.end(), nums2.begin(), nums2.end(), std::back_inserter(dest));

    const auto size = dest.size();

    if (size % 2 == 0) {
        const auto mid = size / 2;
        return (dest[mid-1] + dest[mid]) / 2.0;
    } else {
        return dest[size / 2];
    }
}