#include "aoc-file-lib\file.hpp"

#include <fstream>
#include <iostream>

bool test() { return true; }

std::vector<std::string> aoc::file::getAllLinesFromFile(std::string filename) {
  std::fstream file(filename);

  if (!file.is_open()) {
    std::cerr << "Couldn't open the file: " << filename << std::endl;
  }

  std::vector<std::string> lines;

  std::string line;
  while (std::getline(file, line)) {
    lines.push_back(line);
  }

  return lines;
}