valor = int(input())


cedulas = [100, 50, 20, 10, 5, 2, 1]

for cedula in cedulas:
    quantidade_cedulas = valor // cedula
    valor %= cedula  
    print(f"{quantidade_cedulas} nota(s) de R$ {cedula},00")