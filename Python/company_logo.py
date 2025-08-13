# Given a string s, which is the company name in lowercase letters, 
# your task is to find the top three most common characters in the string.

# Print the three most common characters along with their occurrence count.
# Sort in descending order of occurrence count.
# If the occurrence count is the same, sort the characters in alphabetical order.

# For example, according to the conditions described above,

# GOOGLE would have it's logo with the letters G, O, E.

# Input Format

# A single line of input containing the string S.

# Constraints

# S has at least 3 distinct characters

# Output Format

# Print the three most common characters along with their occurrence count each on a separate line.
# Sort output in descending order of occurrence count.
# If the occurrence count is the same, sort the characters in alphabetical order.

# Sample Input 0

# aabbbccde

# Sample Output 0

# b 3
# a 2
# c 2

# from collections import defaultdict

if __name__ == '__main__':
    # s = input()

    s = "aabbbccde"

    characters = {}
    for ch in s:
        if ch in characters:
            characters[ch] += 1
        else:
            characters[ch] = 1

    sorted_items = sorted(characters.items(), key=lambda item: item[1], reverse=True)
    sorted_dict = dict(sorted_items)
    # print(sorted_dict)

    # inverted_dict = defaultdict(list)
    inverted_dict = {}
    for key, value in sorted_dict.items():
        if not value in inverted_dict:
            inverted_dict[value] = []
        inverted_dict[value].append(key)
    # print(inverted_dict)

    count = 0
    for frequency in inverted_dict:
        if count == 3:
            break
        # print(type(inverted_dict[frequency]))
        # print(inverted_dict[frequency])
        sorted_characters = sorted(inverted_dict[frequency])
        # print(type(sorted_characters))
        # print(sorted_characters)
        for ch in sorted_characters:
            print(f"{ch} {frequency}")
            count += 1
            if count == 3:
                break
