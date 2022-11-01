use std::env;
use std::fs;

fn intro() {
    println!("Advent of Code : Day 2");
    println!("======================\n");
}

fn main() {
    intro();

    let args: Vec<String> = env::args().collect();

    let contents = fs::read_to_string(args[1].clone())
        .expect("Something went wrong reading the file");
    let content = contents.split("\n").collect::<Vec<&str>>();

    let mut forward = 0;
    let mut depth = 0;
    let mut aim = 0;

    for command in content {
        let split_command = command.split(" ").collect::<Vec<&str>>();
        match split_command[..] {
            [action, value] => {
                let parsed_value = value.trim().parse::<i32>().unwrap();
                match action {
                    "forward" => {
                        forward += parsed_value;
                        depth += aim * parsed_value;
                    },
                    "up" => {
                        aim -= parsed_value;
                    },
                    "down" => {
                        aim += parsed_value;
                    },
                    _ => println!("Invalid action")
                }
            },
            _ => {} 
        }
    }

    println!("Forward: {}, Depth: {}, Product: {}", forward, depth, forward * depth);
}
