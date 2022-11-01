a = [1, 2, 3, 10, 5, 3, 14]
b = [-1, 4, 5, 6, 14]

if __name__ == '__main__':
    t = [x for x in (a + b) if x in a and x not in b]

    print(list(set(t)))