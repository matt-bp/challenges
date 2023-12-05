#include <aoc-file-lib\file.hpp>
#include <day1/lib.hpp>

#include <iostream>
#include <vector>

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
        part == 1 ? aoc::day1::get_two_digit_p1(line) : aoc::day1::get_two_digit_p2(line);
    const auto number = std::stoi(two_digit);
    sum += number;
  }

  std::cout << "Sum is: " << sum << '\n';

  return 0; // Exit successfully
}
