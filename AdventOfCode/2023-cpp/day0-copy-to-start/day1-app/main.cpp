#include <aoc-file-lib\file.hpp>
#include <fstream>
#include <iostream>
#include <string>
#include <vector>

int main(int argc, char **argv) {
  std::cout << "Hello world!" << std::endl;

  // We pass in our pointer, and how many elements are in it.
  // We're skipping the first, which is the path to this executable.
  std::vector<std::string> arguments(argv + 1, argv + argc);

  // Check if there are any arguments
  if (arguments.empty()) {
    std::cout << "Usage: " << argv[0] << " <input filename>" << std::endl;
    return 1;
  }

  // Access the arguments using a range-based for loop
  int i = 1;
  for (const auto &arg : arguments) {
    std::cout << "Argument " << i++ << ": " << arg << std::endl;
  }

  const auto &filename = arguments[0];

  const auto lines = aoc::file::getAllLinesFromFile(filename);

  for (const auto &line : lines) {
    std::cout << "Line:" << line << std::endl;


  }


  return 0; // Exit successfully
}
