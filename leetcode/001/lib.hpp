#include <set>
#include <algorithm>
#include <string>
#include <iostream>

class Solution {
public:
    static int lengthOfLongestSubstring(std::string s) {

        if (s.empty()) return 0;

        std::set<char> readCharacters;

        int max{};

        int buildUp{};

        int startingCharacter{};

        for(size_t characterIndex = 0; characterIndex < s.size(); characterIndex++) {

            const char searchC = s[characterIndex];

            if (readCharacters.find(searchC) != readCharacters.end()) {
                std::cout << "Resetting! Found: " << searchC << std::endl;
//                auto temp = characterIndex;
//                characterIndex = startingCharacter + 1;
                startingCharacter += 1;
                characterIndex = startingCharacter;
                std::cout << "Char index: " << characterIndex << std::endl;
                readCharacters.clear();
                buildUp = 0;
            }

            const char actualC = s[characterIndex];

            std::cout << "Read: " << actualC << std::endl;
            readCharacters.insert(actualC);
            buildUp++;
            if (buildUp > max) {
                max = buildUp;
            }
        }

        return max;
    }
};

//#include <string>
//#include <set>
//#include <algorithm>
//
//class Solution {
//public:
//    static int lengthOfLongestSubstring(std::string s) {
//
//        if (s.empty()) return 0;
//
//        std::set<char> readCharacters;
//
//        int max{};
//
//        int buildUp{};
//
//        for(const auto& c : s) {
//            if (readCharacters.find(c) != readCharacters.end()) {
//                readCharacters.clear();
//                buildUp = 0;
//            }
//
//            readCharacters.insert(c);
//            buildUp++;
//            if (buildUp > max) {
//                max = buildUp;
//            }
//        }
//
//        int otherStartingMax = lengthOfLongestSubstring(s.substr(1));
//
//        if (otherStartingMax > max) {
//            max = otherStartingMax;
//        }
//
//        return max;
//    }
//};