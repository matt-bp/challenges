#include "day1/lib.hpp"

#include <optional>
#include <regex>
#include <iostream>
#include <sstream>

char get_digit(const std::string &str) {
  if (str == "one" || str == "1") {
    return '1';
  } else if (str == "two" || str == "2") {
    return '2';
  } else if (str == "three" || str == "3") {
    return '3';
  } else if (str == "four" || str == "4") {
    return '4';
  } else if (str == "five" || str == "5") {
    return '5';
  } else if (str == "six" || str == "6") {
    return '6';
  } else if (str == "seven" || str == "7") {
    return '7';
  } else if (str == "eight" || str == "8") {
    return '8';
  } else if (str == "nine" || str == "9") {
    return '9';
  } else {
    throw std::runtime_error("Achk!");
  }
}

std::string combine_pair(std::optional<char> first,
                         std::optional<char> second) {
  std::stringstream ss;

  ss << first.value();
  ss << second.value();

  return ss.str();
}

// For part one
std::string aoc::day1::get_two_digit_p1(const std::string &str) {
  std::optional<char> first;
  std::optional<char> second;

  for (const auto &c : str) {
    if (std::isdigit(c)) {
      if (!first.has_value()) {
        first = c;
      } else {
        second = c;
      }
    }
  }

  return combine_pair(first, second);
}

std::string aoc::day1::get_two_digit_p2(const std::string &str) {
  std::regex digits_regex("[1-9]|one|two|three|four|five|six|seven|eight|nine");
  std::smatch digits_match;

  std::optional<char> first;
  std::optional<char> second;

  std::cout << str << '\n';

  const auto end = std::sregex_iterator();
  for (auto i = std::sregex_iterator(str.begin(), str.end(), digits_regex);
       i != end; ++i) {
    const std::smatch &m = *i;
    std::cout << "\t" << m.str() << " at position " << m.position() << '\n';

    const auto c = get_digit(m.str());

    if (!first.has_value()) {
      first = c;
      second = c;
    } else {
      second = c;
    }
  }

  std::cout << "  chose: " << first.value() << "," << second.value() << '\n';

  return combine_pair(first, second);
}
