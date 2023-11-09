#include <iostream>
#include <string>
#include <vector>
#include <fstream>
#include <tuple>

int main(int argc, char** argv)
{
    std::cout << "Hello world!" << std::endl;

    // We pass in our pointer, and how many elements are in it.
    // We're skipping the first, which is the path to this executable.
    std::vector<std::string> arguments(argv + 1, argv + argc);

    // Check if there are any arguments
    if (arguments.empty()) {
      std::cout << "Usage: " << argv[0] << " <arg1> <arg2> ..." << std::endl;
      return 1;
    }

    // Access the arguments using a range-based for loop
    int i = 1;
    for (const auto &arg : arguments) {
      std::cout << "Argument " << i++ << ": " << arg << std::endl;
    }

    const auto filename = arguments[0];

    std::fstream file(filename);

    if (!file.is_open()) {
      std::cerr << "Couldn't open the file: " << filename << std::endl;
      return 1;
    }

    std::string line;
    while (std::getline(file, line))
    {
      std::cout << "Read: " << line << std::endl;
    }

    int floor = 0;

    for (std::size_t i = 0; i < line.size(); i++) {
      const auto &c = line[i];
      if (c == '(') {
        floor++;
      } else {
        floor--;
      }

      if (floor < 0) {
        std::cout << "Basement character: " << i + 1 << std::endl;
        break;
      }
    }
    
    std::cout << "End floor is: " << floor << std::endl;

    return 0; // Exit successfully
}

