itemA = int(input())
qtdA = int(input())
priceA = float(input())
itemB = int(input())
qtdB = int(input())
priceB = float(input())

totalA = priceA * qtdA
totalB = priceB * qtdB
soma = totalA + totalB
print(f'TOTAL A PAGAR: R$ {soma:.2f}')