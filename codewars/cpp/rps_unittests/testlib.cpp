#include <catch2/catch_test_macros.hpp>
#include <catch2/matchers/catch_matchers_string.hpp>
#include <rps_lib/lib.hpp>

TEST_CASE("Draw", "[rps]") {
    const std::string p1 = "rock";
    const std::string p2 = "rock";

    const auto result = rps(p1, p2);

    REQUIRE_THAT(result, Catch::Matchers::ContainsSubstring("Draw!"));
}