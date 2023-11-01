#pragma once

#include <vector>
#include <tuple>

/// \brief Accumulate a vector to produce the mean and the first moment of the distribution.
///
/// This computes the mean and the first moment of a vector of double values.
///
std::tuple<double, double> a(const std::vector<double> &values);