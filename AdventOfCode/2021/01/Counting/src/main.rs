use std::env;
use std::fs;

fn help() {
    println!("Usage:
program <string>
    Does an operation on the filename.");
}

fn count_greater_than_previous(numbers: Vec<i32>) -> i32 {
    numbers.iter()
        .enumerate()
        .filter(|&(i, x)| i > 0 as usize && x > &numbers[i-1])
        .count() as i32
}

fn count_groups(numbers: Vec<i32>) -> i32 {
    let length = numbers.len();
    let sums = numbers.iter()
        .take(length - 2)
        .enumerate()
        .map(|(i, x)| x + &numbers[i+1] + &numbers[i+2])
        .collect();

    count_greater_than_previous(sums)
}

fn part_2(numbers: Vec<i32>) {
    let count = count_groups(numbers);
    println!("Count: {}", count);
}

fn part_1(numbers: Vec<i32>) {
    let count = count_greater_than_previous(numbers);
    println!("Count: {}", count);
}

fn main() {
    let args: Vec<String> = env::args().collect();

    match &args[..] {
        [_path, filename] => {
            println!("Opening {}", filename);
            let contents = fs::read_to_string(filename)
                .expect("Something went wrong reading the file");
            let numbers: Vec<i32> = contents
                .split("\n")
                .filter(|&s| s != "")
                .map(|s| s.trim().parse::<i32>().unwrap())
                .collect();
            //part_1(numbers);
            part_2(numbers);
        },
        _ => {
            help();
        }
    }
}
