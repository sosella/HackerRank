# The provided code stub reads an integer, n, from STDIN. For all non-negative integers i < n, print i squared.

if __name__ == '__main__':
    n = int(input())

    for i in range(n):
        print(f"{i * i}")
