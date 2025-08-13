# Task

# You are given two integer arrays,  and  of dimensions X.
# Your task is to perform the following operations:

# Add ( + )
# Subtract ( - )
# Multiply ( * )
# Integer Division ( / )
# Mod ( % )
# Power ( ** )
# Note
# There is a method numpy.floor_divide() that works like numpy.divide() except it performs a floor division.

# Input Format

# The first line contains two space separated integers, N and M.
# The next N lines contains M space separated integers of array A.
# The following N lines contains M space separated integers of array B.

# Output Format

# Print the result of each operation in the given order under Task.

# Sample Input

# 1 4
# 1 2 3 4
# 5 6 7 8

# Sample Output

# [[ 6  8 10 12]]
# [[-4 -4 -4 -4]]
# [[ 5 12 21 32]]
# [[0 0 0 0]]
# [[1 2 3 4]]
# [[    1    64  2187 65536]] 

import numpy as np

if __name__ == '__main__':
    # Read N and M from the first line
    n, m = map(int, input().split())

    # Read array A
    a_elements = []
    for _ in range(n):
        row = list(map(int, input().split()))
        if len(row) != m:
            raise ValueError(f"Expected {m} elements in a row for array A, but got {len(row)}")
        a_elements.append(row)
    A = np.array(a_elements)

    # Read array B
    b_elements = []
    for _ in range(n):
        row = list(map(int, input().split()))
        if len(row) != m:
            raise ValueError(f"Expected {m} elements in a row for array B, but got {len(row)}")
        b_elements.append(row)
    B = np.array(b_elements)


    # Add ( + )
    print(A + B)
    # Subtract ( - )
    print(A - B)
    # Multiply ( * )
    print(A * B)
    # Integer Division ( / )
    print(A // B)
    # Mod ( % )
    print(A % B)
    # Power ( ** )
    print(A ** B)
