use std::env;
use std::fs;

fn intro() {
    println!("Advent of Code : Day 3");
    println!("======================\n");
}

fn main() {
    intro();

    let args: Vec<String> = env::args().collect();
    let filename = args[1].clone();
    println!("Opening file: {}", filename);

    let contents = fs::read_to_string(filename)
        .expect("Something went wrong reading the file");
    let content = contents.split("\n").collect::<Vec<&str>>();

    let length = content[0].trim().len();
    //println!("{}", length);
    let mut gamma_bits = vec![0; length];
    let mut epsilon_bits = vec![0; length];

    for letter_index in 0usize..length {
        let mut count_zero = 0;
        let mut count_one = 0;

        for number in &content {
            let trimmed = number.trim();
            if trimmed == "" {
                continue;
            }

            let current_char = trimmed.chars().nth(letter_index).unwrap();
            //println!("Index: {}, Current: {}", letter_index, current_char);

            match current_char {
                '0' => { count_zero += 1; },
                '1' => { count_one += 1; },
                _ => {println!("Error: don't know what to do with {}", current_char);}
            }
        }

        let gamma_bit = if count_one > count_zero { 1 } else { 0 };
        //println!("Bit for index {}, {}", letter_index, current_bit);
        gamma_bits[letter_index] =  gamma_bit;


        let epsilon_bit = if count_one < count_zero { 1 } else { 0 };
        epsilon_bits[letter_index] = epsilon_bit;
    }

    println!("{:?}", gamma_bits);
    println!("{:?}", epsilon_bits);
}
