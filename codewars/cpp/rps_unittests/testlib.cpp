#define CATCH_CONFIG_MAIN
#include <catch2/catch.hpp>
#include <rps_lib/lib.hpp>

TEST_CASE( "Quick check", "[main]" ) {
    std::vector<double> values {1, 2., 3.};
    auto [front, back] = a(values);

    REQUIRE(front == 1.0);
    REQUIRE(back == 3.0);
}
