#include <aoc-file-lib\file.hpp>
#include <fstream>
#include <iostream>
#include <optional>
#include <regex>
#include <sstream>
#include <string>
#include <vector>

std::string get_two_digit_p1(const std::string &str);
std::string get_two_digit_p2(const std::string &str);
char get_digit(const std::string &str);
std::string combine_pair(std::optional<char> first, std::optional<char> second);

int main(int argc, char **argv) {
  std::cout << "Hello world!" << std::endl;

  // We pass in our pointer, and how many elements are in it.
  // We're skipping the first, which is the path to this executable.
  std::vector<std::string> arguments(argv + 1, argv + argc);

  // Check if there are any arguments
  if (arguments.size() != 2) {
    std::cout << "Usage: " << argv[0] << " <part> <input filename>"
              << std::endl;
    return 1;
  }

  const auto part = std::stoi(arguments[0]);

  const auto &filename = arguments[1];
  const auto lines = aoc::file::getAllLinesFromFile(filename);

  auto sum = 0;

  for (const auto &line : lines) {
    const auto two_digit =
        part == 1 ? get_two_digit_p1(line) : get_two_digit_p2(line);
    const auto number = std::stoi(two_digit);
    sum += number;
  }

  std::cout << "Sum is: " << sum << '\n';

  return 0; // Exit successfully
}

// For part one
std::string get_two_digit_p1(const std::string &str) {
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

std::string get_two_digit_p2(const std::string &str) {
  std::regex digits_regex("[0-9]|one|two|three|four|five|six|seven|eight|nine");
  std::smatch digits_match;

  std::optional<char> first;
  std::optional<char> second;

  const auto end = std::sregex_iterator();
  for (auto i = std::sregex_iterator(str.begin(), str.end(), digits_regex);
       i != end; ++i) {
    const std::smatch &m = *i;
    std::cout << m.str() << " at position " << m.position() << '\n';

    const auto &c = get_digit(m.str());

    if (!first.has_value()) {
      first = c;
    } else {
      second = c;
    }
  }

  return combine_pair(first, second);
}

char get_digit(const std::string &str) {
  if (str.size() == 1 && std::isdigit(str.at(0))) {
    return str[0];
  }

  if (str == "one") {
    return '1';
  } else if (str == "two") {
    return '2';
  } else if (str == "three") {
    return '3';
  } else if (str == "four") {
    return '4';
  } else if (str == "five") {
    return '5';
  } else if (str == "six") {
    return '6';
  } else if (str == "seven") {
    return '7';
  } else if (str == "eight") {
    return '8';
  } else if (str == "nine") {
    return '9';
  } else {
    throw std::runtime_error("Achk!");
  }
}

std::string combine_pair(std::optional<char> first, std::optional<char> second)
{
  std::stringstream ss;

  ss << first.value();

  if (!second.has_value()) {
    ss << first.value();
  } else {
    ss << second.value();
  }

  return ss.str();
}