#include <rps_lib/lib.hpp>

#include <algorithm>
#include <tuple>
#include <vector>

std::tuple<double, double> a(const std::vector<double> &values) {

  return std::make_tuple(values.front(), values.back());
}
