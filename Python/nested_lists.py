# Given the names and grades for each student in a class of N students, 
# store them in a nested list and 
# print the name(s) of any student(s) having the second lowest grade.

# A nested list in Python is a list that contains other lists as its elements. 
# This structure allows for the representation of multi-dimensional data, 
# similar to a matrix or a table. 

# Note: If there are multiple students with the second lowest grade, 
# order their names alphabetically and print each name on a new line.

# Input Format

# The first line contains an integer, N, the number of students.
# The 2N subsequent lines describe each student over 2 lines.
# - The first line contains a student's name.
# - The second line contains their grade.

# Constraints

# 2 <= N <= 5
# There will always be one or more students having the second lowest grade.

# Output Format

# Print the name(s) of any student(s) having the second lowest grade in. 
# If there are multiple students, order their names alphabetically and print each one on a new line.

if __name__ == '__main__':
    list = list(list())
    for _ in range(int(input())):
        name = input()
        score = float(input())
        list.append([name, score])

    # print(list)
    names = [list[i][0] for i in range(len(list))]
    scores = [list[i][1] for i in range(len(list))]
    # print(names)
    # print(scores)
    min_score = min(scores)
    count_of_min_score = scores.count(min_score)
    # print(f"The minimum score in the list is: {min_score}")
    # print(f"The count of the minimum score is: {count_of_min_score}")
    for i in range(count_of_min_score):
        index_of_min = scores.index(min_score)
        del names[index_of_min]
        del scores[index_of_min]
    # print(names)
    # print(scores)
    min_score = min(scores)
    count_of_min_score = scores.count(min_score)
    # print(f"The minimum score in the list is: {min_score}")
    # print(f"The count of the minimum score is: {count_of_min_score}")
    min_names = []
    for i in range(count_of_min_score):
        index_of_min = scores.index(min_score)
        min_names.append(names[index_of_min])
        del names[index_of_min]
        del scores[index_of_min]
    sorted_min_names = sorted(min_names)
    for i in range(len(sorted_min_names)):
        print(sorted_min_names[i])
