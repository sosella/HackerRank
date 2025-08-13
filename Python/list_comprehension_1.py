# Given three integers x, y and z, print a list of all possible coordinates given by (i, j, k)
# where the sum of 
# i + j + k is not equal to n. 
# Here 0 <= i <= n, 0 <= j <= y, 0 <= k <= z. 
# Use list comprehensions rather than multiple loops, as a learning exercise.

# Input Format
# Four integers x, y, z and n, each on a separate line.

# Constraints
# Print the list in lexicographic increasing order.

if __name__ == '__main__':
    # x = int(input())
    # y = int(input())
    # z = int(input())
    # n = int(input())

    x = 1
    y = 1
    z = 2
    n = 3
    coordinates = [[i, j, k] for i in range(x + 1) for j in range(y + 1) for k in range(z + 1) if (i + j + k) != n]
    print(coordinates)

    # [[0, 0, 0], [0, 0, 1], [0, 0, 2], [0, 1, 0], [0, 1, 1], [1, 0, 0], [1, 0, 1], [1, 1, 0], [1, 1, 2]]
