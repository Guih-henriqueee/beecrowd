Line1 = input().split()
Line2 = input().split()
codItemA = int(Line1[0])
qtdA = int(Line1[1])
priceA = float(Line1[2])
codItemB = int(Line2[0])
qtdB = int(Line2[1])
priceB = float(Line2[2])


totalA = priceA * qtdA
totalB = priceB * qtdB
soma = totalA + totalB
print(f'VALOR A PAGAR: R$ {soma:.2f}')
