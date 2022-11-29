def queens(boardSize, queenIndex, a, b, c):
    if queenIndex < boardSize:
        for j in range(boardSize):
            if j not in a and queenIndex+j not in b and queenIndex-j not in c:
                yield from queens(boardSize, queenIndex+1, a+[j], b+[queenIndex+j], c+[queenIndex-j])
    else:
        yield a

for solution in queens(8, 0, [], [], []):
    print(solution)
    