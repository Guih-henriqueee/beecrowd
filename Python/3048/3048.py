large = int(input())
entrys = []
for i in range(large):
    entry = int(input())
    entrys.append(entry)
    
contagem = 0
lastNum = None
for i in entrys:
    if i == 1  and (lastNum == None or lastNum == 2):
        lastNum = 1
        contagem += 1
    elif i == 2  and (lastNum == None or lastNum == 1):
        lastNum = 2
        contagem += 1
              
print(contagem)
    