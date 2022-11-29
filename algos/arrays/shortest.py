

def shortest(arr) -> list:
    result = []
    for i in range(len(arr)):
        # true found so we set result to zer
        if arr[i]:
            result.append(0)
            continue
        # false, how far to a true
        j = 1
        while (i+j < len(arr) and arr[i+j] == False):
            j += 1
        
    return []


assert shortest([True, False, True, False, False]) == [0,1,0,1,2], "simple test"