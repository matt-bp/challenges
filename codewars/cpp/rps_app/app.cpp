#include <rps_lib\lib.hpp>

#include <fmt/format.h>

#include <iostream>
#include <vector>
#include <tuple>

int main() {
    std::vector<double> input = {1.2, 2.3, 3.4, 4.5};

    auto [front, back] = a(input);

    fmt::print("Front: {}, Back: {}\n",  front, back);

    return 0;
}
