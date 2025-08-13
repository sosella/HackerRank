# Without using any string methods, try to print the following:

# 123...n

# Note that "..." represents the consecutive values in between.

if __name__ == '__main__':
    n = int(input())

    for i in range(n):
        print(f"{i+1}", end="")
    print()
